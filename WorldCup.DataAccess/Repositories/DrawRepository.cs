using Microsoft.EntityFrameworkCore;
using WorldCup.DataAccess.Entities;

namespace WorldCup.DataAccess.Repositories
{
    public interface IDrawRepository: IDisposable
    {
        void AddDraw(Draw draw);
        IEnumerable<Draw> GetDraws();
        Task<IEnumerable<Draw>> GetDrawsAsync();
        void Save();
        Task SaveAsync();
    }
    public class DrawRepository : IDrawRepository
    {
        private readonly WorldCupDbContext _dbContext;
        private bool disposedValue;

        public DrawRepository(WorldCupDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddDraw(Draw draw)
        {
            _dbContext.Draws.Add(draw);
        }

        public IEnumerable<Draw> GetDraws()
        {
            return _dbContext.Draws.ToList();
        }

        public async Task<IEnumerable<Draw>> GetDrawsAsync()
        {
            return await _dbContext.Draws.ToListAsync();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
