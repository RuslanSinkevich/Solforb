using Microsoft.AspNetCore.Mvc.Testing;

namespace TestSolforb.IntegrationTest
{
    public class CustomerControllerTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CustomerControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("")]
        [InlineData("/Items/Index/1")]
        [InlineData("/Provider")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            var postRequest = new HttpRequestMessage(HttpMethod.Get, url);

            // Act
            var response = await client.SendAsync(postRequest);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", 
                response.Content.Headers.ContentType!.ToString());

        }

        [Fact]
        public async Task Post_EndpointsReturnSuccessAndCorrectContentType()
        {
            // Arrange
            var formModel = new Dictionary<string, string>
            {
                {  "Provider", "1"}
            };
            var client = _factory.CreateClient();
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/");
            postRequest.Content = new FormUrlEncodedContent(formModel);

            // Act
            var response = await client.SendAsync(postRequest);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", 
                response.Content.Headers.ContentType!.ToString());

        }

    }
}