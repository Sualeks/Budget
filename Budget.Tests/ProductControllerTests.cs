using System.Collections.Generic;
using Moq;
using Budget.Controllers;
using Budget.Models;
using Xunit;
using System.Linq;
using Budget.Models.ViewModels;

namespace Budget.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            //Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product{ProductID=1, CategoryID=1, Name="P1", Description="D1"},
                new Product{ProductID=2, CategoryID=1, Name="P2", Description="D2"},
                new Product{ProductID=3, CategoryID=2, Name="P3", Description="D3"},
                new Product{ProductID=4, CategoryID=2, Name="P4", Description="D4"},
                new Product{ProductID=5, CategoryID=1, Name="P5", Description="D5"}
            }).AsQueryable<Product>);

            ProductController productController = new ProductController(mock.Object);
            productController.pageSize = 3;

            //Action
            IEnumerable<Product> result = (productController.List("",2).ViewData.Model as ProductListViewModel).Products;

            //Assert 
            Product[] prArray = result.ToArray();
            Assert.True(prArray.Length == 2);
            Assert.Equal("P4", prArray[0].Name);
            Assert.Equal("P5", prArray[1].Name);
        }

        [Fact]
        public void Can_Send_Paginate_ViewModel()
        {
            //Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product{ProductID = 1, Name = "P1"},
                new Product{ProductID = 2, Name = "P2"},
                new Product{ProductID = 3, Name = "P3"},
                new Product{ProductID = 4, Name = "P4"},
                new Product{ProductID = 5, Name = "P5"}
            }).AsQueryable<Product>());

            //Arrange
            ProductController controller = new ProductController(mock.Object) { pageSize = 3 };

            //Action
            ProductListViewModel result = controller.List("",2).ViewData.Model as ProductListViewModel;

            //Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }
    }
}
