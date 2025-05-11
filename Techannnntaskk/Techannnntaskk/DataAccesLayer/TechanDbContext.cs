using Microsoft.EntityFrameworkCore;
using Techannnntaskk.Models;

namespace Techannnntaskk.DataAccesLayer;

public class TechanDbContext : DbContext
{
    public TechanDbContext(DbContextOptions option):base(option)
    {
        
    }
   
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Category> Categories { get; set; }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server=.\\SQlEXPRESS;Database = Techan;Truted_Connection = true;TrustServerCertificate=true");
    //    base.OnConfiguring(optionsBuilder);
    // }
}   
    


 



  

