using System.ComponentModel.DataAnnotations;

namespace StoreAppModel
{
    public class StoreFront
    {
        public string StoreFrontName { get; set; }

        public string StoreFrontLocation { get; set; }

        public List<Order> _orders { get; set; }

        public List<Products> _products { get; set; }

        private int _storeID;

        public int StoreID
        {
            get { return _storeID; }
            set
            {
                if(value > 0)
                {
                    _storeID = value;
                }
                else
                {
                    throw new ValidationException("StoreID can only be positive integers");
                }
            }
        }

        public StoreFront()
        {
            _storeID = 0;
            StoreFrontName = this.StoreFrontName;
            StoreFrontLocation = this.StoreFrontLocation;
            _orders = new List<Order>();
            _products = new List<Products>();
        }
    }

}