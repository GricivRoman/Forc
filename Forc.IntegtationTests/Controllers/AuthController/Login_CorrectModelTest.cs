﻿using Forc.IntegtationTests.Infrastructure;
using Forc.WebApi.Dto;
using System.Net;
using System.Net.Http.Json;

namespace Forc.IntegtationTests.Controllers.AuthController
{
    public class Login_CorrectModelTest : TestWebApplicationFactory
    {
        public Login_CorrectModelTest()
        {
            rootUrl = "/account";
        }

        [Fact]
        public async Task Login_CorrectModel_ReturnAuthorizedData()
        {
            var checkInModel = new CheckInViewModel
            {
                UserName = "Test",
                Email = "TestEmail@gmail.com",
                Password = "R12345qwe"
            };

            var response = await _httpClient.PostAsJsonAsync($"{rootUrl}/checkin", checkInModel);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


            // Login by username
            var loginModel = new LoginViewModel
            {
                UserNameOrEmail = "Test",
                Password = "R12345qwe"
            };

            response = await _httpClient.PostAsJsonAsync($"{rootUrl}/login", loginModel);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var authorizedData = await response.Content.ReadFromJsonAsync<CredentialsViewModel>();

            Assert.Multiple(() =>
            {
                Assert.NotNull(authorizedData.UserId);
                Assert.Equal("Test", authorizedData.UserName);
                Assert.NotNull(authorizedData.Token);
                Assert.IsType<string>(authorizedData.Token);
                Assert.NotNull(authorizedData.Expiration);
                Assert.Equal(0, authorizedData.Roles.Count());
            });


            // Login by e-mail
            loginModel = new LoginViewModel
            {
                UserNameOrEmail = "TestEmail@gmail.com",
                Password = "R12345qwe"
            };

            response = await _httpClient.PostAsJsonAsync($"{rootUrl}/login", loginModel);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            authorizedData = await response.Content.ReadFromJsonAsync<CredentialsViewModel>();

            Assert.Multiple(() =>
            {
                Assert.NotNull(authorizedData.UserId);
                Assert.Equal("Test", authorizedData.UserName);
                Assert.NotNull(authorizedData.Token);
                Assert.IsType<string>(authorizedData.Token);
                Assert.NotNull(authorizedData.Expiration);
                Assert.Equal(0, authorizedData.Roles.Count());
            });
        }
    }
}
