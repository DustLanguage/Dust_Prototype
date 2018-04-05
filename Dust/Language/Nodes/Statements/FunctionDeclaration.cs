using Dust.Language.Nodes.Expressions;
using Dust.Language.Types;
using LanguageServer.Parameters;

namespace Dust.Language.Nodes.Statements
{
  public class FunctionDeclaration : Statement
  {
    public Function Function { get; }
 
    public FunctionDeclaration(string name, FunctionModifier[] modifiers, FunctionParameter[] parameters, Statement[] statements, DustType returnType, DustContext context, Range range)
      : base(range)
    {
      Function = new Function(name, modifiers, parameters, statements, returnType, context, range);
    }
  }
}