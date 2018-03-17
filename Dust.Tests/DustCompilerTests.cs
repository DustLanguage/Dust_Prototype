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

    [Theory]
    [InlineData("1+2+3+4", 10)]
    [InlineData("12345*678*9", 75329190)]
    [InlineData("4+20+100", 124)]
    [InlineData("7.5*7.5", 56.25f)]
    [InlineData("4/20*100", 20f)]
    public static void Test_ParseSimpleMultipleArthimeticOperations(string input, int expected)
    {
      Assert.Equal(Compile(input), expected);
    }
    
  }
}