#region Imports
using AutoMapper;
using AutoMapperExamples.Api.Domain;
using AutoMapperExamples.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
#endregion

namespace AutoMapperExamples.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly ILogger<CustomerController> _logger;

        #endregion

        #region Ctor

        public CustomerController(IMapper mapper, ILogger<CustomerController> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IActionResult Get()
        {
            //TODO: Get it from in database
            var entity = new Customer()
            {
                Name = "Ashish Patel",
                Age = 30,
                Phone = "1234567890",
                Address = new Address { Country = "USA", State = "New York" }
            };

            var model = _mapper.Map<CustomerModel>(entity);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Add(CustomerModel model)
        {
            var entity = _mapper.Map<Customer>(model);

            //TODO: Save in database

            return Ok();
        }

        #endregion
    }
}
