using Forc.Infrastructure.Data;
using Forc.IntegtationTests.Infrastructure;
using Forc.WebApi;
using Microsoft.Extensions.DependencyInjection;

namespace Forc.IntegtationTests
{
    public class IntegrationTest : IDisposable, IClassFixture<TestWebApplicationFactory<Program>>
    {
        private readonly TestWebApplicationFactory<Program> _factory;
        private bool _disposedValue;

        public IntegrationTest(TestWebApplicationFactory<Program> factory)
        {
            using (var scope = factory.Services.CreateScope())
            {
                scope.ServiceProvider.GetService<DataContext>().Database.EnsureCreated();
            }
            _factory = factory;
        }
        ~IntegrationTest() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _factory.Services.CreateScope().ServiceProvider.GetService<DataContext>().Database.EnsureDeleted();
                }
                _disposedValue = true;
            }
        }
    }
}
