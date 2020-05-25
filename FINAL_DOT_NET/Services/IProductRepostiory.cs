using FINAL_DOT_NET.Models.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL_DOT_NET.Services
{
    public interface IProductRepostiory
    {
        IEnumerable<Good> AllGoods { get; }
        Good GetGoodById(string Id);
        void Update(Good p);
    }
}
