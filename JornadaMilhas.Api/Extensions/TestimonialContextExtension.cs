using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Delete;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.GetAll;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Read;
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

        #region GetAll

        builder.Services.AddTransient<
            JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.GetAll.Contracts.IRepository,
            JornadaMilhas.Infra.Contexts.TestimonialContext.UseCases.GetAll.Repository>();

        #endregion

        #region Put

        builder.Services.AddTransient<
            JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put.Contracts.IRepository,
            JornadaMilhas.Infra.Contexts.TestimonialContext.UseCases.Put.Repository>();

        #endregion

        #region Delete

        builder.Services.AddTransient<
            JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Delete.Contracts.IRepository,
            JornadaMilhas.Infra.Contexts.TestimonialContext.UseCases.Delete.Repository>();

        #endregion
    }

    public static void MapTestimonialEndpoints(this WebApplication app)
    {
        #region Create
        app.MapPost("api/v1/depoimentos", async (IMediator mediator, CreateTestimonialRequest request) =>
        {
            var newTestimonial = await mediator.Send(new CreateTestimonialCommand(request));
            // var result = await handler.Handle(request, new CancellationToken());
            return newTestimonial.IsSuccess
            ? Results.Created($"api/v1/depoimentos/{newTestimonial.Data?.Id}", newTestimonial)
            : Results.Json(newTestimonial, statusCode: newTestimonial.Status);
        });
        #endregion

        #region Read
        app.MapGet("api/v1/depoimentos/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var testimonial = await mediator.Send(new GetTestimonialByIdQuery(id));
            return testimonial.IsSuccess
                 ? Results.Ok(testimonial)
                 : Results.Json(testimonial, statusCode: testimonial.Status);

        });
        #endregion

        #region GetAll
        app.MapGet("api/v1/depoimentos-home", async (IMediator mediator) =>
        {
            var testimonials = await mediator.Send(new GetTestimonialListQuery());
            return Results.Ok(testimonials);
        });
        #endregion

        #region Put
        app.MapPut("api/v1/depoimentos", async (IMediator mediator, UpdateTestimonialRequest request) =>
        {
            var updatedTestimonial = await mediator.Send(new UpdateTestimonialCommand(request));
            return updatedTestimonial.IsSuccess
            ? Results.Ok(updatedTestimonial)
            : Results.Json(updatedTestimonial, statusCode: updatedTestimonial.Status);
        });
        #endregion

        #region Delet
        app.MapDelete("api/v1/depoimentos/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var testimonial = await mediator.Send(new DeleteTestimonialByIdQuery(id));
            return testimonial.IsSuccess
                 ? Results.Ok(testimonial)
                 : Results.Json(testimonial, statusCode: testimonial.Status);

        });
        #endregion
    }
}
