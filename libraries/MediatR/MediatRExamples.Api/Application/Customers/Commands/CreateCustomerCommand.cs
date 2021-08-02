#region Imports
using MediatR;
using MediatRExamples.Api.Model;
#endregion

namespace MediatRExamples.Api.Application.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public Customer Customer { get; set; }
    }
}
