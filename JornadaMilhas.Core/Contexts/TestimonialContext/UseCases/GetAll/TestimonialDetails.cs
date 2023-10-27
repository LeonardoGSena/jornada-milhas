namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.GetAll;

public class TestimonialDetails
{
    public Guid Id { get; set; }
    public string Testimonial { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
}