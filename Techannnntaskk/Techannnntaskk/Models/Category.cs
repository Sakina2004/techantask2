using System.ComponentModel.DataAnnotations;

namespace Techannnntaskk.Models
{
    public class Category:BaseEntity
    {
        [MinLength(3), MaxLength(64)]
        public string Name { get; set; } = null!;
        public IEnumerable<Product>? Products  { get; set; }
    }
}
