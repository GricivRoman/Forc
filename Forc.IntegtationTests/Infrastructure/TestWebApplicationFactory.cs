﻿using Forc.Infrastructure.Data;
using Forc.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Forc.IntegtationTests.Infrastructure
{
    public class TestWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected HttpClient _httpClient;
        protected string url;

        public TestWebApplicationFactory()
        {
            _httpClient = CreateClient();
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<DataContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<DataContext>(opt =>
                {
                    opt.UseInMemoryDatabase($"Forc_test");
                });
            });

            return base.CreateHost(builder);
        }
    }
}
