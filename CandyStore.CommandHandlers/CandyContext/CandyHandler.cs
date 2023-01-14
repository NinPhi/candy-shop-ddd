using CandyShop.Application.CandyContext;
using CandyStore.Cqrs.Requests;
using CSharpFunctionalExtensions;
using MediatR;

namespace CandyStore.CommandHandlers.CandyContext;

public class CandyHandler :
    IRequestHandler<CreateCandyCommand, Result<CandyDto, string>>,
    IRequestHandler<UpdateCandyCommand, Result<CandyDto, string>>,
    IRequestHandler<RemoveCandyCommand, Result>
{
    public Task<Result<CandyDto, string>> Handle(
        CreateCandyCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result<CandyDto, string>> Handle(
        UpdateCandyCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Handle(
        RemoveCandyCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
