namespace VendingMachine
{
    public class Product
    {
        public string ProductName { get; private set; }
        public int ProductPrice { get; private set; }
        public int ProductAmount { get; private set; }

        public Product(string productName, int productPrice, int productAmount)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            ProductAmount = productAmount;
        }

        public void DecrementProductAmount()
        {
            ProductAmount--;
        }
    }
}