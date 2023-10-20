using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Read;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Read.Contracts;
using JornadaMilhas.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infra.Contexts.TestimonialContext.UseCases.Read;

public class Repository : IRepository
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Testimonial?> GetOneAsync(Guid id, CancellationToken cancellationToken)
    {
        var testimonial = await _context.Testimonials.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        await _context.SaveChangesAsync(cancellationToken);
        return testimonial;
    }
}
