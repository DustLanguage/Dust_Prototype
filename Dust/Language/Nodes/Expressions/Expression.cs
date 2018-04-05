using Dust.Language.Types;
using LanguageServer.Parameters;

namespace Dust.Language.Nodes.Expressions
{
  public abstract class Expression : Node
  {
    public virtual DustType Type => DustType.GetDustType(Value);

    public object Value { get; set; }

    protected Expression(Range range)
      : base(range)
    {
    }
  }
}