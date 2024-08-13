using System.Collections.Generic;
using System.Linq;
using InventoryManagement.Data;
using InventoryManagement.Models;
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
    public class TransactionManager
    {
        private readonly InventoryContext _context;


        public TransactionManager(InventoryContext context)
        {
            _context = context;
        }

        public string AddStock(int productId, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
                return "Product not found.";

            product.Quantity += quantity;
            _context.Products.Update(product);

            var transaction = new Transaction
            {
                ProductID = productId,
                Quantity = quantity,
                Date = DateTime.Now,
                IsAddition = true
            };

            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return "Stock added successfully.";
        }

        public string RemoveStock(int productId, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
                return "Product not found.";

            if (product.Quantity < quantity)
                return "Insufficient stock.";

            product.Quantity -= quantity;
            _context.Products.Update(product);

            var transaction = new Transaction
            {
                ProductID = productId,
                Quantity = quantity,
                Date = DateTime.Now,
                IsAddition = false
            };

            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return "Stock removed successfully.";
        }

        public List<Transaction> GetAllTransactions()
        {
            return _context.Transactions.ToList();
        }
    }
}
