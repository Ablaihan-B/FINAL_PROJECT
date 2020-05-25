using FINAL_DOT_NET.Models.Goods;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL_DOT_NET.Models.Comments
{
    public class Comment
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public Good Good { get; set; }
        public IdentityUser Author { get; set; }
    }
}
