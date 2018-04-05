// basket case

using LanguageServer.Parameters;

namespace Dust.Language.Nodes.Expressions
{
  public class AssignmentExpression : Expression
  {
    public Expression Left { get; }
    public Expression Right { get; }
    
    public AssignmentExpression(Expression left, Expression right, Range range)
      : base(range)
    {
      Left = left;
      Right = right;
    }
  }
}