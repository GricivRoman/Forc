using Forc.IntegtationTests.Infrastructure;
using Forc.WebApi;
using Forc.WebApi.Dto;
using System.Net;
using System.Net.Http.Json;

namespace Forc.IntegtationTests
{
    public class AuthControllerTests : IntegrationTest
    {
        private readonly HttpClient _httpClient;

        public AuthControllerTests(TestWebApplicationFactory<Program> factory) : base(factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Test1()
        {
            var model = new CheckInViewModel
            {
                UserName = "Test",
                Email = "TestEmail@gmail.com",
                Password = "R12345qwe"
            };

            var response = await _httpClient.PostAsJsonAsync($"/account/checkin", model);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}