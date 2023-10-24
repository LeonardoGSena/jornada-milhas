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

    public async Task<Testimonial?> GetOneAsync(Guid id, CancellationToken cancellationToken)
    {
        var testimonial = await _context.Testimonials.FindAsync(id, cancellationToken);
        return testimonial;
    }

    public async Task UpdateAsync(Testimonial testimonial, CancellationToken cancellationToken)
    {
        await _context.Testimonials.AddAsync(testimonial);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
