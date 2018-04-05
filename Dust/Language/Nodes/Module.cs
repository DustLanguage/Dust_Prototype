using Dust.Language.Nodes.Statements;
using LanguageServer.Parameters;

namespace Dust.Language.Nodes
{
  public class Module : Node
  {
    public Statement[] Statements { get; }
    
    public Module(Statement[] statements, Range range)
      : base(range)
    {
      Statements = statements;
    }
  }
}