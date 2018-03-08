using System;

namespace Dust.Language.Nodes.Expressions
{
  public abstract class Expression : Node
  {
    public virtual DustType Type => DustType.GetDustType(Value);

    public object Value { get; set; }
  }
}