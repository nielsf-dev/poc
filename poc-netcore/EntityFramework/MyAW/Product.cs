namespace EntityFramework.MyAW
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public ProductSubCategory SubCategory { get; set; }
        public int SubCategoryId { get; set; }

        public Product(int productId, string name, int subCategoryId)
        {
            ProductId = productId;
            Name = name;
            SubCategoryId = subCategoryId;
        }
    }
}