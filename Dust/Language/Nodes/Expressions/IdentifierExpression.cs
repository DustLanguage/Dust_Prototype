using System;
using LanguageServer.Parameters;

namespace Dust.Language.Nodes.Expressions
{
  public class IdentifierExpression : Expression, IEquatable<IdentifierExpression>
  {
    public string Name { get; }
    public bool IsMutable { get; }

    public IdentifierExpression(string name, bool isMutable, Range range)
      : base(range)
    {
      Name = name;
      IsMutable = isMutable;
      Value = null; 
    }

    public bool Equals(IdentifierExpression other)
    {
      return Equals(Name, other.Name);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      return obj.GetType() == GetType() && Equals((IdentifierExpression) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ IsMutable.GetHashCode();
      }
    }
  }
}