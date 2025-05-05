using Microsoft.EntityFrameworkCore;
using Techannnntaskk.Models;

namespace Techannnntaskk.DataAccesLayer;

public class TechanDbContext:DbContext 
{
    public DbSet<Slider> Sliders { get; set; } 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;;Database=Techan;Trusted_Connection=true;TrustServerCertificate=true");
        base.OnConfiguring(optionsBuilder);
    }
}
