
using Flunt.Notifications;
using Flunt.Validations;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create;

public static class Specification
{
    public static Contract<Notification> Ensure(Request request)
    => new Contract<Notification>()
        .Requires()
        .IsLowerThan(request.Name.Length, 101, "Name", "O nome deve ter no máximo 100 caracteres")
        .IsGreaterThan(request.Name.Length, 2, "Name", "O nome deve ter no mínimo 3 caracteres")
        .IsLowerThan(request.Testimony.Length, 501, "Testimony", "O depoimento deve ter no máximo 500 caracteres")
        .IsGreaterThan(request.Testimony.Length, 2, "Testimony", "O depoimento deve ter no mínimo 3 caracteres")
        .IsNotEmpty(request.Image, "Image");
}
