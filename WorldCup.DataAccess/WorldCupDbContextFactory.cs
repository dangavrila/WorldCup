using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.DataAccess
{
    public class WorldCupDbContextFactory : IDesignTimeDbContextFactory<WorldCupDbContext>
    {
        public WorldCupDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WorldCupDbContext>();
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["WorldCupDb"].ConnectionString);

            return new WorldCupDbContext(optionsBuilder.Options);
        }
    }
}
