namespace JornadaMilhas.Core.Contexts.SharedContext.Entities;

public abstract class Entity : IEquatable<Guid>
{
  protected Entity() => Id = new Guid();
  public Guid Id { get; }
  public bool Equals(Guid other) => Id == other;
  public override int GetHashCode() => Id.GetHashCode();
}
