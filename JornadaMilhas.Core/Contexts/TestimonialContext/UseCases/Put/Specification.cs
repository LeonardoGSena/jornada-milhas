using Flunt.Notifications;
using Flunt.Validations;


namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put;

public static class Specification
{
    public static Contract<Notification> Ensure(UpdateTestimonialCommand request)
     => new Contract<Notification>()
        .Requires()
        .IsNotEmpty(request.TestimonialRequest.Id, "Id")
        .IsNotNull(request.TestimonialRequest.Id, "Id")
        .IsLowerThan(request.TestimonialRequest.Name.Length, 101, "Name", "O nome deve ter no máximo 100 caracteres")
        .IsGreaterThan(request.TestimonialRequest.Name.Length, 2, "Name", "O nome deve ter no mínimo 3 caracteres")
        .IsLowerThan(request.TestimonialRequest.Testimonial.Length, 501, "Testimony", "O depoimento deve ter no máximo 500 caracteres")
        .IsGreaterThan(request.TestimonialRequest.Testimonial.Length, 2, "Testimony", "O depoimento deve ter no mínimo 3 caracteres");
}
