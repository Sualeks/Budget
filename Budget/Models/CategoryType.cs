using System.Collections.Generic;

namespace Budget.Models
{
    public class CategoryType
    {
        public CategoryType()
        {
            this.Categories = new HashSet<Category>();
        }

        public int CategoryTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        ICollection<Category> Categories { get; set; }
    }
}
