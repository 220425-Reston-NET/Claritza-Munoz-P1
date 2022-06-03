using StoreAppDL;
using StoreAppModel;

namespace StoreAppBL
{
    public class CustomerBL : iCustomerBL
    {
        //============Dependency Injection==========
        private iRepository<Customer> _custRepo;

        public CustomerBL(iRepository<Customer> _customerRepo)
        {
            _custRepo = _customerRepo;
        }
        //==========================================
        public void AddCustomer(Customer _custobj)
        {
            Customer foundCustomer = SearchCustomer(_custobj.Username);
            if(foundCustomer == null)
            {
                _custRepo.Add(_custobj);
            }
            else
            {
                throw new Exception("Username already exists!");
            }
        }

        public void AddOrdertoCustomer(Customer p_customer)
        {
            _custRepo.Update(p_customer);
        }

        public List<Customer> GetAllCustomer()
        {
            return _custRepo.GetAll();
        }

        public Customer SearchCustomer(string _custobjUsername)
        {
            List<Customer> currentCustomerList = _custRepo.GetAll();

            foreach(Customer custobj in currentCustomerList)
            {
                if(custobj.Username == _custobjUsername)
                {
                    return custobj;
                }

            }
            
            //returns nothing/no value
            return null;
        }
    }
}