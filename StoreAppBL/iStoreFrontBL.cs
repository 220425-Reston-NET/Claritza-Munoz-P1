using StoreAppModel;

namespace StoreAppBL
{
    public interface iStoreFrontBL
    {
        /// <summary>
        /// displays list of products from store
        /// </summary>
        /// <param name="p_storeId">store it will select</param>
        /// <returns>list of  products from store</returns>
        public List<Products> ViewStoreInventory(int p_storeId);
    }
}