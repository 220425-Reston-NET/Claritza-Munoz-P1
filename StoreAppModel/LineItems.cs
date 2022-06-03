namespace StoreAppModel
{
    public class LineItems
    {
        public Products _products { get; set; }
        public int Quantity { get; set; }

        public LineItems()
        {
            _products = new Products();
            Quantity = this.Quantity;
        }
    }
}