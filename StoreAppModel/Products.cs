namespace StoreAppModel
{
    public  class Products
    {
        public int ProductId { get; set; }
        public string productName { get; set; }

        public double productPrice { get; set; }

        public int Quantity { get; set; }

        public Products()
        {
            ProductId = 0;
            productName = this.productName;
            productPrice = this.productPrice;
            Quantity = 0;
        }
    }
}