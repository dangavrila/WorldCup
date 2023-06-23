using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WorldCup.DataAccess.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal WorldCupDbContext _dbContext;
        internal DbSet<TEntity> _entities;

        public GenericRepository(WorldCupDbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }
    }
}
