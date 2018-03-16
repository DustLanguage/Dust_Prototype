using System.Collections.Generic;
using System.Linq;
using Dust.Language.Nodes.Statements;

namespace Dust.Language.Nodes
{
  public class Module : Statement
  {
    public Statement[] Statements { get; }
    
    public Module(IEnumerable<Statement> statements)
    {
      Statements = statements.ToArray();
    }
  }
}