using System.Collections.Generic;
using System.Linq;
using Dust.Extensions;
using Dust.Language.Errors;
using Dust.Language.Nodes;
using Dust.Language.Nodes.Expressions;
using Dust.Language.Nodes.Statements;
using Dust.Language.Types;
using LanguageServer.Parameters;

namespace Dust.Language
{
  public class DustVisitor : DustBaseVisitor<Node>
  {
    private readonly DustContext visitorContext;

    public DustVisitor(DustContext visitorContext)
    {
      this.visitorContext = visitorContext;
      visitorContext.ErrorHandler.Clear();
    }

    public override Node VisitModule(DustParser.ModuleContext context)
    {
      IEnumerable<Node> nodes = context.statement().Select(Visit);

      return new Module(nodes.Cast<Statement>().ToArray(), context.GetRange());
    }

    public override Node VisitExpressionStatement(DustParser.ExpressionStatementContext context)
    {
      Expression expression = (Expression) Visit(context.expression());

      return new ExpressionStatement(expression, context.GetRange());
    }

    public override Node VisitString(DustParser.StringContext context)
    {
      return LiteralExpression.ParseString(context.GetText(), context.GetRange());
    }

    public override Node VisitInt(DustParser.IntContext context)
    {
      return LiteralExpression.ParseInt(context.GetText(), context.GetRange());
    }

    public override Node VisitFloat(DustParser.FloatContext context)
    {
      return LiteralExpression.ParseFloat(context.GetText(), context.GetRange());
    }

    public override Node VisitBool(DustParser.BoolContext context)
    {
      return LiteralExpression.ParseBool(context.GetText(), context.GetRange());
    }

    public override Node VisitBinaryExpression(DustParser.BinaryExpressionContext context)
    {
      return CreateBinaryExpression(context, context.expression(0), context.arithmeticOperator().GetText(), context.expression(1));
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

    public override Node VisitDeleteUnaryExpression(DustParser.DeleteUnaryExpressionContext context)
    {
      return CreateUnaryExpression(context, context.expression(), "delete");
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
        visitorContext.ErrorHandler.ThrowError(new SyntaxError($"Identifier '{name}' is already defined", context.identifierName().GetRange()));

        return null;
      }

      IdentifierExpression identifier = new IdentifierExpression(name, isMutable, context.identifierName().GetRange());

      visitorContext.AddProperty(identifier);

      return new PropertyDeclaration(initializer, identifier, context.GetRange());
    }

    public override Node VisitFunctionParameter(DustParser.FunctionParameterContext context)
    {
      string name = context.parameterName().GetText();
      bool isMutable = context.GetText().Contains("mut");

      return new FunctionParameter(new IdentifierExpression(name, isMutable, context.parameterName().GetRange()), null, context.GetRange());
    }

    public override Node VisitFunctionDeclaration(DustParser.FunctionDeclarationContext context)
    {
      string name = context.functionDeclarationBase().functionName().identifierName().GetText();

      FunctionModifier[] modifiers = context.functionDeclarationBase().functionModifier().Select(modifierContext => FunctionModifier.Parse(modifierContext.GetText())).ToArray();
      FunctionParameter[] parameters = context.functionParameterList()?.functionParameter().Select(Visit).Cast<FunctionParameter>().ToArray();

      if (visitorContext.ContainsPropety(name))
      {
        visitorContext.ErrorHandler.ThrowError(new SyntaxError($"Identifier '{name}' is already defined", context.functionDeclarationBase().functionName().GetRange()));

        return null;
      }

      for (int i = 0; i < parameters?.Length; i++)
      {
        if (visitorContext.ContainsPropety(parameters[i].Identifier.Name))
        {
          visitorContext.ErrorHandler.ThrowError(new SyntaxError($"Identifier '{name}' is already defined", context.functionParameterList().functionParameter(i).GetRange()));

          return null;
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

          if (statement is ReturnStatement)
          {
            // TODO: Fix the temporary HACK by creating a Type System.
            returnType = DustType.Number;
          }

          statements.Add(statement);
        }
      }

      FunctionDeclaration declaration = new FunctionDeclaration(name, modifiers, parameters ?? new FunctionParameter[0], statements.ToArray(), returnType, child.visitorContext, new Range
      {
        Start = context.GetRange().Start,
        End = context.functionDeclarationBase().functionName().GetRange().End
      });

      visitorContext.AddFunction(declaration.Function);

      return declaration;
    }

    public override Node VisitReturnStatement(DustParser.ReturnStatementContext context)
    {
      Expression expression = (Expression) Visit(context.expression());

      return new ReturnStatement(expression, context.GetRange());
    }

    public override Node VisitCallParameter(DustParser.CallParameterContext context)
    {
      return new CallParameter((Expression) Visit(context.expression()), context.GetRange());
    }

    public override Node VisitCallExpression(DustParser.CallExpressionContext context)
    {
      string name = context.functionName().GetText();
      CallParameter[] parameters = context.callParameterList().callParameter().Select(Visit).Cast<CallParameter>().ToArray();
      Function function = visitorContext.GetFunction(name);

      if (function == null)
      {
        visitorContext.ErrorHandler.ThrowError(new SyntaxError($"Function '{name}' is not defined", context.functionName().GetRange()));

        return null;
      }

      if (function.Parameters.Length != parameters.Length)
      {
        visitorContext.ErrorHandler.ThrowError(new SyntaxError($"Function '{function.Name}' has {function.Parameters.Length} parameters but is called with {parameters.Length}", context.callParameterList().GetRange()));

        return null;
      }

      return new CallExpression(function, parameters, context.GetRange());
    }

    public override Node VisitIdentifierExpression(DustParser.IdentifierExpressionContext context)
    {
      string name = context.GetText();
      IdentifierExpression property = visitorContext.GetProperty(name);
      Function function = visitorContext.GetFunction(name);

      if (property == null && function == null)
      {
        visitorContext.ErrorHandler.ThrowError(new SyntaxError($"Identifier '{name}' is not defined", context.GetRange()));

        return null;
      }

      if (property == null)
      {
        return function;
      }

      return property;
    }

    public override Node VisitTypeOfExpression(DustParser.TypeOfExpressionContext context)
    {
      Expression expression = (Expression) Visit(context.expression());

      return new TypeOfExpression(expression, context.GetRange());
    }

    public override Node VisitGroupExpression(DustParser.GroupExpressionContext context)
    {
      Expression expression = (Expression) Visit(context.expression());

      return new GroupExpression(expression, context.GetRange());
    }

    private DustVisitor CreateChild(FunctionParameter[] predefindProperties)
    {
      DustVisitor visitor = new DustVisitor(new DustContext(visitorContext));

      foreach (FunctionParameter property in predefindProperties)
      {
        // fixme
        visitor.visitorContext.AddProperty(property.Identifier);
      }

      return visitor;
    }

    private BinaryExpression CreateBinaryExpression(DustParser.ExpressionContext context, DustParser.ExpressionContext leftContext, string @operator, DustParser.ExpressionContext rightContext)
    {
      Expression left = (Expression) Visit(leftContext);
      Expression right = (Expression) Visit(rightContext);

      BinaryOperatorType operatorType = BinaryOperatorTypeHelper.FromString(@operator);

      switch (operatorType)
      {
        case BinaryOperatorType.EQUAL:
        case BinaryOperatorType.NOT_EQUAL:
        case BinaryOperatorType.BIGGER:
        case BinaryOperatorType.BIGGER_EQUAL:
        case BinaryOperatorType.SMALLER:
        case BinaryOperatorType.SMALLER_EQUAL:
          return new BinaryExpression(left, operatorType, right, context.GetRange());
      }

      if (left.Type == DustType.Number && right.Type == DustType.Number)
      {
        switch (operatorType)
        {
          case BinaryOperatorType.PLUS:
          case BinaryOperatorType.MINUS:
          case BinaryOperatorType.TIMES:
          case BinaryOperatorType.DIVIDE:
            return new BinaryExpression(left, operatorType, right, context.GetRange());
        }
      }

      // TODO: Make this look better
      if ((left.Type == DustType.String || left.Type == DustType.Number) && (right.Type == DustType.String || right.Type == DustType.Number))
      {
        switch (operatorType)
        {
          case BinaryOperatorType.PLUS:
          case BinaryOperatorType.TIMES:
            return new BinaryExpression(left, operatorType, right, context.GetRange());
        }
      }

      visitorContext.ErrorHandler.ThrowError(new SyntaxError($"Cannot apply operator '{BinaryOperatorTypeHelper.ToString(operatorType)}' to operands of type '{left.Type}' and '{right.Type}'", context.GetRange()));

      return null;
    }

    public override Node VisitAssignmentExpression(DustParser.AssignmentExpressionContext context)
    {
      Expression left = (Expression) Visit(context.expression(0));
      Expression right = (Expression) Visit(context.expression(1));

      if (!(left is IdentifierExpression))
      {
        visitorContext.ErrorHandler.ThrowError(new SyntaxError("Assignment target must be a mutable property.", context.GetRange()));

        return null;
      }

      if (!((IdentifierExpression) left).IsMutable)
      {
        visitorContext.ErrorHandler.ThrowError(new SyntaxError($"Property '{((IdentifierExpression) left).Name}' is not mutable.", context.GetRange()));

        return null;
      }

      return new AssignmentExpression(left, right, context.GetRange());
    }

    private UnaryExpression CreateUnaryExpression(DustParser.ExpressionContext context, DustParser.ExpressionContext expressionContext, string @operator)
    {
      Expression expression = (Expression) Visit(expressionContext);

      UnaryOperatorType operatorType = UnaryOperatorTypeHelper.FromString(@operator);

      if (expression is IdentifierExpression || expression is Function)
      {
        switch (operatorType)
        {
          case UnaryOperatorType.DELETE:
            return new UnaryExpression(expression, operatorType, context.GetRange());
        }
      }

      if (expression.Type == DustType.Number)
      {
        switch (operatorType)
        {
          case UnaryOperatorType.PLUS_PLUS:
          case UnaryOperatorType.MINUS_MINUS:
          case UnaryOperatorType.TIMES_TIMES:
          case UnaryOperatorType.DIVIDE_DIVIDE:
            return new UnaryExpression(expression, operatorType, context.GetRange());
        }
      }

      if (expression.Type == DustType.Bool)
      {
        switch (operatorType)
        {
          case UnaryOperatorType.BANG:
            return new UnaryExpression(expression, operatorType, context.GetRange());
        }
      }

      visitorContext.ErrorHandler.ThrowError(new SyntaxError($"Cannot apply operator '{UnaryOperatorTypeHelper.ToString(operatorType)}' to operand of type '{expression.Type}'", context.GetRange()));

      return null;
    }
  }
}