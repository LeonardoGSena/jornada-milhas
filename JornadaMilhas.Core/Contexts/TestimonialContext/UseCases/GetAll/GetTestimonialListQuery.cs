using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.GetAll;

public record GetTestimonialListQuery() : IRequest<ICollection<Testimonial>>
{

}
