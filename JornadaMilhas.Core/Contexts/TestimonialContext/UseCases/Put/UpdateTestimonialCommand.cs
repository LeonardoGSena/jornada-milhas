using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put;

public record class UpdateTestimonialCommand(UpdateTestimonialRequest TestimonialRequest) : IRequest<TestimonialResponse>;
