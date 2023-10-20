using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Read.Contracts;
using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Read;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        Testimonial? testimonial;
        try
        {
            testimonial = await _repository.GetOneAsync(request, cancellationToken);
            if (testimonial is null)
                return new Response("Depoimento não encontrado", 404);
        }
        catch
        {
            return new Response("Não foi possível acessar o dado", 505);
        }

        return new Response("Depoimento encontrado", new ResponseData(testimonial.Id, testimonial.Name, testimonial.Testimony));
    }
}
