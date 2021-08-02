#region Imports
using MediatR;
using MediatRExamples.Api.Data;
using MediatRExamples.Api.Model;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
#endregion

namespace MediatRExamples.Api.Application.Customers.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly IRepository<Customer> _repository;

        public GetCustomerByIdQueryHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll().FirstOrDefault(x => x.Id == request.Id);
            //return await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
