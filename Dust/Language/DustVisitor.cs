using System.Collections.Generic;
using System.Linq;
using Dust.Extensions;
using Dust.Language.Exceptions;
using Dust.Language.Nodes;
using Dust.Language.Nodes.Expressions;
using Dust.Language.Nodes.Statements;

namespace Dust.Language
{
  public class DustVisitor : DustBaseVisitor<Node>
  {
    private readonly DustContext visitorContext;

    public DustVisitor(DustContext visitorContext)
    {
      this.visitorContext = visitorContext;
    }

    public override Node VisitModule(DustParser.ModuleContext context)
    {
      IEnumerable<Node> nodes = context.statement().Select(Visit);

      return new Module(nodes.Cast<Statement>());
    }

    public override Node VisitExpressionStatement(DustParser.ExpressionStatementContext context)
    {
      Expression expression = (Expression) Visit(context.expression());

      return new ExpressionStatement(expression);
    }

    public override Node VisitString(DustParser.StringContext context)
    {
      return LiteralExpression.ParseString(context.GetText());
    }

    public override Node VisitInt(DustParser.IntContext context)
    {
      return LiteralExpression.ParseInt(context.GetText());
    }

    public override Node VisitFloat(DustParser.FloatContext context)
    {
      return LiteralExpression.ParseFloat(context.GetText());
    }

    public override Node VisitBool(DustParser.BoolContext context)
    {
      return LiteralExpression.ParseBool(context.GetText());
    }

    public override Node VisitAdditionBinaryExpression(DustParser.AdditionBinaryExpressionContext context)
    {
      return CreateBinaryExpression(context, context.expression(0), "+", context.expression(1));
    }

    public override Node VisitSubstractionBinaryExpression(DustParser.SubstractionBinaryExpressionContext context)
    {
      return CreateBinaryExpression(context, context.expression(0), "-", context.expression(1));
    }

    public override Node VisitMultiplicationBinaryExpression(DustParser.MultiplicationBinaryExpressionContext context)
    {
      return CreateBinaryExpression(context, context.expression(0), "*", context.expression(1));
    }

    public override Node VisitDivisionBinaryExpression(DustParser.DivisionBinaryExpressionContext context)
    {
      return CreateBinaryExpression(context, context.expression(0), "/", context.expression(1));
    }

    public override Node VisitAdditionUnaryExpression(DustParser.AdditionUnaryExpressionContext context)
    {
      return CreateUnaryExpression(context, context.expression(), "++");
    }

    public override Node VisitSubstractionUnaryExpression(DustParser.SubstractionUnaryExpressionContext context)
    {
      return CreateUnaryExpression(context, context.expression(), "--");
    }

    public override Node VisitMultiplicationUnaryExpression(DustParser.MultiplicationUnaryExpressionContext context)
    {
      return CreateUnaryExpression(context, context.expression(), "**");
    }

    public override Node VisitDivisionUnaryExpression(DustParser.DivisionUnaryExpressionContext context)
    {
      return CreateUnaryExpression(context, context.expression(), "//");
    }

    public override Node VisitBangUnaryExpression(DustParser.BangUnaryExpressionContext context)
    {
      return CreateUnaryExpression(context, context.expression(), "!");
    }

    public override Node VisitEqualBinaryExpression(DustParser.EqualBinaryExpressionContext context)
    {
      return CreateBinaryExpression(context, context.expression(0), "==", context.expression(1));
    }

    public override Node VisitNotEqualBinaryExpression(DustParser.NotEqualBinaryExpressionContext context)
    {
      return CreateBinaryExpression(context, context.expression(0), "!=", context.expression(1));
    }

    public override Node VisitBiggerBinaryExpression(DustParser.BiggerBinaryExpressionContext context)
    {
      return CreateBinaryExpression(context, context.expression(0), ">", context.expression(1));
    }

    public override Node VisitSmallerBinaryExpression(DustParser.SmallerBinaryExpressionContext context)
    {
      return CreateBinaryExpression(context, context.expression(0), "<", context.expression(1));
    }

    public override Node VisitBiggerEqualBinaryExpression(DustParser.BiggerEqualBinaryExpressionContext context)
    {
      return CreateBinaryExpression(context, context.expression(0), ">=", context.expression(1));
    }

    public override Node VisitSmallerEqualBinaryExpression(DustParser.SmallerEqualBinaryExpressionContext context)
    {
      return CreateBinaryExpression(context, context.expression(0), "<=", context.expression(1));
    }

    public override Node VisitPropertyDeclaration(DustParser.PropertyDeclarationContext context)
    {
      Expression initializer = null;
      string name = context.identifierName().GetText();
      bool isMutable = context.declaration().GetText().Contains("mut");

      if (context.expression() != null)
      {
        initializer = (Expression) Visit(context.expression());
      }

      if (visitorContext.ContainsPropety(name))
      {
        throw new DustSyntaxErrorException($"Identifier '{name}' is already defined", context.identifierName().GetRange());
      }

      return new PropertyDeclaration(initializer, new IdentifierExpression(name, isMutable));
    }

    public override Node VisitFunctionParameter(DustParser.FunctionParameterContext context)
    {
      string name = context.parameterName().GetText();
      bool isMutable = context.GetText().Contains("mut");

      return new FunctionParameter(new IdentifierExpression(name, isMutable), null);
    }

    public override Node VisitFunctionDeclaration(DustParser.FunctionDeclarationContext context)
    {
      string name = context.functionDeclarationBase().functionName().identifierName().GetText();

      FunctionModifier[] modifiers = context.functionDeclarationBase().functionModifier().Select(modifierContext => FunctionModifier.Parse(modifierContext.GetText())).ToArray();
      FunctionParameter[] parameters = context.functionParameterList()?.functionParameter().Select(Visit).Cast<FunctionParameter>().ToArray();

      if (visitorContext.ContainsPropety(name))
      {
        throw new DustSyntaxErrorException($"Identifier '{name}' is already defined", context.functionDeclarationBase().functionName().GetRange());
      }

      for (int i = 0; i < parameters?.Length; i++)
      {
        if (visitorContext.ContainsPropety(parameters[i].Identifier.Name))
        {
          // Needs testing
          throw new DustSyntaxErrorException($"Identifier '{name}' is already defined", context.functionParameterList().functionParameter(i).GetRange());
        }
      }

      DustVisitor child = CreateChild(parameters ?? new FunctionParameter[0]);
      List<Statement> statements = new List<Statement>();

      DustType returnType = null;

      if (context.statementBlock() != null)
      {
        foreach (DustParser.StatementContext statementContext in context.statementBlock().statement())
        {
          Statement statement = (Statement) child.Visit(statementContext);

          if (statement is ReturnStatement returnStatement)
          {
            returnType = returnStatement.Expression.Type;
          }

          statements.Add(statement);
        }
      }

// let fn a {return 1}

      return new FunctionDeclaration(name, modifiers, parameters ?? new FunctionParameter[0], statements.ToArray(), returnType);
    }

    public override Node VisitReturnStatement(DustParser.ReturnStatementContext context)
    {
      Expression expression = (Expression) Visit(context.expression());

      return new ReturnStatement(expression);
    }

    public override Node VisitCallParameter(DustParser.CallParameterContext context)
    {
      string name = context.GetText();

      return new CallParameter(name);
    }

    public override Node VisitCallExpression(DustParser.CallExpressionContext context)
    {
      string name = context.functionName().GetText();
      CallParameter[] parameters = context.callParameterList().callParameter().Select(Visit).Cast<CallParameter>().ToArray();
      Function function = visitorContext.GetFunction(name);

      if (function.Parameters.Length != parameters.Length)
      {
        throw new DustSyntaxErrorException($"Function '{function.Name}' has {function.Parameters.Length} parameters but is called with {parameters.Length}", context.callParameterList().GetRange());
      }

      return new CallExpression(function, parameters);
    }

    public override Node VisitIdentifierExpression(DustParser.IdentifierExpressionContext context)
    {
      string name = context.GetText();
      IdentifierExpression property = visitorContext.GetProperty(name);

      if (property == null)
      {
        throw new DustSyntaxErrorException($"Identifier '{name}' is not defined", context.GetRange());
      }

      return property;
    }

    public override Node VisitTypeOfExpression(DustParser.TypeOfExpressionContext context)
    {
      Expression expression = (Expression) Visit(context.expression());

      return new TypeOfExpression(expression);
    }

    public override Node VisitGroupExpression(DustParser.GroupExpressionContext context)
    {
      Expression expression = (Expression) Visit(context.expression());

      return new GroupExpression(expression);
    }

    private DustVisitor CreateChild(FunctionParameter[] predefindProperties)
    {
      DustVisitor visitor = new DustVisitor(new DustContext(visitorContext));

      foreach (FunctionParameter property in predefindProperties)
      {
        visitor.visitorContext.AddProperty(property.Identifier, null);
      }

      return visitor;
    }

    private BinaryExpression CreateBinaryExpression(DustParser.ExpressionContext context, DustParser.ExpressionContext leftContext, string @operator, DustParser.ExpressionContext rightContext)
    {
      Expression left = (Expression) Visit(leftContext);
      Expression right = (Expression) Visit(rightContext);

      BinaryOperatorType operatorType = BinaryOperatorTypeHelper.FromString(@operator.ToString());

      switch (operatorType)
      {
        case BinaryOperatorType.EQUAL:
        case BinaryOperatorType.NOT_EQUAL:
        case BinaryOperatorType.BIGGER:
        case BinaryOperatorType.BIGGER_EQUAL:
        case BinaryOperatorType.SMALLER:
        case BinaryOperatorType.SMALLER_EQUAL:
          return new BinaryExpression(left, operatorType, right);
      }

      if (left.Type == DustType.Number && right.Type == DustType.Number)
      {
        switch (operatorType)
        {
          case BinaryOperatorType.PLUS:
          case BinaryOperatorType.MINUS:
          case BinaryOperatorType.TIMES:
          case BinaryOperatorType.DIVIDE:
            return new BinaryExpression(left, operatorType, right);
        }
      }

      // TODO: Make this look better
      if ((left.Type == DustType.String || left.Type == DustType.Number) && (right.Type == DustType.String || right.Type == DustType.Number))
      {
        switch (operatorType)
        {
          case BinaryOperatorType.PLUS:
          case BinaryOperatorType.TIMES:
            return new BinaryExpression(left, operatorType, right);
        }
      }

      throw new DustSyntaxErrorException($"Cannot apply operator '{BinaryOperatorTypeHelper.ToString(operatorType)}' to operands of type '{left.Type}' and '{right.Type}'", context.GetRange());
    }

    public override Node VisitAssignmentExpression(DustParser.AssignmentExpressionContext context)
    {
      Expression left = (Expression) Visit(context.expression(0));
      Expression right = (Expression) Visit(context.expression(1));

      if (!(left is IdentifierExpression))
      {
        throw new DustSyntaxErrorException("Assignment target must be a mutable property.", context.GetRange());
      }

      if (!((IdentifierExpression) left).IsMutable)
      {
        throw new DustSyntaxErrorException($"'{((IdentifierExpression) left).Name}' is not mutable.", context.GetRange());
      }

      return new AssignmentExpression(left, right);
    }

    private UnaryExpression CreateUnaryExpression(DustParser.ExpressionContext context, DustParser.ExpressionContext expressionContext, string @operator)
    {
      Expression expression = (Expression) Visit(expressionContext);

      UnaryOperatorType operatorType = UnaryOperatorTypeHelper.FromString(@operator);

      if (expression.Type == DustType.Number)
      {
        switch (operatorType)
        {
          case UnaryOperatorType.PLUS_PLUS:
          case UnaryOperatorType.MINUS_MINUS:
          case UnaryOperatorType.TIMES_TIMES:
          case UnaryOperatorType.DIVIDE_DIVIDE:
            return new UnaryExpression(expression, operatorType);
        }
      }

      if (expression.Type == DustType.Bool)
      {
        switch (operatorType)
        {
          case UnaryOperatorType.BANG:
            return new UnaryExpression(expression, operatorType);
        }
      }

      throw new DustSyntaxErrorException($"Cannot apply operator '{UnaryOperatorTypeHelper.ToString(operatorType)}' to operand of type '{expression.Type}'", context.GetRange());
    }
  }
}