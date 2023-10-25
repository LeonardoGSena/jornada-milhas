using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Delete;

public record class DeleteTestimonialByIdQuery(
    Guid Id
) : IRequest<TestimonialResponse>;
