using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINAL_DOT_NET.Models.Comments;
using Microsoft.EntityFrameworkCore;

namespace FINAL_DOT_NET.Data
{
    public class CommentsContext : DbContext
    {

        public CommentsContext(DbContextOptions<CommentsContext> options) : base(options)
        {
        }

        public DbSet<Comment>  comments{ get; set; }

    }
}
