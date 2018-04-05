using Dust.Language.Types;
using LanguageServer.Parameters;

namespace Dust.Language.Nodes.Expressions
{
  public class ArrayExpression : Expression
  {
    // Make this type array
    public override DustType Type => DustType.Array;

    public ArrayExpression(Range range)
      : base(range)
    {
    }
  }
}