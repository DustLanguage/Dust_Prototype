using Dust.Language.Nodes.Expressions;

namespace Dust.Language.Nodes.Statements
{
  public class ExpressionStatement : Statement
  {
    public Expression Expression { get; }

    public ExpressionStatement(Expression expression)
    {
      Expression = expression;
    }

    protected bool Equals(ExpressionStatement other)
    {
      return Equals(Expression, other.Expression);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != GetType()) return false;
      return Equals((ExpressionStatement) obj);
    }

    public override int GetHashCode()
    {
      return (Expression != null ? Expression.GetHashCode() : 0);
    }
  }
}