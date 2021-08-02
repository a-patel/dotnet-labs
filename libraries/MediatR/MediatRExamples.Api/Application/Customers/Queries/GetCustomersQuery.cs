#region Imports
using MediatR;
using MediatRExamples.Api.Model;
using System.Collections.Generic;
#endregion

namespace MediatRExamples.Api.Application.Customers.Queries
{
    public class GetCustomersQuery : IRequest<List<Customer>>
    {
    }
}
