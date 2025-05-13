using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techannnntaskk.DataAccesLayer;
using Techannnntaskk.ViewModels.Brands;

namespace Techannnntaskk.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController(TechanDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var datas = await _context.Brands.Select(x => new BrandGetVM
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Name = x.Name
            }).ToListAsync();
            return View(datas);
        }
     
        public async Task<IActionResult>Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(BrandCreateVM vm)
        {
            if(vm.ImageFile.Length/1024>200)
            {
                ModelState.AddModelError()
            }
            if (!ModelState.IsValid)
                return View(vm);
            return View();
        }
    }
}
