using CandyStore.Application.CandyContext;
using CandyStore.Domain.CandyContext;
using CSharpFunctionalExtensions;

namespace CandyShop.Application.CandyContext;

public class CandyService
{
    private readonly ICandyRepository candyRepository;

    public CandyService(ICandyRepository candyRepository)
    {
        this.candyRepository = candyRepository;
    }

    public async Task<Result<CandyDto, string>> Find(long id)
    {
        var candy = await candyRepository.FindOrNullAsync(id);
        if (candy == null)
            return $"Candy with id number {id} was not found";

        return CandyDto.FromEntity(candy);
    }

    public async Task<Result<List<CandyDto>, string>> All()
    {
        var candies = await candyRepository.AllAsync();

        return candies.Select(candy => CandyDto.FromEntity(candy)).ToList();
    }

    public async Task<Result<CandyDto, string>> Create(CandyDto candyDto)
    {
        var candyResult = Candy.New(
            candyDto.BrandName,
            candyDto.ProductName,
            candyDto.CostPerKg);

        if (candyResult.IsFailure)
            return candyResult.Error;

        var newCandy = await candyRepository.CreateAsync(candyResult.Value);
        await candyRepository.SaveChangesAsync();

        return CandyDto.FromEntity(newCandy);
    }

    public async Task<Result<CandyDto, string>> Update(CandyDto candyDto)
    {
        var candy = await candyRepository.FindOrNullAsync(candyDto.Id);
        if (candy == null)
            return $"Candy with id number {candyDto.Id} was not found";

        var candyResult = candy.Edit(
            candyDto.BrandName,
            candyDto.ProductName,
            candyDto.CostPerKg);

        if (candyResult.IsFailure)
            return candyResult.Error;

        await candyRepository.UpdateAsync(candy);
        await candyRepository.SaveChangesAsync();

        return CandyDto.FromEntity(candy);
    }

    public async Task<Result> Delete(long id)
    {
        var candy = await candyRepository.FindOrNullAsync(id);
        if (candy == null)
            return Result.Success();

        await candyRepository.DeleteAsync(candy);
        await candyRepository.SaveChangesAsync();

        return Result.Success();
    }
}
