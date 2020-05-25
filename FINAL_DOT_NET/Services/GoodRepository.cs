using FINAL_DOT_NET.Context;
using FINAL_DOT_NET.Models.Goods;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FINAL_DOT_NET.Services
{
    public class GoodRepository : IGoodsRepository
    {

        readonly GoodsContext _context;



        public GoodRepository(GoodsContext context)
        {
            _context = context;
        }

        public void Add(Good good)
        {
            _context.Add(good);
        }



        public IEnumerable<Good> AllGoods
        {
            get
            {
                return _context.Goods.Include(c => c.Category);
            }
        }

        public void Update(Good good)
        {
            _context.Update(good);
        }

        public Good GetOne(string id)
        {
            return _context.Goods.FirstOrDefault(p => p.Id == id);
        }

        public Task<List<Good>> GetAll()
        {
            return _context.Goods.ToListAsync();
        }

        public Task<List<Good>> GetGoods(Expression<Func<Good, bool>> predicate)
        {
            return _context.Goods.Where(predicate).ToListAsync();
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

    }
}