#region Imports
using MediatR;
using MediatRExamples.Api.Application.Customers.Commands;
using MediatRExamples.Api.Application.Customers.Queries;
using MediatRExamples.Api.Model;
using MediatRExamples.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
#endregion

namespace MediatRExamples.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        #region Members

        private readonly IMediator _mediator;
        private readonly ILogger<CustomerController> _logger;

        #endregion

        #region Ctor

        public CustomerController(IMediator mediator, ILogger<CustomerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetCustomersQuery());

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetCustomerByIdQuery
            {
                Id = id
            });

            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCustomerModel createCustomerModel)
        {
            //TODO: Use AutoMapper for mappings

            var customer = new Customer()
            {
                FirstName = createCustomerModel.FirstName,
                LastName = createCustomerModel.LastName,
                Birthday = createCustomerModel.Birthday,
                Age = createCustomerModel.Age,
                Phone = createCustomerModel.Phone,
            };

            var result = await _mediator.Send(new CreateCustomerCommand
            {
                Customer = customer
            });

            return Ok(result);
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerModel updateCustomerModel)
        {
            //TODO: Use AutoMapper for mappings

            var existCustomer = await _mediator.Send(new GetCustomerByIdQuery
            {
                Id = updateCustomerModel.Id
            });

            if (existCustomer == null)
            {
                return BadRequest($"No customer found with the id {updateCustomerModel.Id}");
            }


            var customer = new Customer()
            {
                Id = updateCustomerModel.Id,
                FirstName = updateCustomerModel.FirstName,
                LastName = updateCustomerModel.LastName,
                Birthday = updateCustomerModel.Birthday,
                Age = updateCustomerModel.Age,
                Phone = updateCustomerModel.Phone,
            };

            var result = await _mediator.Send(new UpdateCustomerCommand
            {
                Customer = customer
            });

            return Ok(result);
        }

        #endregion
    }
}
