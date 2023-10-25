
using Flunt.Notifications;
using Flunt.Validations;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Create;

public static class Specification
{
    public static Contract<Notification> Ensure(CreateTestimonialCommand request)
    => new Contract<Notification>()
        .Requires()
        .IsLowerThan(request.TestimonialRequest.Name.Length, 101, "Name", "O nome deve ter no máximo 100 caracteres")
        .IsGreaterThan(request.TestimonialRequest.Name.Length, 2, "Name", "O nome deve ter no mínimo 3 caracteres")
        .IsLowerThan(request.TestimonialRequest.Testimony.Length, 501, "Testimony", "O depoimento deve ter no máximo 500 caracteres")
        .IsGreaterThan(request.TestimonialRequest.Testimony.Length, 2, "Testimony", "O depoimento deve ter no mínimo 3 caracteres")
        .IsNotEmpty(request.TestimonialRequest.Image, "Image")
        .IsNotNull(request.TestimonialRequest.Image, "Image");
}
