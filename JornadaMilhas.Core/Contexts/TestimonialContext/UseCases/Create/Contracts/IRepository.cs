using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create.Contracts;

public interface IRepository
{
    Task SaveAsync(Testimonial testimonial, CancellationToken cancellationToken);
}
