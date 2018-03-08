namespace Dust.Language.Nodes.Expressions
{
  public class ArrayExpression : Expression
  {
    // Make this type array
    public override DustType Type => DustType.Array;
  }
}