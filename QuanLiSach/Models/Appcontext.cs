using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiSach.Models
{
    public class Appcontext : DbContext
    {
        public Appcontext(DbContextOptions<Appcontext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<CategoryBook> CategoryBooks { set; get; }
        public DbSet<Book> Books { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryBook>().HasData(new CategoryBook { Id = 1, Category = "Sách Giáo Trình" });
            modelBuilder.Entity<CategoryBook>().HasData(new CategoryBook { Id = 2, Category = "Sách Tiểu Thuyết" });
            modelBuilder.Entity<CategoryBook>().HasData(new CategoryBook { Id = 3, Category = "Sách Tâm Lý" });
            modelBuilder.Entity<Book>().HasData(new Book

            {
                Id = 1,
                Namebook = "Đắc Nhân Tâm",
                Author="Dale CarNeGie",
                Publishingyear=2016,
                Count=1,
                CategorybookId=1
            });
            modelBuilder.Entity<Book>().HasData(new Book

            {
                Id = 2,
                Namebook = "Đọc Vị Bất Kì Ai",
                Author = "David j.Lieberman",
                Publishingyear = 2015,
                Count = 2,
                CategorybookId = 2
            });
            modelBuilder.Entity<Book>().HasData(new Book

            {
                Id = 3,
                Namebook = "Đời Ngắn Đừng Ngủ Dài",
                Author = "Robin Sharma",
                Publishingyear = 2017,
                Count = 1,
                CategorybookId = 3
            });
        }

    }
    }
