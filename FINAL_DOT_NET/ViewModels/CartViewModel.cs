using FINAL_DOT_NET.Migrations.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL_DOT_NET.ViewModels
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
