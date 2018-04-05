using System.Collections.Immutable;
using Dust.Language;
using Dust.Language.Errors;
using Dust.Language.Nodes;

namespace Dust.Compiler
{
  public class CompileResult<T>
  {
    public Module Module { get; }
    public DustContext GlobalContext { get; }
    public T Value { get; }
    public ImmutableList<Error> Errors => GlobalContext.ErrorHandler.Errors;

    public CompileResult(Module module, DustContext globalContext, T value)
    {
      Module = module;
      GlobalContext = globalContext;
      Value = value;
    }
  }
}