using System;

namespace StoreManagement
{
    public class Admin
    {
        public void AddProduct(string pcode, string pname, int qtyInStock, bool discountAllowed, string brand, double price)
        {
            Product.AddProduct(pcode, pname, qtyInStock, discountAllowed, brand, price);
        }

        public void DisplayProducts()
        {
            Product.DisplayProducts();
        }

        public void UpdateProductPrice(string pname, double newPrice)
        {
            Product product = Product.GetProductDetails(pname);
            if (product != null)
            {
                product.UpdatePrice(newPrice);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }
}
