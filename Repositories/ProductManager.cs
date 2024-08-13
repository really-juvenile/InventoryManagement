using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repositories
{
    public class ProductManager
    {
        private readonly InventoryContext _context;
        public ProductManager(InventoryContext context) //DI
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {

            _context.Products.Update(product);
            _context.SaveChanges();

        }

        public string DeleteProduct(int productId)
        {

            var productToDelete = _context.Products.Where(x => x.ProductID == productId).FirstOrDefault();
            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                _context.SaveChanges();
                return "Product deleted Successfully";
            }
            return "No such product exits";
        }



        public List<Product> GetAllProducts()
        {

            return _context.Products.ToList();

        }
    }
}

