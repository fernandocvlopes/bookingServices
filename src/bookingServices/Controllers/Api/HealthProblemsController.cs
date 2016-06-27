using bookingServices.Models;
using Microsoft.AspNet.Mvc;

namespace bookingServices.Controllers.Api
{
    [Route("api/healthProblems")]
    public class HealthProblemsController : Controller
    {
        private IBookingRepository _repository;

        public HealthProblemsController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var healthProblems = _repository.GetAllHealthProblems();

            return Json(healthProblems);
        }
    }
}
