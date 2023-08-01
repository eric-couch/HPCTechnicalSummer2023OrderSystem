using HPCTechnicalSummer2023OrderSystem.Data;
using HPCTechnicalSummer2023OrderSystem.Models;

namespace HPCTechnicalSummer2023OrderSystem;

internal class Program
{
    static void Main(string[] args)
    {
        using StoreContext context = new StoreContext();

        var products = (context.Products
                        //.Where(p => p.Price > 10.00M)
                        .OrderBy(p => p.Name)).ToList();

        Console.WriteLine("Products list before Price update:");

        foreach ( var product in products )
        {
            Console.WriteLine($"Id:\t{product.Id}");
            Console.WriteLine($"Name:\t{product.Name}");
            Console.WriteLine($"Price:\t{product.Price}");
            Console.WriteLine(new String('-', 20));
        }

        var meatLovers = (from p in context.Products
                         where p.Name == "Meat Lovers Pizza"
                         select p).FirstOrDefault();

        if (meatLovers != null && meatLovers is Product ) {
            context.Products.Remove( meatLovers );
        }

        context.SaveChanges();

        var newProducts = (from p in context.Products select p).ToList();
        Console.WriteLine("Product list after removing meat lovers:");
        foreach (var product in newProducts)
        {
            Console.WriteLine($"Id:\t{product.Id}");
            Console.WriteLine($"Name:\t{product.Name}");
            Console.WriteLine($"Price:\t{product.Price}");
            Console.WriteLine(new String('-', 20));
        }

    }
}