using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put;

public record UpdateTestimonialRequest(
    Guid Id,
    string Name,
    string Testimonial,
    string Image
) : IRequest<TestimonialResponse>;
