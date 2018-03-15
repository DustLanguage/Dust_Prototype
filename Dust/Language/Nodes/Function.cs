using Dust.Language.Nodes.Expressions;

namespace Dust.Language.Nodes
{
  public class Function
  {
    public string Name { get; }
    public FunctionModifier[] Modifiers { get; }
    public FunctionParameter[] Parameters { get; }
    public Statement[] Statements { get; }
    public DustType ReturnType { get; }

    public Function(string name, FunctionModifier[] modifiers, FunctionParameter[] parameters, Statement[] statements, DustType returnType)
    {
      Name = name;
      Parameters = parameters;
      Modifiers = modifiers;
      Statements = statements;
      ReturnType = returnType;
    }
  }
}