using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Read.Contracts;

public interface IRepository
{
    Task<Testimonial?> GetOneAsync(Guid id, CancellationToken cancellationToken);
}
