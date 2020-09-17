using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string File { get; set; }

        public byte[] Image { get; set; }
        public int LanguageId { get; set; }
        public int PublisherId { get; set; }
        public int TranslatorId { get; set; }
        public int NumOfPages { get; set; }
        public short Weight { get; set; }
        public string ISBN { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishDate { get; set; }
        public int PublishYear { get; set; }
        public bool? Delete { get; set; }

        public Language Language { get; set; }

        public Discount Discount { get; set; }

        public Publisher Publisher { get; set; }
        public List<Order_Book> Orders { get; set; }

        public List<Author_Book> Author_Books { get; set; }
        public List<Book_Translator> Book_Translators { get; set; }
        public List<Book_Category> Book_Categories { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> SubCategories { get; set; }
        public List<Book_Category> Book_Categories { get; set; }
    }
    public class Book_Category
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }

        public Book Book { get; set; }
        public Category Category { get; set; }
    }
    public class Language
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public List<Book> Books { get; set; }
    }
    public class Discount
    {
        public int BookId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte Percent { get; set; }

        public Book Book { get; set; }
    }
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Author_Book> Author_Books { get; set; }
    }
    public class Author_Book
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }

    public class Customer
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Mobile { get; set; }
        public string Tel { get; set; }
        public string Image { get; set; }

        public int CityId1 { get; set; }
        public int CityId2 { get; set; }
        public City City1 { get; set; }
        public City City2 { get; set; }
        public List<Order> Orders { get; set; }
        public int Age { get; set; }
    }
    public class Province
    {
        public int Id { get; set; }
        public string ProvinceName { get; set; }
        public List<City> Cities { get; set; }
    }
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
        public List<Customer> Customers1 { get; set; }
        public List<Customer> Customers2 { get; set; }
    }
    public class Order
    {
        public string Id { get; set; }
        public long AmountPaid { get; set; }
        public string DispatchNumber { get; set; }
        public DateTime BuyDate { get; set; }

        public int OrderStatusId { get; set; }
        public string CustomerId { get; set; }
        public OrderStatus OrderStatus{ get; set; }
        public Customer Customer { get; set; }

        public List<Order_Book> Books { get; set; }
    }
    public class OrderStatus
    {
        public int Id { get; set; }
        public string OrderStatusName { get; set; }
        public List<Order> Orders { get; set; }
    }

    public class Order_Book
    {
        public int BookId { get; set; }
        public string OrderId { get; set; }

        public Book Book { get; set; }
        public Order Order { get; set; }
    }
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
    public class Translator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public List<Book_Translator> Book_Translators { get; set; }
    }
    public class Book_Translator
    {
        public int BookId { get; set; }
        public int TranslatorId { get; set; }
        public Book Book { get; set; }
        public Translator Translator { get; set; }
    }
}
