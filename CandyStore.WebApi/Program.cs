using CandyStore.Application.CandyContext;
using CandyStore.Cqrs.Requests;
using CandyStore.Infrastructure.DependencyInjection;
using CSharpResult = CSharpFunctionalExtensions.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterAll(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "CandyShop API is up and running!")
    .WithName("CheckStatus");

#region CandyContext
app.MapGet("/api/candy",
    async ([FromServices] IMediator mediator) =>
    {
        var query = new GetCandiesQuery();
        var result = await mediator.Send(query);
        return result.IsSuccess
            ? Results.Ok(result.Value)
            : Results.BadRequest(result.Error);
    }).WithName("GetCandies");

app.MapGet("/api/candy/{id:long}",
    async ([FromRoute] long id, IMediator mediator) =>
    {
        var query = new GetCandyQuery(id);
        var result = await mediator.Send(query);
        return result.IsSuccess
            ? Results.Ok(result.Value)
            : Results.BadRequest(result.Error);
    }).WithName("GetCandy");

app.MapPost("/api/candy",
    async ([FromBody] CandyDto candy, IMediator mediator) =>
    {
        var query = new CreateCandyCommand(candy);
        var result = await mediator.Send(query);
        return result.IsSuccess
            ? Results.Created(
                $"api/candy/{result.Value.Id}", result.Value)
            : Results.BadRequest(result.Error);
    }).WithName("CreateCandy");

app.MapPut("/api/candy",
    async ([FromBody] CandyDto candy, IMediator mediator) =>
    {
        var query = new UpdateCandyCommand(candy);
        var result = await mediator.Send(query);
        return result.IsSuccess
            ? Results.Ok(result.Value)
            : Results.BadRequest(result.Error);
    }).WithName("UpdateCandy");

app.MapDelete("/api/candy/{id:long}",
    async ([FromRoute] long id, IMediator mediator) =>
    {
        var query = new DeleteCandyCommand(id);
        var result = await mediator.Send(query);
        return result.IsSuccess
            ? Results.Ok()
            : Results.BadRequest(result.Error);
    }).WithName("DeleteCandy");
#endregion CandyContext

app.Run();