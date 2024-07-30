using System;

namespace StoreManagement
{
    public class Program
    {
        public static void Main()
        {
            // Initialize some products
            Product.AddProduct("P001", "Laptop", 10, true, "TechBrand", 100000.00);
            Product.AddProduct("P002", "Smartphone", 20, true, "TechBrand", 20000.00);
            Product.AddProduct("P003", "Headphones", 50, false, "AudioBrand", 2000.00);

            // Create instances of Admin and Customer
            Admin admin = new Admin();
            Customer customer = new Customer();

            // User role selection
            Console.WriteLine("Are you an Admin or Customer?");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Customer");
            Console.Write("Select your role (1/2): ");
            string roleSelection = Console.ReadLine();

            switch (roleSelection)
            {
                case "1":
                    // Admin options
                    Console.WriteLine("\nAdmin Mode:");
                    while (true)
                    {
                        Console.WriteLine("1. Add Product");
                        Console.WriteLine("2. Display Products");
                        Console.WriteLine("3. Update Product Price");
                        Console.WriteLine("4. Exit Admin Mode");
                        Console.Write("Select an option: ");
                        string adminOption = Console.ReadLine();

                        switch (adminOption)
                        {
                            case "1":
                                Console.Write("Enter product code: ");
                                string pcode = Console.ReadLine();
                                Console.Write("Enter product name: ");
                                string pname = Console.ReadLine();
                                Console.Write("Enter quantity in stock: ");
                                int qtyInStock = int.Parse(Console.ReadLine());
                                Console.Write("Allow discount (true/false): ");
                                bool discountAllowed = bool.Parse(Console.ReadLine());
                                Console.Write("Enter brand: ");
                                string brand = Console.ReadLine();
                                Console.Write("Enter price: ");
                                double price = double.Parse(Console.ReadLine());

                                admin.AddProduct(pcode, pname, qtyInStock, discountAllowed, brand, price);
                                break;

                            case "2":
                                admin.DisplayProducts();
                                break;

                            case "3":
                                Console.Write("Enter product name to update price: ");
                                string pnameToUpdate = Console.ReadLine();
                                Console.Write("Enter new price: ");
                                double newPrice = double.Parse(Console.ReadLine());

                                admin.UpdateProductPrice(pnameToUpdate, newPrice);
                                break;

                            case "4":
                                return; // Exit Admin Mode

                            default:
                                Console.WriteLine("Invalid option. Try again.");
                                break;
                        }
                    }

                case "2":
                    // Customer options
                    Console.WriteLine("\nCustomer Mode:");
                    while (true)
                    {
                        Console.WriteLine("1. Order Product");
                        Console.WriteLine("2. Exit Customer Mode");
                        Console.Write("Select an option: ");
                        string customerOption = Console.ReadLine();

                        switch (customerOption)
                        {
                            case "1":
                                customer.OrderProduct();
                                break;

                            case "2":
                                return; // Exit Customer Mode

                            default:
                                Console.WriteLine("Invalid option. Try again.");
                                break;
                        }
                    }

                default:
                    Console.WriteLine("Invalid selection. Please restart the program and select a valid role.");
                    break;
            }
        }
    }
}
