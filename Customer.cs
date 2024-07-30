using System;

namespace StoreManagement
{
    public class Customer
    {
        public void OrderProduct()
        {
            Console.Write("Enter product name to order: ");
            string pname = Console.ReadLine();

            Product product = Product.GetProductDetails(pname);
            if (product != null)
            {
                Console.Write("Enter quantity for {0}: ", pname);
                int qtyRequested = int.Parse(Console.ReadLine());

                double totalAmount = product.CalculateTotalAmount(qtyRequested);
                if (totalAmount > 0)
                {
                    Console.WriteLine("Total amount to be paid (after discount): ₹{0:F2}", totalAmount);
                    Console.WriteLine("Generating bill...");
                    Console.WriteLine("Product Code: {0}", product.Pcode);
                    Console.WriteLine("Product Name: {0}", product.Pname);
                    Console.WriteLine("Quantity Ordered: {0}", qtyRequested);
                    Console.WriteLine("Total Amount (after discount): ₹{0:F2}", totalAmount);
                }
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }
}
