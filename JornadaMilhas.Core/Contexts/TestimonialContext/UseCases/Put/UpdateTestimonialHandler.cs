using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put.Contracts;
using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put;

public class UpdateTestimonialHandler : IRequestHandler<UpdateTestimonialCommand, TestimonialResponse>
{
    public readonly IRepository _repository;

    public UpdateTestimonialHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<TestimonialResponse> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
    {

        #region 01. Validar requisição
        try
        {
            var res = Specification.Ensure(request);
            if (!res.IsValid)
                return new TestimonialResponse("Requisição inválida", 400, res.Notifications);
        }
        catch
        {
            return new TestimonialResponse("Não foi possível validar sua requisição", 500);
        }

        #endregion

        #region 02. Verificar se o depoimento existe e atualizar
        Testimonial? testimonial;
        try
        {
            testimonial = await _repository.GetTestimonialByIdAsync(request.TestimonialRequest.Id, cancellationToken);
            if (testimonial is null)
                return new TestimonialResponse("Depoimento não encontrado", 404);

            testimonial.Update(request);
        }
        catch
        {
            return new TestimonialResponse("Não foi possível realizar a requisição", 500);
        }

        #endregion

        #region 03. Salvar no banco
        try
        {
            await _repository.UpdateAsync(testimonial, cancellationToken);
        }
        catch
        {
            return new TestimonialResponse("Falha ao persistir os dados", 500);
        }

        #endregion

        return new TestimonialResponse("Depoimento atualizado", new ResponseData(testimonial.Id, testimonial.Name, testimonial.Testimony, testimonial.Image));
    }
}
