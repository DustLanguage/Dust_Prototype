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
        Start = new Position {Line = context.Start.Line - 1, Character = context.Start.Column},
        End = new Position {Line = context.Stop.Line - 1, Character = context.Stop.Column}
      };
    }
  }
}