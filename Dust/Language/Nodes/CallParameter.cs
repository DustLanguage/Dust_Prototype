namespace Dust.Language.Nodes.Expressions
{
  public class CallParameter : Node
  {
    public string Name { get; }
    
    public CallParameter(string name)
    {
      Name = name;
    }
  }
}