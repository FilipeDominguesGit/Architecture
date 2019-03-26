using System.Linq;
using Moq;
using NUnit.Framework;
using Onion.Core.Domain.Models;
using Onion.Core.Domain.Repositories;
using Onion.Core.Domain.Services;

namespace Onion.Core.Domain.Tests.Services
{
    [TestFixture]
    public class OrderDomainServiceTests
    {

        private IOrdersDomainService _orderDomainService;
        private Mock<IInventoryRepository> _inventoryRepository;

        [SetUp]
        public void Setup()
        {
            _inventoryRepository = new Mock<IInventoryRepository>();
        }

        [Test]
        public void AddProductToOrder_AddsProductToOrder_WhenHasAvailableOnInventory()
        {
            // arrange
            _orderDomainService = new OrdersDomainService(_inventoryRepository.Object);

            var product = new Product()
            {
                Id = 1,
                Brand = "BrandA",
                Category = "CategoryA",
                Name = "Prod Name",
                Price = 100
            };
            var order = new Order(new User() {Id = 1, FirstName = "FirstName", LastName = "LastName"});

            _inventoryRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(() => new Inventory()
            {
                Quantity = 1,
                Product = new Product() { Id = 1 }
            });


            // act 
            _orderDomainService.AddProductToOrder(product,order);

            // assert
            Assert.IsTrue(order.Products.Count == 1);
            Assert.AreEqual(product,order.Products.First());

        }


    }
}