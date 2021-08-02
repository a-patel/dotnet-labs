#region Imports
using MediatR;
using MediatRExamples.Api.Data;
using MediatRExamples.Api.Model;
using System.Threading;
using System.Threading.Tasks;
#endregion

namespace MediatRExamples.Api.Application.Customers.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly IRepository<Customer> _repository;

        public UpdateCustomerCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.UpdateAsync(request.Customer);

            return customer;
        }
    }
}
