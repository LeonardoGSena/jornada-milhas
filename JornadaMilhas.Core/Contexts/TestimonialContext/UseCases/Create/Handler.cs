using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create.Contracts;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create;

public class Handler
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(Request request)
    {
        #region 01. Validar requisicao

        #endregion

        #region 02. Gerar Objetos

        #endregion

        #region 03. Persistir dados

        #endregion

        return null;
    }
}
