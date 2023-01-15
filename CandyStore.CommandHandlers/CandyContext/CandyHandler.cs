using CandyStore.Application.CandyContext;
using CandyStore.Cqrs.Requests;
using CSharpFunctionalExtensions;
using MediatR;

namespace CandyStore.CommandHandlers.CandyContext;

public class CandyHandler :
    IRequestHandler<CreateCandyCommand, Result<CandyDto, string>>,
    IRequestHandler<UpdateCandyCommand, Result<CandyDto, string>>,
    IRequestHandler<RemoveCandyCommand, Result>
{
    private readonly CandyService candyService;

    public CandyHandler(CandyService candyService)
    {
        this.candyService = candyService;
    }

    public Task<Result<CandyDto, string>> Handle(
        CreateCandyCommand request, CancellationToken cancellationToken)
    {
        return candyService.Create(request.Dto);
    }

    public Task<Result<CandyDto, string>> Handle(
        UpdateCandyCommand request, CancellationToken cancellationToken)
    {
        return candyService.Update(request.Dto);
    }

    public Task<Result> Handle(
        RemoveCandyCommand request, CancellationToken cancellationToken)
    {
        return candyService.Delete(request.Id);
    }
}
