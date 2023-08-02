using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPCTechnicalSummer2023OrderSystem.Models;

namespace HPCTechnicalSummer2023OrderSystem.Data;

public class StoreContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=HpcTechnicalStore;Integrated Security=True;");

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(new Customer
        {
            Id = 1,
            FirstName = "Eric",
            LastName = "Couch",
            Address = "201 Shaffner St.",
            Email = "eric.couch@cognizant.com",
            Phone = "(817) 304-9048"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 1,
            Name = "Pepperoni Pizza",
            Price = 8.99M
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 2,
            Name = "Deluxe Pizza",
            Price = 12.99M
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 3,
            Name = "Meat Lover's Pizza",
            Price = 10.99M
        });
        modelBuilder.Entity<Order>().HasData(new Order
        {
            Id = 1,
            OrderPlaced = new DateTime(2023, 8, 1, 10, 30, 00),
            OrderFulfilled = new DateTime(2023, 8, 1, 11, 00, 00),
            CustomerId = 1
        });
        modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail
        {
            Id = 1,
            Quantity = 1,
            ProductId = 3,
            OrderId = 1
        });
    }
}




