using HPCTechnicalSummer2023OrderSystem.Data;
using HPCTechnicalSummer2023OrderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPCTechnicalSummer2023OrderSystem;

public class OrderService
{
    StoreContext _context = new StoreContext();

    public Customer? FindCustomer(Customer cust)
    {
        var foundCustomer = (from customer in _context.Customers
                             where customer.FirstName == cust.FirstName
                             where customer.LastName == cust.LastName
                             select customer).FirstOrDefault();
        return foundCustomer;
    }

    public Customer SaveCustomer(Customer cust)
    {
        _context.Customers.Add(cust);
        _context.SaveChanges();

        return cust;
    }

    public List<Order> GetOrders(Customer cust)
    {
        List<Order> orders = (from c in _context.Customers
                              join o in _context.Orders on c.Id equals o.CustomerId
                              where c.Id == cust.Id
                              select o).ToList();
        return orders;
    }
    public Product? GetProduct(int Id)
    {
        var product = (from p in _context.Products
                       where p.Id == Id
                       select p).FirstOrDefault();
        return product;
    }

    public void SaveOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void SaveOrderDetail(OrderDetail detail)
    {
        _context.OrderDetails.Add(detail);
        _context.SaveChanges();
    }
    public string ListOrder(List<Order> orders)
    {
        string ret = string.Empty;
        foreach (var order in orders)
        {
            List<OrderDetail> detail = (from o in _context.OrderDetails
                                        where o.OrderId == order.Id
                                        select o).ToList();
            foreach (OrderDetail od in detail)
            {
                ret += $"Order Placed: {order.OrderPlaced}\n";
                Product product = (from p in _context.Products
                                   where p.Id == od.ProductId
                                   select p).FirstOrDefault();
                if (product != null)
                {
                    ret += $"\tQty:\t{od.Quantity}\n\tProduct:\t{product.Name}\n\tPrice:\t{product.Price}\n";
                }
            }
        }
        return ret;
    }

    public static string MainMenu()
    {
        return "(L)ist Order History\n(P)lace Order\n(Q)uit\n";
    }

    public string OrderMenu()
    {
        string ret = string.Empty;
        var products = (from p in _context.Products
                        select p).ToList();
        ret += "Select item by number:\n";
        foreach (var p in products)
        {
            ret += $"({p.Id}) {p.Name} {p.Price}\n";
        }
        ret += "(Q)uit\n";
        return ret;
    }
}
