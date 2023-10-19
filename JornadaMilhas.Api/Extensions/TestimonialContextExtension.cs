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
            ? Results.Created("", result)
            : Results.Json(result, statusCode: result.Status);
        });

        #endregion
    }
}
