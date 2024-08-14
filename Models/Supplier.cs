using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }

        //public Supplier()
        //{

        //}
        //public Supplier(string name, string contactinfo)
        //{

        //    Name = name;
        //    ContactInfo = contactinfo;
        //}
        [ForeignKey("InventoryID")]
        public int? InventoryID { get; set; }
        public Inventory Inventory { get; set; }
        public override string ToString()
        {
            return $"Supplier ID: {SupplierID}\n" +
                $"Supplier Name: {Name}\n" +
                $"Supplier Contact Info: {ContactInfo}\n";
        }
    }
}
