#region Imports
using System;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace MediatRExamples.Api.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        //private readonly AppDbContext _dbContext;

        //public Repository(AppDbContext customerContext)
        //{
        //    _dbContext = customerContext;
        //}

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();

            //try
            //{
            //    return _dbContext.Set<TEntity>();
            //}
            //catch (Exception)
            //{
            //    throw new Exception("Couldn't retrieve entities");
            //}
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();

            //if (entity == null)
            //{
            //    throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            //}

            //try
            //{
            //    await _dbContext.AddAsync(entity);
            //    await _dbContext.SaveChangesAsync();

            //    return entity;
            //}
            //catch (Exception)
            //{
            //    throw new Exception($"{nameof(entity)} could not be saved");
            //}
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();

            //if (entity == null)
            //{
            //    throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            //}

            //try
            //{
            //    _dbContext.Update(entity);
            //    await _dbContext.SaveChangesAsync();

            //    return entity;
            //}
            //catch (Exception)
            //{
            //    throw new Exception($"{nameof(entity)} could not be updated");
            //}
        }
    }
}
