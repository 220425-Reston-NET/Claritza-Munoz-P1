using StoreAppDL;
using StoreAppModel;

namespace StoreAppBL
{
    public class OrderBL : iOrderBL
    {
        //======Dependency Injection==========
        private iRepository<Order> _orderRepo;

        public OrderBL(iRepository<Order> p_orderRepo)
        {
            _orderRepo = p_orderRepo;
        }

        //====================================
        public List<Order> GetAllOrders()
        {
            return _orderRepo.GetAll();
        }

        public Order SearchOrderbyLocation(string p_orderLocation)
        {
            List<Order> currentOrderList = _orderRepo.GetAll();

            foreach(Order orderobj in currentOrderList)
            {
                if(orderobj.Location == p_orderLocation)
                {
                    return orderobj;
                }

            }
            
            //returns nothing/no value
            return null;
        }
    }
}