#region Imports
using MediatR;
using MediatRExamples.Api.Data;
using MediatRExamples.Api.Model;
using System.Threading;
using System.Threading.Tasks;
#endregion

namespace MediatRExamples.Api.Application.Customers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly IRepository<Customer> _repository;

        public CreateCustomerCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(request.Customer);
        }
    }
}
