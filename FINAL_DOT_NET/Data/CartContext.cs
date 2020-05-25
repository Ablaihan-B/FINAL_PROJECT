using FINAL_DOT_NET.Data.Migrations;
using FINAL_DOT_NET.Models.Cart;
using FINAL_DOT_NET.Models.Categories;
using FINAL_DOT_NET.Models.Goods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL_DOT_NET.Data
{
    public class CartContext : DbContext
    {

        public CartContext(DbContextOptions<CartContext> options) : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; }
        
    }
}
