using Elfie.Serialization;
using Techannnntaskk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Techannnntaskk.DataAccesLayer;
using Techannnntaskk.ViewModels.Sliders;

namespace Techannnntaskk.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller  
    {
        public async Task< IActionResult> Index()
        {
            List<Slider> datas = [];
            using (var context = new TechanDbContext())
            {
                 datas= await context.Sliders.ToListAsync();
            }
            List<SliderGetVM> sliders = [];
            foreach(var item in datas)
            {
                sliders.Add(new SliderGetVM()
                {
                    BigTitle = item.BigTitle,
                    Id = item.Id,
                    ImageUrl = item.ImageUrl,
                    Link = item.Link,
                    LittleTitle = item.LittleTitle,
                    Offer = item.Offer,
                    Title = item.Title,
                });
               

            }
          return View(sliders);
        }
        
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(SliderCreateVM model)
        {
            return Ok
        }
    }
}
