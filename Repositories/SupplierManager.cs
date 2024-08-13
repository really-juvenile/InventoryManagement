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
            
                _context.Entry(supplier).State = EntityState.Modified;
                _context.SaveChanges();
            
        }

        public void DeleteSupplier(int supplierId)
        {
            
            
                var supplier = _context.Suppliers.Find(supplierId);
                if (supplier != null)
                {
                    _context.Suppliers.Remove(supplier);
                    _context.SaveChanges();
                }
            
        }

        public Supplier GetSupplierByID(int supplierId)
        {

            return _context.Suppliers.Find(supplierId);

        }

        public List<Supplier> GetAllSuppliers()
        {
         
                return _context.Suppliers.ToList();
            
        }
    }

}

