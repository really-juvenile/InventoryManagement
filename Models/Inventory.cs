using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Inventory
    {
 
            [Key]
            public int InventoryID { get; set; }
            public string Location { get; set; }

            // Navigation properties
            public List <Product> Products { get; set; }
            public List <Supplier> Suppliers { get; set; }
            public List <Transaction> Transactions { get; set; }
        }
    }



