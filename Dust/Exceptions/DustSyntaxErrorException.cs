﻿using System;
using LanguageServer.Parameters;

namespace Dust.Exceptions
{
  public class DustSyntaxErrorException : Exception
  {
    public Range Range { get; }    
    
    public DustSyntaxErrorException(string message, Range range)
      : base($"{range.Start.Line}:{range.Start.Character} {message}")
    {
      Range = range;
    }
  }
}