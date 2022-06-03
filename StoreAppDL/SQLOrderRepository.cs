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
            throw new NotImplementedException();
        }

        public void Update(Order p_resource)
        {
            string SQLquery = @"update Orders
                                set Totalprice = @TotalPrice
                                where Username = @Username and Location = @Location";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);

                command.Parameters.AddWithValue("@Location", p_resource.Location);
                command.Parameters.AddWithValue("@TotalPrice", p_resource.TotalPrice);

                command.ExecuteNonQuery();
            }
        }
    }
}