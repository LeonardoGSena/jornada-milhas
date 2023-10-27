using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.GetAll.Contracts;

public interface IRepository
{
    Task<ICollection<Testimonial>> GetAllTestimonialsAsync();

}
