using System.Collections.Generic;
using System.Linq;
using InventoryManagement.Data;
using InventoryManagement.Models;
using System;
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
            using (var context = new InventoryContext())
            {
                var product = context.Products.Find(productId);
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
                context.Transactions.Add(transaction);
                context.SaveChanges();
            }
        }

        public void RemoveStock(int productId, int quantity)
        {
            using (var context = new InventoryContext())
            {
                var product = context.Products.Find(productId);
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
                context.Transactions.Add(transaction);
                context.SaveChanges();
            }
        }

        public Transaction GetTransactionById(int transactionId)
        {
            using (var context = new InventoryContext())
            {
                var transaction = context.Transactions.Find(transactionId);
                if (transaction == null)
                {
                    throw new TransactionNotFoundException(transactionId);
                }
                return transaction;
            }
        }

        public List<Transaction> GetAllTransactions()
        {
            using (var context = new InventoryContext())
            {
                return context.Transactions.ToList();
            }
        }
    }
}
