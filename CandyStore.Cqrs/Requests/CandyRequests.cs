using CandyStore.Application.CandyContext;
using CSharpFunctionalExtensions;
using MediatR;

namespace CandyStore.Cqrs.Requests;

public class GetCandiesQuery :
    IRequest<Result<List<CandyDto>, string>>
{

}

public class GetCandyQuery :
    IRequest<Result<CandyDto, string>>
{
    public long Id { get; }
    public GetCandyQuery(long id) => Id = id;
}

public class CreateCandyCommand :
    IRequest<Result<CandyDto, string>>
{
    public CandyDto Dto { get; }
    public CreateCandyCommand(CandyDto dto) => Dto = dto;
}

public class UpdateCandyCommand :
    IRequest<Result<CandyDto, string>>
{
    public CandyDto Dto { get; }
    public UpdateCandyCommand(CandyDto dto) => Dto = dto;
}

public class RemoveCandyCommand :
    IRequest<Result>
{
    public long Id { get; }
    public RemoveCandyCommand(long id) => Id = id;
}