﻿using Forc.IntegtationTests.Infrastructure;
using Forc.WebApi.Dto;
using System.Net;
using System.Net.Http.Json;

namespace Forc.IntegtationTests.Controllers.AuthController
{
    public class CreateUser_CorrectModelTest : TestWebApplicationFactory
    {
        public CreateUser_CorrectModelTest()
        {
            rootUrl = "/account";
        }

        [Fact]
        public async Task CreateUser_CorrectModel_ReturnOK()
        {
            var model = new CheckInViewModel
            {
                UserName = "Test",
                Email = "TestEmail@gmail.com",
                Password = "R12345qwe"
            };

            var response = await _httpClient.PostAsJsonAsync($"{rootUrl}/checkin", model);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
