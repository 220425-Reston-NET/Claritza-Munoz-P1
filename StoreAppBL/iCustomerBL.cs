using StoreAppModel;

namespace StoreAppBL
{
    /// <summary>
    /// business layer is responsible for further validation or processing of data obtained from the database or the user
    /// </summary>
    public interface iCustomerBL
    {
        /// <summary>
        /// Add customer to database
        /// </summary>
        /// <param name="_custobj">customer object to be added to database</param>
        /// <returns>returns customer that was added to database</returns>
        void AddCustomer(Customer _custobj);

        Customer SearchCustomer(string _custUserObj);

        void AddOrdertoCustomer(Customer p_customer);

        /// <summary>
        /// will give current customers in db
        /// </summary>
        /// <returns>list object that holds customer</returns>
        List<Customer> GetAllCustomer();
    }
}
