﻿namespace Dust.Language.Nodes.Expressions
{
  public class BinaryExpression : Expression
  {
    public Expression Left { get; }
    public BinaryOperatorType Operator { get; }
    public Expression Right { get; }

    public override DustType Type => Left.Type;

    public BinaryExpression(Expression left, BinaryOperatorType @operator, Expression right)
    {
      Left = left;
      Operator = @operator;
      Right = right;
    }

  }
}