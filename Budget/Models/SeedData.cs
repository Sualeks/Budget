
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Budget.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { CategoryID = 1, Name = "Хлеб", Description = "Delicious" },
                    new Product { CategoryID = 1, Name = "Milk", Description = "Delicious" },
                    new Product { CategoryID = 1, Name = "Eggs", Description = "Delicious" }
                    );
                context.Categories.AddRange(
                    new Category { CategoryTypeID = 1, Name = "Feed", ParentCategoryID = null }
                    );
                context.CategoryTypes.AddRange(
                   new CategoryType { Name = "Needed" }
                   );
                context.SaveChanges();
            }
        }
    }
}
