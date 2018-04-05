using Dust.Language.Types;
using LanguageServer.Parameters;

namespace Dust.Language.Nodes.Expressions
{
  public class BinaryExpression : Expression
  {
    public Expression Left { get; }
    public BinaryOperatorType Operator { get; }
    public Expression Right { get; }

    public override DustType Type
    {
      get
      {
        if (Left.Type == DustType.Float || Right.Type == DustType.Float)
        {
          return DustType.Float;
        }
        
        return DustType.Int;
      }
    }

    public BinaryExpression(Expression left, BinaryOperatorType @operator, Expression right, Range range)
      : base(range)
    {
      Left = left;
      Operator = @operator;
      Right = right;
    }
  }
}