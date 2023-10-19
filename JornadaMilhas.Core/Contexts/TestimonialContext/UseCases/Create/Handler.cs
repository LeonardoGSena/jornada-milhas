using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create.Contracts;
using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01. Validar requisicao
        try
        {
            var res = Specification.Ensure(request);
            if (!res.IsValid)
                return new Response("Requisição inválida", 400, res.Notifications);
        }
        catch
        {

            return new Response("Não foi possível validar sua requisição", 500);
        }
        #endregion

        #region 02. Gerar Objetos
        Testimonial testimonial;
        try
        {
            testimonial = new Testimonial(request.Name, request.Testimony, request.Image);
        }
        catch
        {
            return new Response("Não foi possível criar o depoimento", 500);
        }
        #endregion

        #region 03. Persistir dados
        try
        {
            await _repository.SaveAsync(testimonial, cancellationToken);
        }
        catch
        {
            return new Response("Falha ao persistir dados", 500);
        }
        #endregion

        return new Response("Depoimento criado", new ResponseData(testimonial.Id, testimonial.Name, testimonial.Testimony));
    }


}

