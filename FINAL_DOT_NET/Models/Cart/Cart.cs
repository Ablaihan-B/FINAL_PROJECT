using FINAL_DOT_NET.Models.Goods;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace FINAL_DOT_NET.Models.Cart
{
    public class Cart
    {
       
        public string Id { get; set; }
        public Good Good { get; set; }
        public IdentityUser User { get; set; }
    }
}
