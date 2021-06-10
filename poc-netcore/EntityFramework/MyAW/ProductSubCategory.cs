using System.Collections.Generic;

namespace EntityFramework.MyAW
{
    public class ProductSubCategory
    {
        public int ProductSubCategoryId { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }

        //
        // public ProductCategory Category { get; set; }
        // public int CategoryId { get; set; }

    }
}