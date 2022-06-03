using StoreAppDL;
using StoreAppModel;

namespace StoreAppUI
{
    public class ViewCustomerOrder : iMenu
    {
        // //==========dependency injection=====================
        
        // private IOrderedQueryable _orderBL;

        // public ViewCustomerOrder(IOrderedQueryable p_orderBL)
        // {
        //     _orderBL = p_orderBL;
        // }
        // //===================================================
        public void Display()
        {
            Console.WriteLine("===Customer Orders===");
            foreach(Order _orderObj in SearchCustomer.foundCustomer.Orders)
            {
                Console.WriteLine(_orderObj);
            }
            Console.WriteLine("0 - Go Back");
        }

        public string YourChoice()
        {
            string userInput = Console.ReadLine();
            if(userInput == "0")
            {
                return "SearchCustomer";
            }
            else
            {
                return "MainMenu";
            }
        }
    }
}