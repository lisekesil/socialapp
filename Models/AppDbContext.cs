using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialapp.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

    }
}
