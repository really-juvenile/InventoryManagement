using InventoryManagement.Data;
using InventoryManagement.Models;
using InventoryManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        //        static void Main(string[] args)
        //        {
        //            //// SupplierManager supplierManager = new SupplierManager(new InventorContext());
        //            //ProductManager productManager = new ProductManager(new InventoryContext());
        //            //SupplierManager supplierManager = new SupplierManager(new InventoryContext());
        //            ////ProductManager productManager1 = new ProductManager();
        //            ////SupplierManager supplierManager1  = new SupplierManager(context);



        //            //Product newProduct = new Product
        //            //{
        //            //    Name = "Laptop",
        //            //    Description = "A high-performance laptop",
        //            //    Quantity = 10,
        //            //    Price = 1500
        //            //};
        //            //productManager.AddProduct(newProduct);
        //            //Console.WriteLine("New product added Successfully");

        //// Read all products
        ////List<Product> products = productManager.GetAllProducts();
        ////    foreach (var product in products)
        ////    {
        ////        Console.WriteLine($"{product.ProductID} - {product.Name}");
        ////    }

        //var products = productManager.GetAllProducts();
        //products.ForEach(p => Console.WriteLine(p));

        ////Console.WriteLine(productManager.DeleteProduct(1));





        ////Supplier newSupplier = new Supplier
        ////{
        ////    Name = "Tech Supplies",
        ////    ContactInfo = "techsupplies@example.com"
        ////};
        ////supplierManager.AddSupplier(newSupplier);


        static void MainMenu()
        {
            InventoryContext context = new InventoryContext();
            ProductManager productManager = new ProductManager(new InventoryContext());
            SupplierManager supplierManager = new SupplierManager(new InventoryContext());
            TransactionManager transactionManager = new TransactionManager(new InventoryContext());




            Product newProduct = new Product
            {
                Name = "Laptop",
                Description = "A high-performance laptop",
                Quantity = 10,
                Price = 1500
            };
            productManager.AddProduct(newProduct);
            Console.WriteLine("New product added Successfully");

            while (true)
            {
                Console.WriteLine("Welcome to the Inventory Management System");
                Console.WriteLine("1. Product Management");
                Console.WriteLine("2. Supplier Management");
                Console.WriteLine("3. Transaction Management");
                Console.WriteLine("4. Generate Report");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ProductManagementMenu(productManager);
                        break;
                    case 2:
                        SupplierManagementMenu(supplierManager);
                        break;
                    case 3:
                        TransactionManagementMenu(transactionManager);
                        break;
                    case 4:
                        GenerateReportMenu(productManager, supplierManager, transactionManager);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void ProductManagementMenu(ProductManager productManager)
        {
            while (true)
            {
                Console.WriteLine("\nProduct Management");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. View Product's Details");
                Console.WriteLine("5. View All Products");
                Console.WriteLine("6. Go Back to Main Menu");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddProduct(productManager);
                        break;
                    case 2:
                        UpdateProduct(productManager);
                        break;
                    case 3:
                        DeleteProduct(productManager);
                        break;
                    case 4:
                        ViewProductDetails(productManager);
                        break;
                    case 5:
                        ViewAllProducts(productManager);
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void SupplierManagementMenu(SupplierManager supplierManager)
        {
            while (true)
            {
                Console.WriteLine("\nSupplier Management");
                Console.WriteLine("1. Add Supplier");
                Console.WriteLine("2. Update Supplier");
                Console.WriteLine("3. Delete Supplier");
                Console.WriteLine("4. View Supplier's Details");
                Console.WriteLine("5. View All Suppliers");
                Console.WriteLine("6. Go Back to Main Menu");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddSupplier(supplierManager);
                        break;
                    case 2:
                        UpdateSupplier(supplierManager);
                        break;
                    case 3:
                        DeleteSupplier(supplierManager);
                        break;
                    case 4:
                        ViewSupplierDetails(supplierManager);
                        break;
                    case 5:
                        ViewAllSuppliers(supplierManager);
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void TransactionManagementMenu(TransactionManager transactionManager)
        {
            while (true)
            {
                Console.WriteLine("\nTransaction Management");
                Console.WriteLine("1. Add Stock");
                Console.WriteLine("2. Remove Stock");
                Console.WriteLine("3. View Transaction History");
                Console.WriteLine("4. Go Back to Main Menu");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStock(transactionManager);
                        break;
                    case 2:
                        RemoveStock(transactionManager);
                        break;
                    case 3:
                        ViewTransactionHistory(transactionManager);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void GenerateReportMenu(ProductManager productManager, SupplierManager supplierManager, TransactionManager transactionManager)
        {
            while (true)
            {
                Console.WriteLine("\nGenerate Report");
                Console.WriteLine("1. Inventory Details");
                Console.WriteLine("2. List Products");
                Console.WriteLine("3. List Suppliers");
                Console.WriteLine("4. List Transactions");
                Console.WriteLine("5. Go Back to Main Menu");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ViewAllProducts(productManager);
                        ViewAllSuppliers(supplierManager);
                        ViewTransactionHistory(transactionManager);
                        break;
                    case 2:
                        ViewAllProducts(productManager);
                        break;
                    case 3:
                        ViewAllSuppliers(supplierManager);
                        break;
                    case 4:
                        ViewTransactionHistory(transactionManager);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void AddProduct(ProductManager productManager)
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Product Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Product Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter Product Price: ");
            double price = double.Parse(Console.ReadLine());

            var product = new Product { Name = name, Description = description, Quantity = quantity, Price = price };
            productManager.AddProduct(product);
            Console.WriteLine("Product added successfully.");
        }

        static void UpdateProduct(ProductManager productManager)
        {
            Console.Write("Enter Product ID to update: ");
            int productId = int.Parse(Console.ReadLine());

            var product = productManager.GetAllProducts().FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter New Product Name: ");
            product.Name = Console.ReadLine();
            Console.Write("Enter New Product Description: ");
            product.Description = Console.ReadLine();
            Console.Write("Enter New Product Price: ");
            product.Price = double.Parse(Console.ReadLine());

            productManager.UpdateProduct(product);
            Console.WriteLine("Product updated successfully.");
        }

        static void DeleteProduct(ProductManager productManager)
        {
            Console.Write("Enter Product ID to delete: ");
            int productId = int.Parse(Console.ReadLine());

            var result = productManager.DeleteProduct(productId);
            Console.WriteLine(result);
        }

        static void ViewProductDetails(ProductManager productManager)
        {
            Console.Write("Enter Product ID to view details: ");
            int productId = int.Parse(Console.ReadLine());

            var product = productManager.GetAllProducts().FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
            }
            else
            {
                Console.WriteLine(product);
            }
        }

        static void ViewAllProducts(ProductManager productManager)
        {
            var products = productManager.GetAllProducts();
            if (!products.Any())
            {
                Console.WriteLine("No products found.");
            }
            else
            {
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
        }

        static void AddSupplier(SupplierManager supplierManager)
        {
            Console.Write("Enter Supplier Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Supplier Contact Info: ");
            string contactInfo = Console.ReadLine();

            var supplier = new Supplier { Name = name, ContactInfo = contactInfo };
            supplierManager.AddSupplier(supplier);
            Console.WriteLine("Supplier added successfully.");
        }

        static void UpdateSupplier(SupplierManager supplierManager)
        {
            Console.Write("Enter Supplier ID to update: ");
            int supplierId = int.Parse(Console.ReadLine());

            var supplier = supplierManager.GetSupplierByID(supplierId);
            if (supplier == null)
            {
                Console.WriteLine("Supplier not found.");
                return;
            }

            Console.Write("Enter New Supplier Name: ");
            supplier.Name = Console.ReadLine();
            Console.Write("Enter New Supplier Contact Info: ");
            supplier.ContactInfo = Console.ReadLine();

            supplierManager.UpdateSupplier(supplier);
            Console.WriteLine("Supplier updated successfully.");
        }

        static void DeleteSupplier(SupplierManager supplierManager)
        {
            Console.Write("Enter Supplier ID to delete: ");
            int supplierId = int.Parse(Console.ReadLine());

            supplierManager.DeleteSupplier(supplierId);
            Console.WriteLine("Supplier deleted successfully.");
        }

        static void ViewSupplierDetails(SupplierManager supplierManager)
        {
            Console.Write("Enter Supplier ID to view details: ");
            int supplierId = int.Parse(Console.ReadLine());

            var supplier = supplierManager.GetSupplierByID(supplierId);
            if (supplier == null)
            {
                Console.WriteLine("Supplier not found.");
            }
            else
            {
                Console.WriteLine(supplier);
            }
        }

        static void ViewAllSuppliers(SupplierManager supplierManager)
        {
            var suppliers = supplierManager.GetAllSuppliers();
            if (!suppliers.Any())
            {
                Console.WriteLine("No suppliers found.");
            }
            else
            {
                foreach (var supplier in suppliers)
                {
                    Console.WriteLine(supplier);
                }
            }
        }

        static void AddStock(TransactionManager transactionManager)
        {
            Console.Write("Enter Product ID to add stock: ");
            int productId = int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity to add: ");
            int quantity = int.Parse(Console.ReadLine());

            transactionManager.AddStock(productId, quantity);
            Console.WriteLine("Stock added successfully.");
        }

        static void RemoveStock(TransactionManager transactionManager)
        {
            Console.Write("Enter Product ID to remove stock: ");
            int productId = int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity to remove: ");
            int quantity = int.Parse(Console.ReadLine());

            transactionManager.RemoveStock(productId, quantity);
            Console.WriteLine("Stock removed successfully.");
        }

        static void ViewTransactionHistory(TransactionManager transactionManager)
        {
            var transactions = transactionManager.GetAllTransactions();
            if (!transactions.Any())
            {
                Console.WriteLine("No transactions found.");
            }
            else
            {
                foreach (var transaction in transactions)
                {
                    Console.WriteLine(transaction);
                }
            }



        }
    }
}





