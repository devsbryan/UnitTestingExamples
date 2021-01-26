using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using MyCompany.ECommerce.Api.Controllers;
using MyCompany.ECommerce.Api.Models;
using MyCompany.ECommerce.Api.Services;
using NUnit.Framework;

namespace MyCompany.ECommerce.Api.Tests.Controllers
{
    [TestFixture]
    public class ProductControllerTests
    {
        private AutoMocker _autoMocker;

        private readonly Fixture _autoFixture;

        public ProductControllerTests()
        {
            _autoFixture = new Fixture();
        }

        [SetUp]
        public void SetupTestCase()
        {
            _autoMocker = new AutoMocker();
        }

        [Test]
        public void GetProduct_WithProductId_ReturnsAnOkObjectResult()
        {
            var productId = _autoFixture.Create<int>();

            var sut = _autoMocker.CreateInstance<ProductController>();

            var result = sut.GetProduct(productId);

            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Test]
        public void GetProduct_WithProductId_ReturnsAProductAsContent()
        {
            var product = _autoFixture.Create<Product>();

            var productId = _autoFixture.Create<int>();

            var sut = _autoMocker.CreateInstance<ProductController>();

            _autoMocker.GetMock<IProductService>().Setup(x => x.GetProduct(productId)).Returns(product);

            var result = sut.GetProduct(productId);

            var okObjectResult = result as OkObjectResult;
            var content = okObjectResult?.Value;

            Assert.IsAssignableFrom<Product>(content);
        }

        [Test]
        public void GetProduct_WithProductId_ReturnsTheRequestedProductFromTheProductService()
        {
            var product = _autoFixture.Create<Product>();

            var productId = _autoFixture.Create<int>();

            var sut = _autoMocker.CreateInstance<ProductController>();

            _autoMocker.GetMock<IProductService>().Setup(x => x.GetProduct(productId)).Returns(product);

            var result = sut.GetProduct(productId);

            var okObjectResult = result as OkObjectResult;

            Assert.AreEqual(product, okObjectResult?.Value);
        }

        [Test]
        public void GetProduct_WithProductId_RaisesAProductRetrievalEvent()
        {
            var product = _autoFixture.Create<Product>();

            var productId = _autoFixture.Create<int>();

            var sut = _autoMocker.CreateInstance<ProductController>();

            _autoMocker.GetMock<IProductService>().Setup(x => x.GetProduct(productId)).Returns(product);

            sut.GetProduct(productId);

            _autoMocker.GetMock<IEventNotificationService>()
                .Verify(x => x.RaiseEvent("ProductRetrieval", productId), Times.Once);
        }
    }
}
