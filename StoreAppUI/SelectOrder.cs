using StoreAppBL;
using StoreAppModel;

namespace StoreAppUI
{
    public class SelectOrder : iMenu
    {
        //==============Dependency Injection====
        private iOrderBL _orderBL;
        private iCustomerBL _customerBL;

        public SelectOrder(iOrderBL p_orderBL, iCustomerBL p_customerBL)
        {
            _orderBL = p_orderBL;
            _customerBL = p_customerBL;
        }
        //======================================
        public void Display()
        {
            List<Order> listOfOrder = _orderBL.GetAllOrders();
            foreach(Order _orderObj in listOfOrder)
            {
                Console.WriteLine(_orderObj.Location);
            }
        }

        public string YourChoice()
        {

            Console.WriteLine("Choose a location from the list above to add an order: ");
            string userInput = Console.ReadLine();

            Order foundOrder = _orderBL.SearchOrderbyLocation(userInput);

            if (foundOrder != null)
            {
                //adds order to searched customer using List of orders in customer model
                SearchCustomer.foundCustomer.Orders.Add(foundOrder);

                _customerBL.AddOrdertoCustomer(SearchCustomer.foundCustomer);
                
            }
            else
            {
                Console.WriteLine("Invalid Order Location! Please enter valid Order Location (case sensitive)");
                Console.ReadLine();
                return "SelectOrder";
            }

            Console.ReadLine();
            return "MainMenu";

        }
    }
}