using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using JornadaMilhas.Core.Contexts.TestimonialContext.Queries;
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
     => await _context.Testimonials.FirstOrDefaultAsync(TestimonialQueries.GetById(id), cancellationToken);
}
