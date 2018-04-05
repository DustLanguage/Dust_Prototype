using LanguageServer.Parameters;

namespace Dust.Language.Nodes
{
  public class Node 
  {
    public Range Range { get; }

    public Node(Range range)
    {
      Range = range;
    }
  }
}