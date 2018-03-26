using LanguageServer.Parameters;

namespace Dust.Language.Errors
{
  public class SyntaxError : Error
  {
    public Range Range { get; }
    
    public SyntaxError(string message, Range range)
      : base(message)
    {
      Range = range;
    }

    public override string ToString()
    {
      return Range == null ? $"{nameof(SyntaxError)}: {Message}" : $"{nameof(SyntaxError)} at line {Range.Start.Line + 1} character {Range.Start.Character}: {Message}";
    }
  }
}