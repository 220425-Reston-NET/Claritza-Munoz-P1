using System.ComponentModel.DataAnnotations;

namespace StoreAppModel
{
    public class Order
    {   
        private int _orderID;

        public int OrderID
        {
            get { return _orderID; }
            set
            {
                if(value > 0)
                {
                    _orderID = value;
                }
                else
                {
                    throw new ValidationException("OrderID can only be positive integers");
                }
            }
        }
        public string Location { get; set; }
        public List<LineItems> _lineItems { get; set; }
        public double TotalPrice { get; set; }


        public Order()
        {
            Location = this.Location;
            _lineItems = new List<LineItems>();
            TotalPrice = 0;
        }

        public override string ToString()
        {
            return $"================\nOrderID: {OrderID}\nLocation: {Location}\nTotalPrice: {TotalPrice}\n================";
        }
    }

}