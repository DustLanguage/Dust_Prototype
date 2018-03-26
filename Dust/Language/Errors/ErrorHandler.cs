using System.Collections.Generic;
using System.Collections.Immutable;

namespace Dust.Language.Errors
{
  public class ErrorHandler
  {
    public ImmutableList<Error> Errors => errors.ToImmutableList();

    private readonly List<Error> errors = new List<Error>();

    public void ThrowError(Error error)
    {
      errors.Add(error);
    }

    public void Clear()
    {
      errors.Clear();
    }
  }
}