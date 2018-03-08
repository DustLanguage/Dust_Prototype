namespace Dust.Language.Nodes.Expressions
{
  public class UnaryExpression : Expression
  {
    public Expression Expression { get; }
    public UnaryOperatorType Operator { get; }

    public override DustType Type => Expression.Type;

    public UnaryExpression(Expression expression, UnaryOperatorType @operator)
    {
      Expression = expression;
      Operator = @operator;
    }
}
}