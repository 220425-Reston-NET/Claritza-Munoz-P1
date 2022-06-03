using System.Text.Json;
using StoreAppModel;

namespace StoreAppDL
{
    public class OrderRepository : iRepository<Order>
    {
        private string _filepath = "../StoreAppDL/Data/Order.json";
        public void Add(Order p_resource)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            string jsonString = File.ReadAllText(_filepath);
            List<Order> listOfOrder = JsonSerializer.Deserialize<List<Order>>(jsonString);

            return listOfOrder;
        }

        public void Update(Order p_resource)
        {
            throw new NotImplementedException();
        }
    }
}