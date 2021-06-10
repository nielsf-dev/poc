namespace EntityFramework.MyAW
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        
        public virtual ProductSubCategory ProductSubCategory { get; set; }
        public int? ProductSubCategoryId { get; set; }

        //
        // public Product(int id, string name, int subCategoryId)
        // {
        //     Id = id;
        //     Name = name;
        //     SubCategoryId = subCategoryId;
        // }
    }
}