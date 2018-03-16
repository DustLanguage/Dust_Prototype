namespace Dust.Language.Nodes
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