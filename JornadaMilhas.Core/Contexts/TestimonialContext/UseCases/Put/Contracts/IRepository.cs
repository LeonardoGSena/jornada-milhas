
using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put.Contracts;

public interface IRepository
{
    Task<Testimonial?> GetTestimonialByIdAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateAsync(Testimonial testimonial, CancellationToken cancellationToken);
}
