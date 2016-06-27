using System;
using Microsoft.AspNet.Mvc;
using bookingServices.Models;
using System.Net;
using Microsoft.Extensions.Logging;

namespace bookingServices.Controllers.Api
{
    [Route("api/UnavailableDates")]
    public class UnavailableDatesController : Controller
    {
        private IBookingRepository _repository;
        private ILogger<UnavailableDatesController> _logger;

        public UnavailableDatesController(IBookingRepository repository, ILogger<UnavailableDatesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get(string eventName)
        {
            try
            {
                var results = _repository.GetAllUnavailableDates(eventName);

                if (results.Success == false)
                {                    
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(results.Message);
                }
                else
                    return Json(results.UnavailableDates);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to find the unavailable dates for the event: {eventName}.", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed to find the unavailable dates for the event");
            }
        }
    }
}
