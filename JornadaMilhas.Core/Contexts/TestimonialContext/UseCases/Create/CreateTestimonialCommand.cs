using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create;

public record class CreateTestimonialCommand(CreateTestimonialRequest TestimonialRequest) : IRequest<TestimonialResponse>;
