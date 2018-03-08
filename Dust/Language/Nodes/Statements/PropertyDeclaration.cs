using Dust.Language.Nodes.Expressions;

namespace Dust.Language.Nodes.Statements
{
  public class PropertyDeclaration : Statement
  {
    public Expression Initializer { get; }
    public IdentifierExpression Identifier { get; }

    public PropertyDeclaration(Expression initializer, IdentifierExpression identifier)
    {
      Initializer = initializer;
      Identifier = identifier;
    }
  }
}