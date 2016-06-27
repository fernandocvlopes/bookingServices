using System;
using Microsoft.AspNet.Mvc;
using bookingServices.Models;
using System.Net;
using Microsoft.Extensions.Logging;
using bookingServices.ViewModels;

namespace bookingServices.Controllers.Api
{
    [Route("api/event")]
    public class EventsController : Controller
    {
        private IBookingRepository _repository;
        private ILogger<UnavailableDatesController> _logger;

        public EventsController(IBookingRepository repository, ILogger<UnavailableDatesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get(string eventName)
        {
            try
            {
                var results = _repository.GetEvent(eventName);

                if (results.Success == false)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(results.Message);
                }
                else
                    return Json(results.SelectedEvent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to find the event: {eventName}.", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed to find the event requested");
            }
        }

        [HttpPost("")]
        public JsonResult Post([FromBody] Booking vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Trying to save a new booking.");

                    if (_repository.AddBooking(vm))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json("Success");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to confirm the event.", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }
    }
}
