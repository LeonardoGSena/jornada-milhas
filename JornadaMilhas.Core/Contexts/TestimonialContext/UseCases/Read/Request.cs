using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Read;

public record Request(
    Guid Id
) : IRequest<Response>;