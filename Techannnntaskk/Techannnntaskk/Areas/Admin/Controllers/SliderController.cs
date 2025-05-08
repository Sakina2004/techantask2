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
    public class SliderController (TechanDbContext context) : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            List<Slider> datas = [];

            datas = await context.Sliders.ToListAsync();
            List<SliderGetVM> sliders = [];
            foreach (var item in datas)
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
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(SliderCreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            Slider slider = new();
            slider.LittleTitle = model.LittleTitle;
            slider.Title = model.Title;
            slider.BigTitle = model.BigTitle;
            slider.Offer = model.Offer;
            slider.ImageUrl = model.ImageUrl;
            slider.Link = model.Link;
          
                await context.Sliders.AddAsync(slider);
                await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue || id.Value < 1) return BadRequest();

            var entity = await context.Sliders.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
                return NotFound();

             context.Sliders.Remove(entity);

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
