using Microsoft.AspNetCore.Mvc;
using Moq;
using Solforb.Controllers;
using Solforb.DataAccess.Repository.IRepository;
using Solforb.Models.ViewModel;
using TestSolforb.Helper;

namespace TestSolforb
{
    public class HomeControllerTests
    {
        private readonly Mock<IOrderRepository> _order = new();
        private readonly Mock<IProviderRepository> _provider = new();
        private readonly BdTests _bdTests = new();

        public HomeControllerTests()
        {
            _provider.Setup(repo => repo.GetAll(null, null, null, true)).Returns(_bdTests.GetTestProvider());
            _order.Setup(repo => repo.GetAll(null, null, "Provider", true)).Returns(_bdTests.GetTestOrder());
            }

        [Fact]
        public void Index_Returns_View_Result_With_HomeVm()
        {
            // Arrange
            var controller = new HomeController(orderRepository: _order.Object, providerRepository: _provider.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<HomeVM>(viewResult.Model);
        }
    }
}