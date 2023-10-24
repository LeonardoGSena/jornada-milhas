using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put.Contracts;
using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put;

public class Handler : IRequestHandler<Request, Response>
{
    public readonly IRepository _repository;

    public Handler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        // #region 01. Validar requisição
        // try
        // {
        //     var res = Specification.Ensure(request);
        //     if (!res.IsValid)
        //         return new Response("Requisição inválida", 400, res.Notifications);
        // }
        // catch
        // {
        //     return new Response("Não foi possível validar sua requisição", 500);
        // }

        // #endregion

        #region 02. Verificar se o depoimento existe e atualizar
        Testimonial? testimonial;
        try
        {
            testimonial = await _repository.GetOneAsync(request.Id, cancellationToken);
            if (testimonial is null)
                return new Response("Depoimento não encontrado", 404);

            testimonial.Update(request);
        }
        catch
        {
            return new Response("Não foi possível realizar a requisição", 500);
        }

        #endregion

        #region 04. Salvar no banco
        try
        {
            await _repository.UpdateAsync(testimonial, cancellationToken);
        }
        catch
        {
            return new Response("Falha ao persistir os dados", 500);
        }

        #endregion

        return new Response("Depoimento atualizado", new ResponseData(testimonial.Id, testimonial.Name, testimonial.Testimony, testimonial.Image));
    }
}
