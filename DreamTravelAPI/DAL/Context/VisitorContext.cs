using DreamTravelAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DreamTravelAPI.DAL.Context
{
    public class VisitorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=KAYMAK\\SQLEXPRESS;initial catalog=DreamTravelAPIDB; integrated security=true;");
        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
