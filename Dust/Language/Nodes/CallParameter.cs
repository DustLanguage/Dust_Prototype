using Dust.Language.Nodes.Expressions;
using LanguageServer.Parameters;

namespace Dust.Language.Nodes
{
  public class CallParameter : Node
  {
    public Expression Expression { get; }
    
    public CallParameter(Expression expression, Range range)
      : base(range)
    {
      Expression = expression;
    }
  }
}