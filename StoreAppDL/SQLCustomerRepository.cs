using Microsoft.Data.SqlClient;
using StoreAppModel;

namespace StoreAppDL
{
    public class SQLCustomerRepository : iRepository<Customer>
    {
        //============dependency injection============
        private string _connectionString;

        public SQLCustomerRepository(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }
        //============================================

        public void Add(Customer p_resource)
        {
            string  SqlQuery = @"insert into Customer
                                values  (@Username, @customerName, @customerAddress, @customerEmail)";

            using (SqlConnection connect = new SqlConnection(_connectionString))
            {
                connect.Open();

                SqlCommand command = new SqlCommand(SqlQuery, connect);

                //dynamically change info using AddWithValue and Parameters to avoid risk of SQL Injection attack
                command.Parameters.AddWithValue("@Username", p_resource.Username);
                command.Parameters.AddWithValue("@customerName", p_resource.Name);
                command.Parameters.AddWithValue("@customerAddress", p_resource.Address);
                command.Parameters.AddWithValue("@customerEmail", p_resource.Email);

                //ExecuteNonQuery will not give info back
                command.ExecuteNonQuery();
            }
        }

        public List<Customer> GetAll()
        {
            string SQLQuery = @"select * from Customer";

            List<Customer> listOfCustomer = new List<Customer>();

            //SqlConnection object establishes  connection to database
            using (SqlConnection connect = new SqlConnection(_connectionString))
            {
                connect.Open();

                //SqlCommand object executes SQL statments to database
                SqlCommand command = new  SqlCommand(SQLQuery, connect);

                //SqlDataReader reads info from SQL Server database
                SqlDataReader reader =  command.ExecuteReader();

                //mapping table format to  List collection
                while (reader.Read())
                {
                    //adding new Customer object to List collection
                    listOfCustomer.Add(new Customer(){

                        Username = reader.GetString(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        Email = reader.GetString(3),
                    });
                }
                return listOfCustomer;

            }
        }

        public void Update(Customer p_resource)
        {
            throw new NotImplementedException();
        }
    }
}
