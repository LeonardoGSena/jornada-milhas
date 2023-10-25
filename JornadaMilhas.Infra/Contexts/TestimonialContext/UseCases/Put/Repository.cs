using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put.Contracts;
using JornadaMilhas.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infra.Contexts.TestimonialContext.UseCases.Put;

public class Repository : IRepository
{
    public readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Testimonial?> GetTestimonialByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Testimonials.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task UpdateAsync(Testimonial testimonial, CancellationToken cancellationToken)
    {
        _context.Testimonials.Update(testimonial);
        await _context.SaveChangesAsync();
    }
}
