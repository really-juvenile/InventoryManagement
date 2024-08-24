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
    public class SupplierManager
    {
        private readonly InventoryContext _context;

        public SupplierManager(InventoryContext context) //DI
        {
            _context = context;
        }


        public void AddSupplier(Supplier supplier)
        {
            
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
            
        }

        public void UpdateSupplier(Supplier supplier)
        {
            var existingSupplier = _context.Suppliers.Find(supplier.SupplierID);
            if (existingSupplier == null)
            {
                throw new SupplierNotFoundException(supplier.SupplierID);
            }
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }

        public void DeleteSupplier(int supplierId)
        {
            var supplierToDelete = _context.Suppliers.Find(supplierId);
            if (supplierToDelete == null)
            {
                throw new SupplierNotFoundException(supplierId);
            }
            _context.Suppliers.Remove(supplierToDelete);
            _context.SaveChanges();
        }

        public Supplier GetSupplierById(int supplierId)
        {
            var supplier = _context.Suppliers.Find(supplierId);
            if (supplier == null)
            {
                throw new SupplierNotFoundException(supplierId);
            }
            return supplier;
        }
        public Supplier GetSupplierByID(int supplierId)
        {
            var supplier = _context.Suppliers.Find(supplierId);
            if (supplier == null)
            {
                throw new SupplierNotFoundException(supplierId);
            }
            return supplier;
        }

        public List<Supplier> GetAllSuppliers()
        {
         
                return _context.Suppliers.ToList();
            
        }
    }

}

