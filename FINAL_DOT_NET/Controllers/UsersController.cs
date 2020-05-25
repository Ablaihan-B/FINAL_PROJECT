using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FINAL_DOT_NET.Controllers
{
    public class UsersController : Controller
    {
        UserManager<IdentityUser> userManager;

        private IPasswordHasher<IdentityUser> passwordHasher;



        public UsersController(UserManager<IdentityUser> userManager, IPasswordHasher<IdentityUser> passwordHash)
        {
            this.userManager = userManager;
            passwordHasher = passwordHash;
        }

        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View(new IdentityUser());
        }

        public async Task<IActionResult> Update(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }



     

      


        [HttpPost]
        public async Task<IActionResult> Update(string id, string email, string password)
        {
            var user = await userManager.FindByIdAsync(id);
            
            if (user != null)
            {
                if (!string.IsNullOrEmpty(email))
                {
                    user.Email = email;
                    user.UserName = email;
                }
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                if (!string.IsNullOrEmpty(password))
                    user.PasswordHash = passwordHasher.HashPassword(user, password);
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                  
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View(user);
        }





        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            await userManager.DeleteAsync(user);

            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityUser user)
        {
            await userManager.CreateAsync(user);
            return RedirectToAction("Index");
        }

    }
}