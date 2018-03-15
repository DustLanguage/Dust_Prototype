using Dust.Language.Nodes.Expressions;

namespace Dust.Language.Nodes.Statements
{
  public class ReturnStatement : Statement
  {
    public Expression Expression { get; }
    
    public ReturnStatement(Expression expression)
    {
      Expression = expression;
    }
  }
}