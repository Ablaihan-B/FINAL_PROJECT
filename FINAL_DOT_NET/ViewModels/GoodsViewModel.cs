using FINAL_DOT_NET.Models.Categories;
using FINAL_DOT_NET.Models.Goods;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL_DOT_NET.ViewModels
{
    public class GoodsViewModel
    {
        /*
        public IEnumerable<Good> goods { get; set; }
        public string CurrentCategory { get; set; }
        */


        public string Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile Image { get; set; }
    }
}
