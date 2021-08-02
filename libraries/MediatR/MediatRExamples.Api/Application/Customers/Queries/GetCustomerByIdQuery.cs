#region Imports
using MediatR;
using MediatRExamples.Api.Model;
using System;
#endregion

namespace MediatRExamples.Api.Application.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public Guid Id { get; set; }
    }
}
