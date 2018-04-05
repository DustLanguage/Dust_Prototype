using Dust.Language.Types;
using LanguageServer.Parameters;

namespace Dust.Language.Nodes.Expressions
{
  public class UnaryExpression : Expression
  {
    public Expression Expression { get; }
    public UnaryOperatorType Operator { get; }

    public override DustType Type => Expression.Type;

    public UnaryExpression(Expression expression, UnaryOperatorType @operator, Range range)
      : base(range)
    {
      Expression = expression;
      Operator = @operator;
    }
}
}