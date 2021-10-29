using CQRS.Domain.Dtos;
using CQRS.Domain.Entities;
using CQRS.Domain.Extensions;
using CQRS.Domain.Interfaces;
using CQRS.Infrastructure.Context;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Repositories
{
    public class VivaRealImoveisRepository : IVivaRealImoveisRepository
    {
        protected readonly AppDbContext _dbContext;
        public VivaRealImoveisRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<GetImoveisListResponseDto> GetByPageAsync(int limit, int page,
                                                                    CancellationToken cancellationToken)
        {
            var imoveis = await SaleRules().Union(RentalRules())
           .OrderBy(p => p.CreatedAt)
           .PaginateAsync(limit, page, cancellationToken);

            return new GetImoveisListResponseDto
            {
                PageNumber = imoveis.PageNumber,
                PageSize = imoveis.PageSize,
                TotalCount = imoveis.TotalCount,
                TotalPages = imoveis.TotalPages,
                Listings = imoveis.Items.Select(p => new ImoveisDto
                {
                    UsableAreas = p.UsableAreas,
                    ListingType = p.ListingType,
                    CreatedAt = p.CreatedAt,
                    ListingStatus = p.ListingStatus,
                    Id = p.Id,
                    ParkingSpaces = p.ParkingSpaces,
                    UpdatedAt = p.UpdatedAt,
                    Owner = p.Owner,
                    Images = p.Images,
                    Address = new AddressDto
                    {
                        City = p.Address.City,
                        Neighborhood = p.Address.Neighborhood,
                        GeoLocation = new GeoLocationDto
                        {
                            Precision = p.Address.GeoLocation.Precision,
                            Location = new LocationDto
                            {
                                Lat = p.Address.GeoLocation.Location.Lat,
                                Lon = p.Address.GeoLocation.Location.Lon
                            }
                        }
                    },
                    BathRooms = p.BathRooms,
                    BedRooms = p.BedRooms,
                    PricingInfos = new PricingInfosDto
                    {
                        YearlyIptu = p.PricingInfos.YearlyIptu,
                        BusinessType = p.PricingInfos.BusinessType,
                        Price = p.PricingInfos.Price,
                        MonthlyCondoFee = p.PricingInfos.MonthlyCondoFee,
                        RentalTotalPrice = p.PricingInfos.RentalTotalPrice
                    }
                }).ToList()
            };
        }

        public IQueryable<Imoveis> SaleRules()
        {
            return _dbContext.Imoveis
            .Where(
                x => x.PricingInfos.BusinessType.Equals("SALE") &&
                Convert.ToInt32(x.PricingInfos.Price) <= 700000 &&
                x.Address.GeoLocation.Location.Lat < 0 &&
                x.Address.GeoLocation.Location.Lon < 0);
        }

        public IQueryable<Imoveis> RentalRules()
        {
            double v;

            return _dbContext.Imoveis
                        .Where(
                             x => x.PricingInfos.BusinessType.Equals("RENTAL") &&
                             x.Address.GeoLocation.Location.Lat < 0 &&
                             x.Address.GeoLocation.Location.Lon < 0)
                         .Where(
                             x => double.TryParse(x.PricingInfos.MonthlyCondoFee, out v) ?
                             v < Convert.ToDouble(x.PricingInfos.RentalTotalPrice) * 0.3 : false)
                         .Where(
                             x => x.Address.GeoLocation.Location.Lon >= -46.693419 &&
                             x.Address.GeoLocation.Location.Lon <= -46.641146 &&
                             x.Address.GeoLocation.Location.Lat >= -23.568704 &&
                             x.Address.GeoLocation.Location.Lat <= -23.546686 ?
                             Convert.ToDouble(x.PricingInfos.RentalTotalPrice) <= (4000 * 1.5) :
                             Convert.ToInt32(x.PricingInfos.RentalTotalPrice) <= 4000);
        }
    }
}
