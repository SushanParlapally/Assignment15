using System;
using System.Collections.Generic;

namespace StoreManagement
{
    public class Product
    {
        private static Dictionary<string, Product> allProducts = new Dictionary<string, Product>();

        public string Pcode { get; private set; }
        public string Pname { get; set; }
        public int QtyInStock { get; set; }
        public bool DiscountAllowed { get; set; }
        public string Brand { get; set; }
        public double Price { get; private set; } // Price property in rupees

        public Product(string pcode, string pname, int qtyInStock, bool discountAllowed, string brand, double price)
        {
            Pcode = pcode;
            Pname = pname;
            QtyInStock = qtyInStock;
            DiscountAllowed = discountAllowed;
            Brand = brand;
            Price = price; // Initialize price
        }

        public static void AddProduct(string pcode, string pname, int qtyInStock, bool discountAllowed, string brand, double price)
        {
            if (allProducts.ContainsKey(pcode))
            {
                Console.WriteLine($"Product with pcode {pcode} already exists.");
            }
            else
            {
                allProducts[pcode] = new Product(pcode, pname, qtyInStock, discountAllowed, brand, price);
                Console.WriteLine("Product added successfully.");
            }
        }

        public static void DisplayProducts()
        {
            foreach (var product in allProducts.Values)
            {
                Console.WriteLine($"Product Code: {product.Pcode}, Name: {product.Pname}, Quantity: {product.QtyInStock}, Price: ₹{product.Price:F2}, Discount Allowed: {product.DiscountAllowed}, Brand: {product.Brand}");
            }
        }

        public static Product GetProductDetails(string pname)
        {
            foreach (var product in allProducts.Values)
            {
                if (product.Pname.Equals(pname, StringComparison.OrdinalIgnoreCase))
                {
                    return product;
                }
            }
            return null;
        }

        public void UpdatePrice(double newPrice)
        {
            Price = newPrice;
            Console.WriteLine($"Price for product {Pname} updated to ₹{Price:F2}");
        }

        public double CalculateTotalAmount(int qtyRequested)
        {
            if (qtyRequested > QtyInStock)
            {
                Console.WriteLine("Requested quantity exceeds stock available.");
                return 0;
            }

            double totalAmount = Price * qtyRequested;
            double discount = 20;  // 20% discount
            double discountedAmount = totalAmount * (1 - discount / 100);

            return discountedAmount;
        }
    }
}
