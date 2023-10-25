using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Read.Contracts;
using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Read;

public class GetTestimonialByIdHandler : IRequestHandler<GetTestimonialByIdQuery, TestimonialResponse>
{
    private readonly IRepository _repository;

    public GetTestimonialByIdHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<TestimonialResponse> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
    {

        #region 01. Realizar requisição

        Testimonial? testimonial;
        try
        {
            testimonial = await _repository.GetOneAsync(request.Id, cancellationToken);
            if (testimonial is null)
                return new TestimonialResponse("Depoimento não encontrado", 404);
        }
        catch
        {
            return new TestimonialResponse("Não foi possível acessar o dado", 505);
        }

        #endregion

        return new TestimonialResponse("Depoimento encontrado", new ResponseData(testimonial.Id, testimonial.Name, testimonial.Testimony));
    }
}
