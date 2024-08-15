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
using InventoryManagement.Exceptions;

namespace InventoryManagement.Repositories
{
    public class TransactionManager
    {
        private readonly InventoryContext _context;


        public TransactionManager(InventoryContext context)
        {
            _context = context;
        }

        public void AddStock(int productId, int quantity)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                throw new ProductNotFoundException(productId);
            }
            product.Quantity += quantity;

            var transaction = new Transaction
            {
                ProductID = productId,
                Quantity = quantity,
                Date = DateTime.Now,
                IsAddition = true
            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public void RemoveStock(int productId, int quantity)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                throw new ProductNotFoundException(productId);
            }
            product.Quantity -= quantity;

            var transaction = new Transaction
            {
                ProductID = productId,
                Quantity = quantity,
                Date = DateTime.Now,
                IsAddition = false
            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        //public Transaction GetTransactionById(int transactionId)
        //{
        //    var transaction = _context.Transactions.Find(transactionId);
        //    if (transaction == null)
        //    {
        //        throw new TransactionNotFoundException(transactionId);
        //    }
        //    return transaction;
        //}

        public List<Transaction> GetAllTransactions()
        {
            return _context.Transactions.ToList();
        }
    }
}
