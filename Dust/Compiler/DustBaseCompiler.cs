using System.Linq;
using Dust.Language;
using Dust.Language.Nodes;
using Dust.Language.Nodes.Expressions;
using Dust.Language.Nodes.Statements;

namespace Dust.Compiler
{
  public abstract class DustBaseCompiler<T>
  {
    public virtual string Name { get; } = "";

    protected readonly DustContext CompilerContext;

    public DustBaseCompiler(DustContext compilerContext)
    {
      CompilerContext = compilerContext;
    }

    public virtual T CompileModule(Module module)
    {
      return default(T);
    }

    public virtual T CompileStatements(Statement[] statements)
    {
      return statements.Length == 0 ? default(T) : CombineStatements(statements.Select(CompileStatement).ToArray());
    }

    private T CompileStatement(Statement baseStatement)
    {
      switch (baseStatement)
      {
        case ExpressionStatement statement:
          return CompileExpressionStatement(statement);
        case ReturnStatement statement:
          return CompileReturnStatement(statement);
        case PropertyDeclaration statement:
          return CompilePropertyDeclaration(statement);
        case FunctionDeclaration statement:
          return CompileFunctionDeclaration(statement);
      }

      return default(T);
    }

    public T CompileExpression(Expression baseExpression)
    {
      switch (baseExpression)
      {
        case ArrayExpression expression:
          return CompileArrayExpression(expression);
        case BinaryExpression expression:
          return CompileBinaryExpression(expression);
        case UnaryExpression expression:
          return CompileUnaryExpression(expression);
        case CallExpression expression:
          return CompileCallExpression(expression);
        case IdentifierExpression expression:
          return CompileIdentifierExpression(expression);
        case LiteralExpression expression:
          return CompileLiteralExpression(expression);
        case AssignmentExpression expression:
          return CompileAssignmentExpression(expression);
        case TypeOfExpression expression:
          return CompileTypeOfExpression(expression);
        case GroupExpression expression:
          return CompileGroupExpression(expression);
      }

      return default(T);
    }

    #region Statements

    public T CompileExpressionStatement(ExpressionStatement statement)
    {
      return CompileExpression(statement.Expression);
    }

    protected abstract T CompileReturnStatement(ReturnStatement statement);
    protected abstract T CompilePropertyDeclaration(PropertyDeclaration statement);
    protected abstract T CompileFunctionDeclaration(FunctionDeclaration statement);

    #endregion

    #region Expressions

    protected abstract T CompileArrayExpression(ArrayExpression expression);
    protected abstract T CompileBinaryExpression(BinaryExpression expression);
    protected abstract T CompileUnaryExpression(UnaryExpression expression);
    protected abstract T CompileCallExpression(CallExpression expression);
    protected abstract T CompileIdentifierExpression(IdentifierExpression expression);
    protected abstract T CompileLiteralExpression(LiteralExpression expression);
    protected abstract T CompileAssignmentExpression(AssignmentExpression expression);
    protected abstract T CompileTypeOfExpression(TypeOfExpression expression);
    protected abstract T CompileGroupExpression(GroupExpression expression);

    #endregion

    protected abstract T CombineStatements(T[] returns);
  }
}