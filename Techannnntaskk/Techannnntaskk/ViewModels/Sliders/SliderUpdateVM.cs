using System.ComponentModel.DataAnnotations;

namespace Techannnntaskk.ViewModels.Sliders
{
    public class SliderUpdateVM
    {
  public int Id { get; set; }
        [MinLength(5,ErrorMessage ="Bashliq 5den uzun olmalidir")] [MaxLength(50)]
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        [MinLength(5)]
        public string LittleTitle { get; set; }
        [MinLength(5)]
        public string BigTitle { get; set; }
        [MinLength(10)]
        public string Offer { get; set; }
        public string Link { get; set; }
    }
}
