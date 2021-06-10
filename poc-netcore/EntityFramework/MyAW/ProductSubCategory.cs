namespace EntityFramework.MyAW
{
    public class ProductSubCategory
    {
        public int SubcategoryId { get; set; }
        public string Name { get; set; }
        
        public ProductCategory Category { get; set; }
        public int CategoryId { get; set; }

    }
}