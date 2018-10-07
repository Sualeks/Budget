using System.Linq;

namespace Budget.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);

        IQueryable<CategoryType> CategoryTypes { get; }
        void AddCategoryType(CategoryType type);
        void UpdateCategoryType(CategoryType type);
        void DeleteCategoryType(CategoryType type);

        IQueryable<Category> Categories { get; }
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);

    }
}
