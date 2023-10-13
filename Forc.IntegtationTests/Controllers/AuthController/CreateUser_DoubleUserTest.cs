﻿using Forc.IntegtationTests.Infrastructure;
using Forc.WebApi.Dto;
using System.Net.Http.Json;
using System.Net;

namespace Forc.IntegtationTests.Controllers.AuthController
{
    public class CreateUser_DoubleUserTest : TestWebApplicationFactory
    {
        [Fact]
        public async Task CreateUser_DoubleUser_ReturnBadRequest()
        {
            var model = new CheckInViewModel
            {
                UserName = "Test",
                Email = "TestEmail@gmail.com",
                Password = "R12345qwe"
            };
            var response = await _httpClient.PostAsJsonAsync($"/account/checkin", model);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            model = new CheckInViewModel
            {
                UserName = "Other",
                Email = "TestEmail@gmail.com",
                Password = "R12345qwe"
            };

            response = await _httpClient.PostAsJsonAsync($"/account/checkin", model);
            var errorMessage = (await response.Content.ReadFromJsonAsync<ExeptionDto>()).Message;

            Assert.Multiple(() =>
            {
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
                Assert.Equal("User with this E-mail already exists", errorMessage);
            });

            model = new CheckInViewModel
            {
                UserName = "Test",
                Email = "OtherMail@mail.ru",
                Password = "R12345qwe"
            };

            response = await _httpClient.PostAsJsonAsync($"/account/checkin", model);
            errorMessage = (await response.Content.ReadFromJsonAsync<ExeptionDto>()).Message;

            Assert.Multiple(() =>
            {
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
                Assert.Equal("User with this username already exists", errorMessage);
            });
        }
    }
}
