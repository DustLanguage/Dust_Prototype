using Dust.Language.Nodes.Expressions;
using LanguageServer.Parameters;

namespace Dust.Language.Nodes.Statements
{
  public class PropertyDeclaration : Statement
  {
    public Expression Initializer { get; }
    public IdentifierExpression Identifier { get; }

    public PropertyDeclaration(Expression initializer, IdentifierExpression identifier, Range range)
      : base(range)
    {
      Initializer = initializer;
      Identifier = identifier;
    }
  }
}