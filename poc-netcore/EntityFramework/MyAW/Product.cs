namespace EntityFramework.MyAW
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ProductSubCategory SubCategory { get; set; }
        public int? SubCategoryId { get; set; }

        //
        // public Product(int id, string name, int subCategoryId)
        // {
        //     Id = id;
        //     Name = name;
        //     SubCategoryId = subCategoryId;
        // }
    }
}