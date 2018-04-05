using Dust.Language.Nodes.Expressions;
using LanguageServer.Parameters;

namespace Dust.Language.Nodes
{
  public class FunctionParameter : Node
  {
    public IdentifierExpression Identifier { get; }
    public Expression Default { get; }

    public FunctionParameter(IdentifierExpression identifier, Expression @default, Range range)
      : base(range)
    {
      Identifier = identifier;
      Default = @default;
    }
  }
}