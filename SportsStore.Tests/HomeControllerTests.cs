using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace SportsStore.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Can_Use_Repository()
        {
            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns(
                (new Product[]{
                    new Product{ProductId=1,Name="p1"},
                    new Product{ProductId=2,Name="p2"}
                } ).AsQueryable<Product>());
            HomeController controller = new HomeController(mock.Object);

            // Act
            IEnumerable<Product>? result=(controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert
            Product[] prodArray = result?.ToArray() ?? Array.Empty<Product>();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("p1", prodArray[0].Name);
            Assert.Equal("p2", prodArray[1].Name);
        }
    }
}