using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class MyBlogContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyBlogDB;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Burada bire çok ilişiki mevcut, HasOne=> Bir, WithMany=>Çok

            //Bir Gönderici, birçok gönderilen mesaja sahip olabilir, Gönderici Id'si ile birlikte.
            modelBuilder.Entity<Message2>()
                .HasOne(a => a.SenderUser)
                .WithMany(b => b.SentMessage)
                .HasForeignKey(c => c.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //Bir Alıcı, birçok alınan mesaja sahip olabilir, Alıcı Id'si ile birlikte.
            modelBuilder.Entity<Message2>()
                .HasOne(a => a.ReceiverUser)
                .WithMany(b => b.ReceivedMessage)
                .HasForeignKey(c => c.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ArticleRating> ArticleRatings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Message2> Message2s { get; set; }
    }
}
