using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create;

public record CreateTestimonialRequest(
    string Name,
    string Testimony,
    string Image
) : IRequest<TestimonialResponse>;
