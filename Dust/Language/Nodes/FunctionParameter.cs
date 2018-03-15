namespace Dust.Language.Nodes.Expressions
{
  public class FunctionParameter : Node
  {
    public IdentifierExpression Identifier { get; }
    public Expression Default { get; }

    public FunctionParameter(IdentifierExpression identifier, Expression @default)
    {
      Identifier = identifier;
      Default = @default;
    }
  }
}