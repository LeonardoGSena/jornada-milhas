using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create.Contracts;
using JornadaMilhas.Infra.Data;

namespace JornadaMilhas.Infra.Contexts.TestimonialContext.UseCases.Create;

public class Repository : IRepository
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(Testimonial testimonial)
    {
        await _context.Testimonials.AddAsync(testimonial);
        await _context.SaveChangesAsync();
    }
}
