using CandyStore.Domain.CandyContext;

namespace CandyShop.Application.CandyContext;

public record CandyDto(
    long Id,
    string BrandName,
    string ProductName,
    decimal CostPerKg)
{
    internal static CandyDto FromEntity(Candy entity)
    {
        var dto = new CandyDto(
            entity.Id,
            entity.BrandName,
            entity.ProductName,
            entity.CostPerKg);

        return dto;
    }
}
