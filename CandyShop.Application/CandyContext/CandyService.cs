using CandyStore.Application.CandyContext;
using CandyStore.Domain.CandyContext;
using CSharpFunctionalExtensions;

namespace CandyShop.Application.CandyContext;

public class CandyService
{
    private readonly ICandyRepository candyRepo;

    public CandyService(ICandyRepository candyRepo)
    {
        this.candyRepo = candyRepo;
    }

    public async Result<CandyDto, string> Create(CandyDto candyDto)
    {
        var candyResult = Candy.New(
            0,
            candyDto.BrandName,
            candyDto.ProductName,
            candyDto.CostPerKg);

        if (candyResult.IsSuccess)
        {
            await candyRepo.AddAsync(candyResult.Value);
        }

    }
}
