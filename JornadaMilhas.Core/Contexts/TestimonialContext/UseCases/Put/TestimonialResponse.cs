using Flunt.Notifications;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put;

public class TestimonialResponse : JornadaMilhas.Core.Contexts.SharedContext.UseCases.Response
{
    public TestimonialResponse()
    {

    }

    public TestimonialResponse(string message, int status, IEnumerable<Notification>? notifications = null)
    {
        Message = message;
        Status = status;
        Notifications = notifications;
    }

    public TestimonialResponse(string message, ResponseData data)
    {
        Message = message;
        Status = 200;
        Notifications = null;
        Data = data;
    }
    public ResponseData? Data { get; set; }
}

public record ResponseData(Guid Id, string Name, string Testimony, string Image);
