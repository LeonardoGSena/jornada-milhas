using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Delete.Contracts;
using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Delete;

public class DeleteTestimonialdHandler : IRequestHandler<DeleteTestimonialByIdQuery, TestimonialResponse>
{
    private readonly IRepository _repository;

    public DeleteTestimonialdHandler(IRepository repository)
    {
        _repository = repository;
    }
    public async Task<TestimonialResponse> Handle(DeleteTestimonialByIdQuery request, CancellationToken cancellationToken)
    {
        #region 01. Verificar se o depoimento existe
        Testimonial? testimonial;
        try
        {
            testimonial = await _repository.GetTestimonialByIdAsync(request.Id, cancellationToken);
            if (testimonial is null)
                return new TestimonialResponse("Depoimento não encontrado", 404);
        }
        catch
        {
            return new TestimonialResponse("Não foi possível realizar a requisição", 500);
        }

        #endregion
        #region 03. Salvar no banco
        try
        {
            await _repository.DeleteAsync(testimonial, cancellationToken);
        }
        catch
        {
            return new TestimonialResponse("Falha ao persistir os dados", 500);
        }

        #endregion

        return new TestimonialResponse("Depoimento deletado com sucesso", new ResponseData(testimonial.Id, testimonial.Name, testimonial.Testimony));

    }
}
