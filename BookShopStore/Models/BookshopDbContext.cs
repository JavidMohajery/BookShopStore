﻿using BookShopStore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopStore.Models
{
    public class BookshopDbContext : DbContext
    {
        public BookshopDbContext(DbContextOptions<BookshopDbContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BookMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new LanguageMap());
            modelBuilder.ApplyConfiguration(new Author_BookMap());
            modelBuilder.ApplyConfiguration(new DiscountMap());
            modelBuilder.ApplyConfiguration(new Order_BookMap());
            modelBuilder.ApplyConfiguration(new AuthorMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new ProvinceMap());
            modelBuilder.ApplyConfiguration(new CityMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderStatusMap());
            modelBuilder.ApplyConfiguration(new PublisherMap());
            modelBuilder.ApplyConfiguration(new TranslatorMap());
            modelBuilder.ApplyConfiguration(new Book_TranslatorMap());
            modelBuilder.ApplyConfiguration(new Book_CategoryMap());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Author_Book> Author_Books { get; set; }
        public DbSet<Order_Book> Order_Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Translator> Translators { get; set; }
        public DbSet<Book_Category> Book_Categories { get; set; }
    }
}
