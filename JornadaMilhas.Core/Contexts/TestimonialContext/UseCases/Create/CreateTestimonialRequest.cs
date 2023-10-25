using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create;

public record CreateTestimonialRequest(
    string Name,
    string Testimonial,
    string Image
) : IRequest<TestimonialResponse>;
