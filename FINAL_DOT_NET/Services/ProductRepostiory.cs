using FINAL_DOT_NET.Data;
using FINAL_DOT_NET.Models.Goods;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL_DOT_NET.Services
{
    public class ProductRepostiory : IProductRepostiory
    {

        private readonly ApplicationDbContext _appDbContext;

        public ProductRepostiory(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Good> AllGoods
        {
            get
            {
                return _appDbContext.Goods.Include(c => c.Category);
            }
        }


        public Good GetGoodById(string id)
        {
            return _appDbContext.Goods.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Good good)
        {
            _appDbContext.Goods.Update(good);
            _appDbContext.SaveChanges();
        }
    }
}
