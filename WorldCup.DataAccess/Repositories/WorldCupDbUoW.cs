using WorldCup.DataAccess.Entities;

namespace WorldCup.DataAccess.Repositories
{
    public class WorldCupDbUoW : IDisposable
    {
        private bool disposedValue;
        private readonly WorldCupDbContext _dbContext;
        private readonly GenericRepository<Country> _countriesRepository;
        private readonly GenericRepository<Team> _teamsRepository;
        private readonly GenericRepository<Group> _groupsRepository;
        private readonly GenericRepository<User> _usersRepository;
        private readonly GenericRepository<Draw> _drawsRepository;

        public WorldCupDbUoW(WorldCupDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _countriesRepository = new GenericRepository<Country>(dbContext);
            _teamsRepository = new GenericRepository<Team>(dbContext);
            _groupsRepository = new GenericRepository<Group>(dbContext);
            _usersRepository = new GenericRepository<User>(dbContext);
            _drawsRepository = new GenericRepository<Draw>(dbContext);
        }

        public GenericRepository<Country> CountriesRepository => _countriesRepository;

        public GenericRepository<Team> TeamsRepository => _teamsRepository;

        public GenericRepository<Group> GroupsRepository => _groupsRepository;

        public GenericRepository<User> UsersRepository => _usersRepository;

        public GenericRepository<Draw> DrawsRepository => _drawsRepository;

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
