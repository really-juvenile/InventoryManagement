using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace InventoryManagement.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public double Price { get; set; }

        [ForeignKey("InventoryID")]
        public int? InventoryID { get; set; }
        public Inventory Inventory { get; set; }

        //inventoryid? foreign key
        //many product one inventory
        //inventory ctor mt,parametr


        //public string Type { get; set; }

        //public Product()
        //{

        //}
        ////empty constructor
        //public Product(string name,string desc, int qty,double price)
        //{
        //    Name = name;
        //    Description = desc;
        //    Quantity = qty;
        //    Price = price;
        //}

        public override string ToString()
        {
            return $"Product ID: {ProductID}\n" +
                $"Product NAme : {Name}\n" +
                $"Product description: {Description}\n" +
                $"Product Quantity: {Quantity}\n" +
                $"Product Price:  {Price}\n";
        }
    }
}
