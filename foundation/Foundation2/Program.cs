using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Address address1 = new Address("123 Church St", "Salt Lake City", "UT", "USA");
        Address address2 = new Address("456 Faith Rd", "Toronto", "ON", "Canada");

        Customer customer1 = new Customer("Alice Johnson", address1);
        Customer customer2 = new Customer("John Smith", address2);

        Product product1 = new Product("Book of Mormon", "B001", 19.99, 1);
        Product product2 = new Product("Relief Society Manual", "RSM002", 15.50, 2);
        Product product3 = new Product("Charms Bracelet", "C003", 29.99, 1);
        Product product4 = new Product("Gospel Study Journal", "GSJ004", 12.00, 3);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        DisplayOrderDetails(order1);
        Console.WriteLine();
        DisplayOrderDetails(order2);
        Console.WriteLine();
    }

    private static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():F2}\n");

        Console.WriteLine("Details of the products:");
        foreach (var product in order.GetProducts())
        {
            Console.WriteLine($"{product.GetName()} - Quantity: {product.GetQuantity()} - Price per unit: ${product.GetPrice():F2} - Total: ${product.GetTotalCost():F2}");
        }
    }
}
