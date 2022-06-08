using Microsoft.Data.SqlClient;
using StoreAppModel;

namespace StoreAppDL
{
    public class SQLOrderRepositoryRepo : iRepository<Order>
    {
        //=================== Dependency Injection ==========================
        private string _connectionString;

        public SQLOrderRepositoryRepo(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }

        //=====================Dependency Injection ========================
        public void Add(Order p_resource)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            string SQLQuery = @"select c.Username, o.ID, o.Location, o.TotalPrice from Customer c
                                inner join Orders o on c.Username = o.Username
                                where c.Username = @Username";

            List<Order> listOfOrders = new List<Order>();

            using (SqlConnection connect = new SqlConnection(_connectionString))
            {
                connect.Open();

                SqlCommand command = new  SqlCommand(SQLQuery, connect);

                //command.Parameters.AddWithValue("@Username", p_username);

                SqlDataReader reader =  command.ExecuteReader();

                while (reader.Read())
                {
                        listOfOrders.Add(new Order(){
                        OrderID = reader.GetInt32(1),
                        Location = reader.GetString(2),
                        TotalPrice = (double)reader.GetDecimal(3)
                        
                    });
                }
                return listOfOrders;
            }
        }

        public void Update(Order p_resource)
        {
            string SQLquery = @"update Orders
                                set Totalprice = @TotalPrice
                                set Location = @Location
                                where Username = @Username and ID = @OrderID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);

                command.Parameters.AddWithValue("@ID", p_resource.OrderID);
                command.Parameters.AddWithValue("@Location", p_resource.Location);
                command.Parameters.AddWithValue("@TotalPrice", p_resource.TotalPrice);

                command.ExecuteNonQuery();
            }
        }
    }
}