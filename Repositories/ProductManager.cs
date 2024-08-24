using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Data;
using InventoryManagement.Exceptions;
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
            var existingProduct = _context.Products.Find(product.ProductID);
            if (existingProduct == null)
            {
                throw new ProductNotFoundException(product.ProductID);
            }
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public string DeleteProduct(int productId)
        {
            var productToDelete = _context.Products.Find(productId);
            if (productToDelete == null)
            {
                throw new ProductNotFoundException(productId);
            }
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
            return "Product deleted successfully";
        }

        public Product GetProductById(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                throw new ProductNotFoundException(productId);
            }
            return product;
        }


        public List<Product> GetAllProducts()
        {

            return _context.Products.ToList();

        }
    }
}

