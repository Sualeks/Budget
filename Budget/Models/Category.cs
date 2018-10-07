using System.Collections.Generic;

namespace Budget.Models
{
    public class Category
    {
        public Category()
        {
            CategoryTypes = new HashSet<CategoryType>();
        }
        public int CategoryID { get; set; }
        public int? ParentCategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryTypeID { get; set; }

        public ICollection<CategoryType> CategoryTypes { get; set; }
    }
}
