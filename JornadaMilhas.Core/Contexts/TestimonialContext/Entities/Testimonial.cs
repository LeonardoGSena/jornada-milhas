﻿using JornadaMilhas.Core.Contexts.SharedContext.Entities;
using JornadaMilhas.Core.Contexts.TestimonialContext.UseCases.Put;

namespace JornadaMilhas.Core.Contexts.TestimonialContext.Entities;

public class Testimonial : Entity
{
  protected Testimonial()
  {

  }
  public Testimonial(string name, string testimony, string image)
  {
    Name = name;
    Testimony = testimony;
    Image = image;
  }

  public string Name { get; private set; } = string.Empty;
  public string Testimony { get; private set; } = string.Empty;
  public string Image { get; private set; } = string.Empty;

  public void Update(UpdateTestimonialCommand request)
  {
    Name = request.TestimonialRequest.Name;
    Testimony = request.TestimonialRequest.Testimonial;
    Image = request.TestimonialRequest.Image;
  }
}
