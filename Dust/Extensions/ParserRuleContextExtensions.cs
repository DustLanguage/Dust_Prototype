using System.Text.RegularExpressions;
using Antlr4.Runtime;
using LanguageServer.Parameters;

namespace Dust.Extensions
{
  public static class ParserRuleContextExtensions
  {
    public static (int stopLine, int stopColumn) CalculateStop(this IToken token)
    {
      var match = Regex.Matches(token.Text, @"(\r\n|\r|\n)");

      int stopLine;
      int stopColumn;

      if (match.Count > 0)
      {
        stopLine = token.Line - 1 + match.Count;
        stopColumn = token.Column + token.Text.Length - (match[match.Count - 1].Index + match[match.Count - 1].Length);
      }
      else
      {
        stopLine = token.Line - 1;
        stopColumn = token.Column + token.Text.Length;
      }

      return (stopLine, stopColumn);
    }

    public static Range GetRange(this ParserRuleContext context)
    {
      (int stopLine, int stopCharacter) = context.Stop.CalculateStop();

      return new Range
      {
        Start = new Position {Line = context.Start.Line - 1, Character = context.Start.Column},
        End = new Position {Line = stopLine, Character = stopCharacter}
      };
    }
  }
}