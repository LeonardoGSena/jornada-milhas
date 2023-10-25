using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Delete.Contracts;

public interface IRepository
{
    Task DeleteAsync(Testimonial testimonial, CancellationToken cancellationToken);
    Task<Testimonial?> GetTestimonialByIdAsync(Guid id, CancellationToken cancellationToken);
}
