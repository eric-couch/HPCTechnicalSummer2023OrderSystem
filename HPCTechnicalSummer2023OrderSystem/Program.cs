using HPCTechnicalSummer2023OrderSystem.Data;
using HPCTechnicalSummer2023OrderSystem.Models;

namespace HPCTechnicalSummer2023OrderSystem;

internal class Program
{
    static void Main(string[] args)
    {
        Customer thisCustomer = new Customer();
        OrderService thisOrder = new OrderService();
        
        Console.Write("Enter First Name: ");
        thisCustomer.FirstName = Console.ReadLine() ?? "";
        Console.Write("Enter Last Name: ");
        thisCustomer.LastName = Console.ReadLine() ?? "";

        var findCustomer = thisOrder.FindCustomer(thisCustomer);

        if (findCustomer == null) 
        {
            Console.WriteLine("Customer not found.");
            Console.Write("Enter your address: ");
            thisCustomer.Address = Console.ReadLine() ?? "";
            Console.Write("Enter your phone: ");
            thisCustomer.Phone = Console.ReadLine() ?? "";
            Console.Write("Enter your email: ");
            thisCustomer.Email = Console.ReadLine() ?? "";
            thisCustomer = thisOrder.SaveCustomer(thisCustomer);
        } else
        {
            thisCustomer = findCustomer;
            Console.WriteLine("Customer found");
            Console.WriteLine(thisCustomer.ToString());
        }

        bool quitOrder = false;

        do
        {
            Console.WriteLine(OrderService.MainMenu());
            string userReponse = Console.ReadLine() ?? "";

            if (userReponse.ToLower() == "l")
            {
                Console.Clear();
                List<Order> orders = thisOrder.GetOrders(thisCustomer);
                if (orders is null)
                {
                    Console.WriteLine("No orders found.");
                } else
                {
                    Console.WriteLine(thisOrder.ListOrder(orders));
                }
            }else if (userReponse.ToLower() == "p")
            {
                Console.Clear();
                Order newOrder = new Order()
                {
                    Customer = thisCustomer,
                    OrderPlaced = DateTime.Now
                };
                OrderDetail od = new OrderDetail()
                {
                    Order = newOrder
                };
                bool doneWithProducts = false;
                do
                {
                    Console.WriteLine(thisOrder.OrderMenu());
                    string orderItem = Console.ReadLine() ?? "q";
                    if (orderItem.ToLower() == "q")
                    {
                        doneWithProducts = true;
                    } else if (Int32.TryParse(orderItem, out int productNumber))
                    {
                        var product = thisOrder.GetProduct(productNumber);
                        if (product is not null)
                        {
                            od.Products = product;
                            od.Quantity = 1;
                            thisOrder.SaveOrder(newOrder);
                            thisOrder.SaveOrderDetail(od);
                            doneWithProducts=true;
                        }
                    } else
                    {
                        Console.WriteLine("Invalid entry.  Try again.");
                    }
                } while (!doneWithProducts);
            } else
            {
                quitOrder = true;
            }


        } while (!quitOrder);
    }
}