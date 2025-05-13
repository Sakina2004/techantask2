using System.ComponentModel.DataAnnotations;

namespace Techannnntaskk.ViewModels.Brands
{
	public class BrandCreateVM
	{
		[MinLength(3)] 
        public string  Name { get; set; }
		public IFormFile ImageFile { get; set; }
    }
}
