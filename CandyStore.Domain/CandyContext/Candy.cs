using CandyStore.Domain.CommonContext;
using CSharpFunctionalExtensions;

namespace CandyStore.Domain.CandyContext;

public class Candy : IEntity
{
    public long Id { get; init; }
    public string BrandName { get; private set; } = null!;
    public string ProductName { get; private set; } = null!;
    public decimal CostPerKg { get; private set; }

    private Candy() { }

    public static Result<Candy, string> New(
        long id,
        string brandName,
        string productName,
        decimal costPerKg)
    {
        var candy = new Candy()
        {
            Id = id,
            BrandName = brandName,
            ProductName = productName,
            CostPerKg = costPerKg,
        };

        var validation = Validate(candy);
        if (validation.IsFailure)
            return validation.Error;

        return candy;
    }

    public Result Edit(
        string brandName,
        string productName,
        decimal costPerKg)
    {
        BrandName = brandName;
        ProductName = productName;
        CostPerKg = costPerKg;

        var validation = Validate(this);
        if (validation.IsFailure)
            return validation;

        return Result.Success();
    }

    private static Result Validate(Candy candy)
    {
        if (candy.Id < 0)
            return Result.Failure("Candy id number cannot be negative");

        if (string.IsNullOrWhiteSpace(candy.BrandName))
            return Result.Failure("Candy brand name cannot be empty");

        if (string.IsNullOrWhiteSpace(candy.ProductName))
            return Result.Failure("Candy product name cannot be empty");

        if (candy.CostPerKg < 0)
            return Result.Failure("Candy cost per kilogram cannot be negative");

        return Result.Success();
    }
}
