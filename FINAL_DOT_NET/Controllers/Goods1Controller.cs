using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FINAL_DOT_NET.Context;
using FINAL_DOT_NET.Models.Goods;
using FINAL_DOT_NET.Data;
using FINAL_DOT_NET.Migrations.Categories;
using FINAL_DOT_NET.Services;
using FINAL_DOT_NET.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FINAL_DOT_NET.Controllers
{
    public class Goods1Controller : Controller
    {
        private readonly GoodsContext _context;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        /*
        /// <summary>
      
        public string ReturnUrl { get; set; }
        public async Task OnGetAsync(string returnUrl = null)
        {
            using (var context = new CategoriesContext())
            {
                ViewData["categories"] = await context.Categories.ToListAsync();
                ReturnUrl = returnUrl;
            }
        }
        /// </summary>
        */

        public Goods1Controller(GoodsContext context, ICategoryRepository categoryRepository, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _categoryRepository = categoryRepository;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Goods1
        public async Task<IActionResult> Index()
        {
      
            return View(await _context.Goods.ToListAsync());
        }

        // GET: Goods1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // GET: Goods1/Create
        public IActionResult Create()
        {

            ViewBag.Categories = _categoryRepository.AllCategories.Select(li => new SelectListItem
            { Text = li.Name, Value = li.Id.ToString() });

            return View();
        }

        // POST: Goods1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Image")] Good good)
        {


            //IFormFile imagemodel = good.Image;
            //HttpPostedFileBase postedFile;
            //string fileName = Path.GetFileNameWithoutExtension(imagemodel.FileName);
            
            //string filePath = "~/images/" + fileName;
           // good.Image.SaveAs(Server.MapPath(filePath));
           // string file = Path.Combine("~/images/", fileName);


            if (ModelState.IsValid)
            {
                /*
                string uniqueFileName = good.Image.FileName;
                Good good2 = new Good {
                    Id = good.Id,
                    Name = good.Name,
                    Description = good.Description,
                    Price = good.Price,
                    Image = uniqueFileName
                };*/
                
                _context.Add(good);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(good);
        }

        // GET: Goods1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods.FindAsync(id);
            if (good == null)
            {
                return NotFound();
            }
            return View(good);
        }

        // POST: Goods1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description,Price")] GoodsViewModel good)
        {
            if (id != good.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(good);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodExists(good.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(good);
        }

        // GET: Goods1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // POST: Goods1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var good = await _context.Goods.FindAsync(id);
            _context.Goods.Remove(good);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodExists(string id)
        {
            return _context.Goods.Any(e => e.Id == id);
        }

        private string UploadedFile(GoodsViewModel model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
