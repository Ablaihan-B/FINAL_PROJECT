using System;
using System.Collections.Generic;
using System.Text;
using FINAL_DOT_NET.Models.Cart;
using FINAL_DOT_NET.Models.Categories;
using FINAL_DOT_NET.Models.Goods;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FINAL_DOT_NET.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Cart> Carts { get; set; }
     
    }
}
