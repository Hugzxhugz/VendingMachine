
namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();

            vendingMachine.StartVendingMachine();

            bool continueVending = true;
            while (continueVending)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Deposit money");
                Console.WriteLine("2. Choose and buy a product");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        vendingMachine.DepositBalance();
                        break;
                    case 2:
                        Console.WriteLine();
                        vendingMachine.ChooseAndBuyProduct();
                        break;
                    case 3:
                        vendingMachine.ReturnChange();
                        continueVending = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}