using CandyStore.Application.CandyContext;
using CandyStore.Cqrs.Requests;
using CSharpFunctionalExtensions;
using MediatR;

namespace CandyStore.QueryHandlers.CandyContext;

public class CandyHandler :
    IRequestHandler<GetCandyQuery, Result<CandyDto, string>>,
    IRequestHandler<GetCandiesQuery, Result<List<CandyDto>, string>>
{
    private readonly CandyService candyService;

    public CandyHandler(CandyService candyService)
    {
        this.candyService = candyService;
    }

    public Task<Result<CandyDto, string>> Handle(
        GetCandyQuery request, CancellationToken cancellationToken)
    {
        return candyService.Find(request.Id);
    }

    public Task<Result<List<CandyDto>, string>> Handle(
        GetCandiesQuery request, CancellationToken cancellationToken)
    {
        return candyService.All();
    }
}
