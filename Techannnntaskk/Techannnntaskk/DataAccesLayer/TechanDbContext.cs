using Microsoft.EntityFrameworkCore;
using Techannnntaskk.Models;

namespace Techannnntaskk.DataAccesLayer;

public class TechanDbContext:DbContext 
{
    public TechanDbContext(DbContextOptions options) : base(options)
    {
    }


    public DbSet<Slider> Sliders { get; set; } 
  
}
