using StoreAppModel;

namespace StoreAppBL
{
    public interface iOrderBL
    {
        /// <summary>
        /// will give all orders from db
        /// </summary>
        /// <returns>returns list of order objects</returns>
        List<Order> GetAllOrders();

        /// <summary>
        /// will find n order in the db based on location
        /// </summary>
        /// <param name="p_orderLocation">location parameter used to find the order</param>
        /// <returns>returns an order object that is found or null if no order was found</returns>
        Order SearchOrderbyLocation(string p_orderLocation);

    }
}