using FINAL_DOT_NET.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL_DOT_NET.Models.Goods
{
    public class Good
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

    }
}
