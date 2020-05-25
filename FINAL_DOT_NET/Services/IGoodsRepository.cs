using FINAL_DOT_NET.Models.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FINAL_DOT_NET.Services
{
    public interface IGoodsRepository
    {
        IEnumerable<Good> AllGoods { get; }

        Good GetOne(string id);
        void Add(Good good);

        void Update(Good good);
        Task Save();

        Task<List<Good>> GetAll();

        Task<List<Good>> GetGoods(Expression<Func<Good, bool>> predicate);
    }
}
