using Antlr4.Runtime;

namespace Dust.Language
{
  public partial class DustParser
  {
    protected bool LineTerminatorAhead()
    {
      int index = CurrentToken.TokenIndex - 1;
      IToken tokenAhead = TokenStream.Get(index);

      while (tokenAhead.Type == WhiteSpace)
      {
        tokenAhead = TokenStream.Get(index--);
      }

      if (tokenAhead.Channel == Lexer.Hidden)
        return false;

      if (tokenAhead.Type == LineTerminator)
        return true;

      string text = tokenAhead.Text;

      return tokenAhead.Type == MultiLineComment && (text.Contains("\r") || text.Contains("\n"));
    }
  }
}