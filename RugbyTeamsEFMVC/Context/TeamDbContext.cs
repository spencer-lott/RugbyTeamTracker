using Microsoft.EntityFrameworkCore;
using RugbyTeamsEFMVC.Models;

namespace RugbyTeamsEFMVC.Context
{
    public class TeamDbContext : DbContext
    {
        public TeamDbContext(DbContextOptions<TeamDbContext> options) : base(options) 
        { 
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

    }
}
