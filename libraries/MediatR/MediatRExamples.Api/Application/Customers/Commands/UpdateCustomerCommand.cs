#region Imports
using MediatR;
using MediatRExamples.Api.Model;
using System;
#endregion

namespace MediatRExamples.Api.Application.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        public Customer Customer { get; set; }
    }
}
