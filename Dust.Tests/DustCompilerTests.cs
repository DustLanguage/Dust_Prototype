using Antlr4.Runtime;
using Dust.Compiler;
using Dust.Language;
using Dust.Language.Nodes;
using Xunit;

namespace Dust.Tests
{
  public static class DustCompilerTests
  {
    private static object Compile(string input)
    {
      AntlrInputStream inputStream = new AntlrInputStream(input);
      DustLexer lexer = new DustLexer(inputStream);
      CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
      DustParser parser = new DustParser(commonTokenStream);
      DustVisitor visitor = new DustVisitor(new DustContext());

      DustRuntimeCompiler compiler = new DustRuntimeCompiler(new DustContext());

      return compiler.CompileModule((Module) visitor.VisitModule(parser.module()));
    }
  }
}