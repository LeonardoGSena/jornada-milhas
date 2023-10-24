using MediatR;

namespace JornadaMilhas.Api.Extensions;

public static class TestimonialContextExtension
{
    public static void AddTestimonialContext(this WebApplicationBuilder builder)
    {
        #region Create

        builder.Services.AddTransient<
            JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create.Contracts.IRepository,
            JornadaMilhas.Infra.Contexts.TestimonialContext.UseCases.Create.Repository>();

        #endregion

        #region Read

        builder.Services.AddTransient<
            JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Read.Contracts.IRepository,
            JornadaMilhas.Infra.Contexts.TestimonialContext.UseCases.Read.Repository>();

        #endregion

        #region Put

        builder.Services.AddTransient<
            JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put.Contracts.IRepository,
            JornadaMilhas.Infra.Contexts.TestimonialContext.UseCases.Put.Repository>();

        #endregion
    }

    public static void MapTestimonialEndpoints(this WebApplication app)
    {
        #region Create

        app.MapPost("api/v1/depoimentos", async (
            JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create.Request request,
            IRequestHandler<
                JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create.Request,
                JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
            ? Results.Created($"api/v1/depoimentos/{result.Data?.Id}", result)
            : Results.Json(result, statusCode: result.Status);
        });

        #endregion

        #region Read

        app.MapGet("api/v1/depoimentos/{id}", async (
            [AsParameters] JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Read.Request request,
            IRequestHandler<
                JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Read.Request,
                JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Read.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
            ? Results.Ok(result)
            : Results.Json(result, statusCode: result.Status);
        });

        #endregion

        #region Put

        app.MapPut("api/v1/depoimentos/{id}", async (
            [AsParameters] JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put.Request request,
            IRequestHandler<
                JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put.Request,
                JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
            ? Results.Ok(result)
            : Results.Json(result, statusCode: result.Status);
        });

        #endregion


    }
}
