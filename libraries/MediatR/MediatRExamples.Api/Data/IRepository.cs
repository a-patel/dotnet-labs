#region Imports
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace MediatRExamples.Api.Data
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
