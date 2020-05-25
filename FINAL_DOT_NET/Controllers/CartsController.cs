
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FINAL_DOT_NET.Data;
using FINAL_DOT_NET.Models.Cart;
using Microsoft.AspNetCore.Identity;
using FINAL_DOT_NET.Context;
using FINAL_DOT_NET.Models.Goods;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace FINAL_DOT_NET.Controllers
{
    public class CartsController : Controller
    {
        private readonly CartContext _context;
        private readonly ApplicationDbContext _Goodcontext;
        private readonly GoodsContext _context7;

        UserManager<IdentityUser> userManager;

        public CartsController(CartContext context, ApplicationDbContext Goodcontext, UserManager<IdentityUser> userManager)
        {
            _Goodcontext = Goodcontext;
            _context = context;
            this.userManager = userManager;

        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

           /* var c = _Goodcontext.Carts.Find();
            var b = _Goodcontext.Carts.ToListAsync();

            var gg = _context7.Goods.ToListAsync().Result;
            List<Cart> cartT = new List<Cart>();*/

            List<Good> cartProducts = new List<Good>();

            var cart = _Goodcontext.Carts.Where(c => c.User.Id == user.Id).ToListAsync();
          //  var cart7 = _Goodcontext.Goods.Where(c => c.Id == cart.Good.Id).ToListAsync();
            foreach (var i in cart.Result)
            {
              var cart7 = _Goodcontext.Goods.Where(c => c.Id == i.Good.Id).ToListAsync();
                //cartProducts.Add(_Goodcontext.Goods.FirstOrDefault(c => c.Id == i.Good.Id));
                cartProducts.Add(i.Good);
            }
            //cartProducts = cart7;
            /*
            while(cart!=null) {
                cartProducts.Add(cart.FirstOrDefault);
               
            }*/


            //return View(await _Goodcontext.Carts.ToListAsync());
            return View(cartProducts);
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Carts/Create
        /*
        public IActionResult Create()
        {

            //var good = await _Goodcontext.Goods.FirstOrDefaultAsync(m => m.Id == id);
            // Good good = _Goodcontext.Goods.FirstOrDefault(p => p.Id == GoodId);
            //Good good = _Goodcontext.Goods.Where(u => u.Id.Equals(id));

            return View();
        }
        */


/*
        public async Task<IActionResult> AddToShoppingCart(string id)
        {        
            Cart cart = new Cart();
           // var good = _goodsRepository.AllGoods.FirstOrDefault(p => p.Id == id);
            //var good = _context2.Goods.FirstOrDefault(m => m.Id == id);
                //good.Id = id + "CART";
             
            if (good != null)
                {
                    cart.Id = good.Id + "CART";
                    cart.Good = good;
                    _context.Add(cart);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(cart);
        }*/

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    
        public async Task<IActionResult> Create(string GoodId)
        {
           // var gd = _Goodcontext.Goods.Where(u => u.Good.Id.Equals(GoodId));
            Good good = _Goodcontext.Goods.Find(GoodId);


            Console.WriteLine(good);
            Cart cart = new Cart();
            //var user =  userManager.GetUserAsync(User).Result;
            var varUser = _Goodcontext.Users.Where(u => u.Email.Equals(User.Identity.Name));
            //var user = varUser.FirstOrDefault();
            var user = await userManager.GetUserAsync(User);
            //var user = User.Identity.;
            // var good = _goodsRepository.AllGoods.FirstOrDefault(p => p.Id == id);
            if (ModelState.IsValid)
            {
                //    cart.Good = good;
                cart.Id = user.Id + "CART";
                cart.Good = good;
                cart.User = user;
                _Goodcontext.Add(cart);
                await _Goodcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", cart);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id")] Cart cart)
        {
            if (id != cart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.Id))
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
            return View(cart);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cart = await _context.Carts.FindAsync(id);
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(string id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
    }
}
