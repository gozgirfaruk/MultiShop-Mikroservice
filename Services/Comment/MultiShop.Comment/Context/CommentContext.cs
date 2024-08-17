using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1434; Initial Catalog=MultiShopCommentDb; User=sa; Password=Saat1212.*");
        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}
