﻿using CandyShop.Application.CandyContext;
using CandyStore.Cqrs.Requests;
using CSharpFunctionalExtensions;
using MediatR;

namespace CandyStore.QueryHandlers.CandyContext;

public class CandyHandler :
    IRequestHandler<GetCandyQuery, Result<CandyDto, string>>,
    IRequestHandler<GetCandiesQuery, Result<List<CandyDto>, string>>
{
    public Task<Result<CandyDto, string>> Handle(
        GetCandyQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<CandyDto>, string>> Handle(
        GetCandiesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
