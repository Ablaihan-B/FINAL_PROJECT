using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINAL_DOT_NET.Context;
using FINAL_DOT_NET.Models.Categories;
using FINAL_DOT_NET.Models.Goods;
using FINAL_DOT_NET.Services;
using Microsoft.AspNetCore.Mvc;

namespace FINAL_DOT_NET.Controllers
{
    public class GoodsController : Controller
    {
        private readonly GoodsService _goodService;
        public async Task<IActionResult> Index()
        {
            var goods = await _goodService.GetGoods();
            return View(goods);
        }

        GoodsContext db;
      /*  public GoodsController(GoodsContext context)
        {
            db = context;
            Category category = new Category {Id = "sm1",Name = "Smartphone"};
            
            if (!db.Goods.Any())
            {
                db.Goods.Add(new Good { Name = "iPhone X", Category = category,Description = "16 mpx" , Price = 79900 });
                db.SaveChanges();
            }
        }
        */

        static Category category = new Category { Id = "sm1", Name = "Smartphone" };
        
        static List<Good> goods = new List<Good>
        {
        new Good { Name = "iPhone X", Category = category,Description = "16 mpx" , Price = 79900}
        };

        public GoodsController(GoodsService goodService)
        {
            _goodService = goodService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Good good)
        {

            await _goodService.AddAndSave(good);

            var goods = await _goodService.GetGoods();

            return View("Index", goods);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

    


        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Good good)
        {

            await _goodService.Save(good);

            var goods = await _goodService.GetGoods();

            return View("Index", goods);
        }


        public async Task<IActionResult> Search(string text)
        {
            var searchedGoods = await _goodService.Search(text);
            return View("Index", searchedGoods);
        }

    

        /*
        [HttpGet]
        public IEnumerable<Good> Get()
        {
            return db.Goods.ToList();
        }

        [HttpGet("{id}")]
        public Good Get(string id)
        {
            Good good = db.Goods.FirstOrDefault(x => x.Id == id);
            return good;
        }

        [HttpPost]
        public IActionResult Post(Good good)
        {
            if (ModelState.IsValid)
            {
                db.Goods.Add(good);
                db.SaveChanges();
                return Ok(good);
            }
            return BadRequest(ModelState);
        }



        [HttpPut]
        public IActionResult Put(Good good)
        {
            if (ModelState.IsValid)
            {
                db.Update(good);
                db.SaveChanges();
                return Ok(good);
            }
            return BadRequest(ModelState);
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Good good = db.Goods.FirstOrDefault(x => x.Id == id);
            if (good != null)
            {
                db.Goods.Remove(good);
                db.SaveChanges();
            }
            return Ok(good);
        }
        */
    }
}