namespace EntityFramework.MyAW
{
    /// <summary>
    /// Het product uit de adventure works
    /// </summary>
    public class Product
    {
        public int Id { get; set; }

        /// <summary>
        /// Naam van het product
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// De <see cref="ProductSubCategory">Sub-category</see>
        /// </summary>
        public virtual ProductSubCategory SubCategory { get; set; }
        public int? SubCategoryId { get; set; }

        /// <summary>
        /// Of het product waardig is
        /// </summary>
        /// <param name="worthyNumber">Het waarde nummer</param>
        public bool CategoryWorth(int worthyNumber)
        {
            return SubCategory.Id > worthyNumber;
        }

        //public Product(string name, int ProductSubcategoryID)
        //{
        //    Name = name;
        //    SubCategoryId = ProductSubcategoryID;
        //}
    }
}