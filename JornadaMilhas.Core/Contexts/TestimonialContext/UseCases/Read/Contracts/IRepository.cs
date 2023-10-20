using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Read.Contracts;

public interface IRepository
{
    Task<Testimonial?> GetOneAsync(Request request, CancellationToken cancellationToken);
}
