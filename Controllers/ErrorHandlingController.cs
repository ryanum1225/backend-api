using Microsoft.AspNetCore.Mvc;

namespace TechHiveSolutions.Controllers
{
    [ApiController]
    public class ErrorHandlingController : ControllerBase
    {
        [Route("/api/error")]
        public IActionResult HandleError() => Problem();
    }
}