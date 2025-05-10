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
    public class SliderController (TechanDbContext _context) : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            List<Slider> datas = [];

            datas = await _context.Sliders.ToListAsync();
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

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue || id.Value < 1) return BadRequest();

            var entity = await _context.Sliders.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
                return NotFound();

             _context.Sliders.Remove(entity);
         
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult>Update(int? id)
        {
            if (id.HasValue && id < 1) return BadRequest();
            var entity = await _context.Sliders
                .Select(x=>new SliderUpdateVM
            {
Id=x.Id,
BigTitle=x.BigTitle,
Title=x.Title,
ImageUrl=x.ImageUrl,
Link=x.Link,
LittleTitle=x.LittleTitle,
Offer=x.Offer
            })
                .FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null)
                return NotFound();
            return View(entity);
            {
                
            }
        }
    }
 
}

