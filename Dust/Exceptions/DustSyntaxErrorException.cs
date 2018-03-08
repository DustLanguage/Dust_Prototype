using System;
using LanguageServer.Parameters;

namespace Dust.Language.Exceptions
{
  public class DustSyntaxErrorException : Exception
  {
    public Range Range { get; }    
    
    public DustSyntaxErrorException(string message, Range range)
      : base(message)
    {
      Range = range;
    }
  }
}