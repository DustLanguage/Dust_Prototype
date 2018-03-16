using Dust.Language.Nodes.Statements;
using Dust.Language.Types;

namespace Dust.Language.Nodes.Expressions
{
  public class Function : Expression
  {
    public string Name { get; }
    public FunctionModifier[] Modifiers { get; }
    public FunctionParameter[] Parameters { get; }
    public Statement[] Statements { get; }
    public DustType ReturnType { get; }

    public override DustType Type { get; }

    public Function(string name, FunctionModifier[] modifiers, FunctionParameter[] parameters, Statement[] statements, DustType returnType)
    {
      Name = name;
      Parameters = parameters;
      Modifiers = modifiers;
      Statements = statements;
      ReturnType = returnType;
      Type = returnType;
    }
  }
}