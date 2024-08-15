using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Exceptions
{
    public class InventoryNotFoundException : Exception
    {
        public InventoryNotFoundException(int inventoryId)
           : base($"Inventory with ID {inventoryId} was not found.")
        {
        }
    }
}
