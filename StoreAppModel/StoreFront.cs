namespace StoreAppModel
{
    public class StoreFront
    {
        public string StoreFrontName { get; set; }

        public string StoreFrontLocation { get; set; }

        public List<Order> _orders { get; set; }

        public List<Products> _products { get; set; }

        public StoreFront()
        {
            StoreFrontName = this.StoreFrontName;
            StoreFrontLocation = this.StoreFrontLocation;
            _orders = new List<Order>();
            _products = new List<Products>();
        }
    }

}