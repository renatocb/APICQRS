using System.Threading;
using System.Threading.Tasks;
using CQRS.Tests.MockRepository;
using CQRS.Application.Services.Queries;
using CQRS.Domain.Dtos;
using CQRS.Domain.Interfaces;
using CQRS.Domain.Utils;
using CQRS.Infrastructure.Context;
using CQRS.Infrastructure.Repositories;
using MediatR;
using Moq;
using Xunit;

namespace MyApiApp.Tests
{
    public class VivaRealImoveisSaleTests
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IZapImoveisRepository> _zapImoveisRepository;
        private readonly Mock<IVivaRealImoveisRepository> _vivaRealImoveisRepository;
        private readonly GetAllImoveisByPageQuery _pageQuery;

        public VivaRealImoveisSaleTests()
        {
            _zapImoveisRepository = new Mock<IZapImoveisRepository>(); 
            _vivaRealImoveisRepository = new Mock<IVivaRealImoveisRepository>();
            _mediator = new Mock<IMediator>();
            _pageQuery = new GetAllImoveisByPageQuery("vivareal", 50, 1);
        }

        private void SetupTest(AppDbContext dbContext)
        {
            var _fakeRepository = new ZapImoveisRepository(dbContext);
            _vivaRealImoveisRepository.Setup(s => s.GetByPageAsync(50, 1, new CancellationToken()))
            .Returns(_fakeRepository.GetByPageAsync(1, 50, CancellationToken.None));
            _vivaRealImoveisRepository.Setup(s => s.SaleRules())
            .Returns(_fakeRepository.SaleRules());
        }

        private void SetupTestSaleWork()
        {
            AppDbContext dbContext = new FakeRepositoryZapImoveis().CreateFakeRepositorySaleRulesWorking();
            SetupTest(dbContext);
        }

        private void SetupTestRentalWork()
        {
            AppDbContext dbContext = new FakeRepositoryZapImoveis().CreateFakeRepositoryRentalRulesWorking();
            SetupTest(dbContext);
        }

        private void SetupTestSaleNotWork()
        {
            AppDbContext dbContext = new FakeRepositoryZapImoveis().CreateFakeRepositorySaleRulesNotWorking();
            SetupTest(dbContext);
        }

        private void SetupTestRentalNotWork()
        {
            AppDbContext dbContext = new FakeRepositoryZapImoveis().CreateFakeRepositoryRentalRulesNotWorking();
            SetupTest(dbContext);
        }
        private async Task<GetImoveisListResponseDto> Execute()
        {
            var imoveisQueryHandler = new GetAllImoveisQueryQueryHandler(_zapImoveisRepository.Object, _vivaRealImoveisRepository.Object, _mediator.Object);
            var imoveisResult = await imoveisQueryHandler.Handle(_pageQuery, new CancellationToken());
            return imoveisResult;
        }

        [Fact]
        public async Task VivaRealImoveisReturnSale_RulesWorking_Exists()
        {
            SetupTestSaleWork();
            var result = await Execute();
            Assert.Equal(result.Listings.Count == 1, true);
        }

        [Fact]
        public async Task VivaRealImoveisReturnSale_RentalWorking_Exists()
        {
            SetupTestRentalWork();
            var result = await Execute();
            Assert.Equal(result.Listings.Count == 1, true);
        }

        [Fact]
        public async Task VivaRealImoveisReturnSale_RulesNotWorking_NotExists()
        {
            SetupTestSaleNotWork();
            var result = await Execute();
            Assert.Equal(result.Listings.Count == 0, true);
        }

        [Fact]
        public async Task VivaRealImoveisReturnSale_RentalNotWorking_NotExists()
        {
            SetupTestRentalNotWork();
            var result = await Execute();
            Assert.Equal(result.Listings.Count == 0, true);
        }
    }
}

