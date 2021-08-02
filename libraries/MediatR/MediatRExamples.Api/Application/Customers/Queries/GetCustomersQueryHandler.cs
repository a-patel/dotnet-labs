#region Imports
using MediatR;
using MediatRExamples.Api.Data;
using MediatRExamples.Api.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
#endregion

namespace MediatRExamples.Api.Application.Customers.Queries
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<Customer>>
    {
        private readonly IRepository<Customer> _repository;

        public GetCustomersQueryHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll().ToList();
            //return await _repository.GetAll().ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
