using StoreAppDL;
using StoreAppModel;

namespace StoreAppBL
{
    public class StoreFrontBL : iStoreFrontBL
    {
    //============Dependency Injection==========
        private iRepository<StoreFront> _storefrontRepo;

        public StoreFrontBL(iRepository<StoreFront> _storefrontRepo)
        {
            _storefrontRepo = _storefrontRepo;
        }
        //==========================================
        public List<Products> ViewStoreInventory(int p_storeId)
        {
            List<StoreFront> listofCurrentStore = _storefrontRepo.GetAll();

            foreach (StoreFront item in listofCurrentStore)
            {
                if (item.StoreID == p_storeId)
                {
                    return item._products;
                }
            }
            
            //will return nothing if the client input store that isn't in database
            return null;
        }

    }
}