using System.Linq.Expressions;
using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.Queries;

public static class TestimonialQueries
{
    public static Expression<Func<Testimonial, bool>> GetById(Guid id)
    {
        return x => x.Id == id;
    }

}
