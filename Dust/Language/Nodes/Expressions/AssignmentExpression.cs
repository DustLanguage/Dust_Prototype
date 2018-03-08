// basket case

namespace Dust.Language.Nodes.Expressions
{
  public class AssignmentExpression : Expression
  {
    public Expression Left { get; }
    public Expression Right { get; }
    
    public AssignmentExpression(Expression left, Expression right)
    {
      Left = left;
      Right = right;
    }
  }
}