using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class VendingMachine
    {
        private List<Product> inventory;
        private int balance;

        public VendingMachine()
        {
            inventory = new List<Product>();
            balance = 0;

            AddProduct("Coca-cola", 20, 15);
            AddProduct("Hershey's", 10, 20);
            AddProduct("Skittles", 10, 20);
            AddProduct("Bubblegum", 10, 20);
        }

        public void AddBalance(int deposit)
        {
            balance += deposit;
        }

        public void AddProduct(string name, int price, int amount)
        {
            Product product = new Product(name, price, amount);
            inventory.Add(product);
        }

        public void PurchaseProduct(string productName)
        {
            Product selectedProduct = inventory.Find(product => product.ProductName == productName);

            if (selectedProduct == null)
            {
                Console.WriteLine("There is no such item found.\n");
                return;
            }

            if (selectedProduct.ProductAmount <= 0)
            {
                Console.WriteLine("Sorry, product out of stock.\n");
            }
            else if (selectedProduct.ProductPrice > balance)
            {
                Console.WriteLine("Sorry, insufficient balance. Please deposit more amount.\n");
            }
            else
            {
                selectedProduct.DecrementProductAmount();
                balance -= selectedProduct.ProductPrice;
                Console.WriteLine($"Thank you for purchasing {selectedProduct.ProductName}\n");

                if (balance == 0)
                {
                    Console.WriteLine("Thank you for using the exact amount.\n");
                }
                else
                {
                    Console.WriteLine($"Remaining balance: {balance}\n");
                }
            }
        }

        public void ReturnChange()
        {
            if (balance == 0)
            {
                Console.WriteLine("Thank you for using the exact amount.");
            }
            else
            {
                Console.WriteLine($"Returning change: {balance}");
                balance = 0;
            }
        }
        public void DisplayInventory()
        {
            int number = 1;
            foreach (Product product in inventory)
            {
                Console.WriteLine($"{number++} - {product.ProductName} - Price: {product.ProductPrice}");
            }

            Console.WriteLine();
        }

        public void StartVendingMachine()
        {
            Console.WriteLine("Welcome to the virtual vending machine!");
            DisplayInventory();
            Console.WriteLine("Please deposit a sufficient amount to purchase an item.");
            Console.WriteLine($"Your current balance is: {balance}\n");
        }

        public void DepositBalance()
        {
            Console.Write("Enter the amount to deposit: ");
            balance = int.Parse(Console.ReadLine());
            Console.Clear();
            DisplayInventory();
            Console.WriteLine($"Your current balance is: {balance}\n");
        }

        public void ChooseAndBuyProduct()
        {
            DisplayInventory();
            Console.Write("Please select the product to purchase: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    PurchaseProduct("Coca-cola");
                    break;
                case 2:
                    PurchaseProduct("Hershey's");
                    break;
                case 3:
                    PurchaseProduct("Skittles");
                    break;
                case 4:
                    PurchaseProduct("Bubblegum");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
