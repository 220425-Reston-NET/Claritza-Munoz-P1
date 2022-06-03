namespace StoreAppDL
{
    public interface iRepository<T>
    {
        /// <summary>
        /// will add resource to database
        /// </summary>
        /// <param name="p_resource">resource being added to the database</param>
        void  Add(T p_resource);

        /// <summary>
        /// will get all the specific resources from the datatype
        /// </summary>
        /// <returns>T is the resource being given</returns>
        List<T> GetAll();

        /// <summary>
        /// will update exsisting resource
        /// </summary>
        /// <param name="p_resource">resource it is updating</param>
        void Update(T p_resource);
    }
}