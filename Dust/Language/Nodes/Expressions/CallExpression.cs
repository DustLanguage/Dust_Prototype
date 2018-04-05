using Dust.Language.Types;
using LanguageServer.Parameters;

namespace Dust.Language.Nodes.Expressions
{
  public class CallExpression : Expression
  {
    public Function Function { get; }
    public CallParameter[] Parameters { get; }
    public override DustType Type => Function.ReturnType;

    public CallExpression(Function function, CallParameter[] parameters, Range range)
      : base(range)
    {
      Function = function;
      Parameters = parameters;
    }
  }
}