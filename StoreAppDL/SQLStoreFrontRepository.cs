using Microsoft.Data.SqlClient;
using StoreAppModel;

namespace StoreAppDL
{
    public class SQLStoreFrontRepository : iRepository<StoreFront>
    {
        //============dependency injection============
        private string _connectionString;

        public SQLStoreFrontRepository(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }
        //============================================
        public void Add(StoreFront p_resource)
        {
            throw new NotImplementedException();
        }

        public List<StoreFront> GetAll()
        {
            string SqlQuery = @"select * from StoreFront";
            List<StoreFront> listofStoreFront = new List<StoreFront>();

            using (SqlConnection connect = new SqlConnection(_connectionString))
            {
                connect.Open();

                SqlCommand command = new SqlCommand(SqlQuery,  connect);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listofStoreFront.Add(new StoreFront(){
                        StoreID = reader.GetInt32(0),
                        StoreFrontName = reader.GetString(1),
                        StoreFrontLocation = reader.GetString(2),
                        _products = GetProductsFromStore(reader.GetInt32(0))
                    });
                }
            }
            return listofStoreFront;
        }

        private List<Products> GetProductsFromStore(int p_storeId)
        {
            string SqlQuery = @"select s.StoreName, i.quantity, p.pId, p.productName, p.productPrice from StoreFront s
                                inner join Inventory i on s.storeId = i.storeId
                                inner join Products p on p.pId = i.pId
                                where s.storeId = @storeId";

            List<Products> listofProducts = new List<Products>();

            using (SqlConnection connect = new SqlConnection(_connectionString))
            {
                connect.Open();

                SqlCommand command = new SqlCommand(SqlQuery, connect);

                command.Parameters.AddWithValue("@storeId", p_storeId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listofProducts.Add(new Products(){
                        ProductId = reader.GetInt32(2),
                        Quantity = reader.GetInt32(1),
                        productName = reader.GetString(3),
                        productPrice = (double)reader.GetDecimal(4)
                    });
                }
            }

            return listofProducts;
        }

        public void Update(StoreFront p_resource)
        {
            throw new NotImplementedException();
        }
    }
}