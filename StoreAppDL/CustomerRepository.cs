using System.Text.Json;
using StoreAppModel;

namespace StoreAppDL
{
    //accessing database
    public class CustomerRepository: iRepository<Customer>
    {
        private string _filepath = "../StoreAppDL/Data/Customer.json";

        //method to add customer to data
        public void Add(Customer _custobj)
        {
            List<Customer> listOfCustomer = GetAll();
            listOfCustomer.Add(_custobj);

            string jsonString = JsonSerializer.Serialize(listOfCustomer, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(_filepath, jsonString);

        }

        public List<Customer> GetAll()
        {
            string jsonString = File.ReadAllText(_filepath);
            List<Customer> listOfCustomer = JsonSerializer.Deserialize<List<Customer>>(jsonString);

            return listOfCustomer;
        }

        public void Update(Customer p_resource)
        {
            List<Customer> listofCustomer = GetAll();

            foreach (Customer customerObj in listofCustomer)
            {
                if (customerObj.Username == p_resource.Username)
                {
                    customerObj.Orders = p_resource.Orders;
                }
            }

            string jsonString = JsonSerializer.Serialize(listofCustomer, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(_filepath, jsonString);
        }
    }
}
