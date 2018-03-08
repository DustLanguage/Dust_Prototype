using Antlr4.Runtime;
using LanguageServer.Parameters;

namespace Dust.Extensions
{
  public static class ParserRuleContextExtensions
  {
    public static Range GetRange(this ParserRuleContext context)
    {
      return new Range
      {
        start = new Position {line = context.Start.Line - 1, character = context.Start.Column},
        end = new Position {line = context.Stop.Line - 1, character = context.Stop.Column}
      };
    }
  }
}