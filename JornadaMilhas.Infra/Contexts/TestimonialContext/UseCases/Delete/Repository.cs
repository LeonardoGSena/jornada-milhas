using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using JornadaMilhas.Core.Contexts.TestimonialContext.Queries;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Delete.Contracts;
using JornadaMilhas.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infra.Contexts.TestimonialContext.UseCases.Delete;

public class Repository : IRepository
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Testimonial?> GetTestimonialByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Testimonials.FirstOrDefaultAsync(TestimonialQueries.GetById(id), cancellationToken);

    public async Task DeleteAsync(Testimonial testimonial, CancellationToken cancellationToken)
    {
        _context.Testimonials.Remove(testimonial);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
