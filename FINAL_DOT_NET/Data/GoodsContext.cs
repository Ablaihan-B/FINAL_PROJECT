using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINAL_DOT_NET.Models.Goods;
using Microsoft.EntityFrameworkCore;


namespace FINAL_DOT_NET.Context
{
    public class GoodsContext : DbContext
    {
        public GoodsContext(DbContextOptions<GoodsContext> options): base(options)
        {
        }

        public DbSet<Good> Goods { get; set; }

    }
}
