using Dust.Language.Nodes.Expressions;
using LanguageServer.Parameters;

namespace Dust.Language.Nodes.Statements
{
  public class ReturnStatement : Statement
  {
    public Expression Expression { get; }
    
    public ReturnStatement(Expression expression, Range range)
      : base(range)
    {
      Expression = expression;
    }
  }
}