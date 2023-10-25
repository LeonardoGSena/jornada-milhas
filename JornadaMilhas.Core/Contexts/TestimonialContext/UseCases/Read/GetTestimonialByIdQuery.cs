using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Read;

public record GetTestimonialByIdQuery(
    Guid Id
) : IRequest<TestimonialResponse>;