using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public bool IsAddition { get; set; }

        [ForeignKey("InventoryID")]
        public int? InventoryID { get; set; }

       
        public Inventory Inventory { get; set; }

        // Navigation property for product
        public Product Product { get; set; }
        public override string ToString()
        {
            string type;
            if (IsAddition)
            {
                type = "Added";
            }
            else
            {
                type = "Removed";
            }

            return $"Transaction ID: {TransactionID}\n" +
                  $"Product ID: {ProductID}\n" +
                  $"Quantity: {Quantity}\n" +
                  $"Date: {Date}\n" +
                  $"Type: {type}\n" +
                  $"==============================================";
        }

    }
}
