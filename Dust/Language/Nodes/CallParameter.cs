using Dust.Language.Nodes.Expressions;

namespace Dust.Language.Nodes
{
  public class CallParameter : Node
  {
    public Expression Expression { get; }
    
    public CallParameter(Expression expression)
    {
      Expression = expression;
    }
  }
}