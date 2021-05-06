#region Imports
using AutofacExamples.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
#endregion

namespace AutofacExamples.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        #region Members

        private readonly IService _service;
        private readonly ILogger<TestController> _logger;

        #endregion

        #region Ctor

        public TestController(IService service, ILogger<TestController> logger)
        {
            _service = service;
            _logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.Method(0, "");
            return Ok(result);
        }

        #endregion
    }
}
