using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrisonCollegePortal.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateController : ControllerBase, IDisposable
    {
        IWebHostEnvironment _environment;
        public DateController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of any managed resources here
                //_repository.Dispose();
            }
        }
        [HttpGet]
        [Route("GetDate")]
        public ActionResult<DateTime> GetDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}
