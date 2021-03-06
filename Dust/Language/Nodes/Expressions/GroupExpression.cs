﻿using Dust.Language.Types;
using LanguageServer.Parameters;

namespace Dust.Language.Nodes.Expressions
{
  public class GroupExpression : Expression
  {
    public Expression Expression { get; }

    public override DustType Type => Expression.Type;

    public GroupExpression(Expression expression, Range range)
      : base(range)
    {
      Expression = expression;
    }
  }
}