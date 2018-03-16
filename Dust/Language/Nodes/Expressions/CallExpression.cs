using Dust.Language.Types;

namespace Dust.Language.Nodes.Expressions
{
  public class CallExpression : Expression
  {
    public Function Function { get; }
    public CallParameter[] Parameters { get; }
    public override DustType Type => Function.ReturnType;

    public CallExpression(Function function, CallParameter[] parameters)
    {
      Function = function;
      Parameters = parameters;
    }
  }
}