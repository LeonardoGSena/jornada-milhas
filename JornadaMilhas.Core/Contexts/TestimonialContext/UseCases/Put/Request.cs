using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put;

public record Request(
    Guid Id,
    string Name,
    string Testimonial,
    string Image
) : IRequest<Response>;
