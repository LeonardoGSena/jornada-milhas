using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.GetAll;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.GetAll.Contracts;
using JornadaMilhas.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infra.Contexts.TestimonialContext.UseCases.GetAll;

public class Repository : IRepository
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Testimonial>> GetAllTestimonialsAsync()
    {
        return await _context.Testimonials.ToListAsync();
    }
}
