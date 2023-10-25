using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create.Contracts;
using MediatR;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create;

public class CreateTestimonialHandler : IRequestHandler<CreateTestimonialCommand, TestimonialResponse>
{
    private readonly IRepository _repository;

    public CreateTestimonialHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<TestimonialResponse> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
    {
        #region 01. Validar requisicao
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

        #region 02. Gerar Objetos
        Testimonial testimonial;
        try
        {
            testimonial = new Testimonial(request.TestimonialRequest.Name, request.TestimonialRequest.Testimonial, request.TestimonialRequest.Image);
        }
        catch
        {
            return new TestimonialResponse("Não foi possível criar o depoimento", 500);
        }
        #endregion

        #region 03. Persistir dados
        try
        {
            await _repository.SaveAsync(testimonial, cancellationToken);
        }
        catch
        {
            return new TestimonialResponse("Falha ao persistir dados", 500);
        }
        #endregion

        return new TestimonialResponse("Depoimento criado", new ResponseData(testimonial.Id, testimonial.Name, testimonial.Testimony));
    }


}

