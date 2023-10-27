using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.GetAll;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.GetAll.Contracts;
using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.ReadRandom;

public class GetTestimonialsHandler : IRequestHandler<GetTestimonialListQuery, ICollection<Testimonial>>
{
    private readonly IRepository _repository;

    public GetTestimonialsHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Testimonial>> Handle(GetTestimonialListQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllTestimonialsAsync();
    }
}
