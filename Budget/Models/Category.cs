namespace Budget.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public int ParentCategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryTypeID { get; set; }
    }
}
