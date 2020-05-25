using FINAL_DOT_NET.Models.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL_DOT_NET.Data
{
    public class CategoriesContext : DbContext
    {
    

        public CategoriesContext(DbContextOptions<CategoriesContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

    }
}
