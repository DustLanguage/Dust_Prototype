using System.Linq;
using Antlr4.Runtime;
using Dust.Language;
using Dust.Language.Nodes;
using Dust.Language.Nodes.Expressions;
using Dust.Language.Nodes.Statements;
using Xunit;

namespace Dust.Tests
{
  public static class DustVisitorTests
  {
    private static Statement ParseStatements(string input)
    {
      AntlrInputStream inputStream = new AntlrInputStream(input);
      DustLexer lexer = new DustLexer(inputStream);
      CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
      DustParser parser = new DustParser(commonTokenStream);
      DustVisitor visitor = new DustVisitor(new DustContext());

      return ((Module) visitor.VisitModule(parser.module())).Statements.First();
    }

    [Theory]
    [InlineData("10", 10)]
    [InlineData("123456", 123456)]
    [InlineData("+123", 123)]
    [InlineData("-10", -10)]
    [InlineData("-123456", -123456)]
    public static void Test_PraseInt(string input, int expected)
    {
      Assert.Equal(ParseStatements(input), new ExpressionStatement(new LiteralExpression(expected)));
    }
    
    [Theory]
    [InlineData("10.0", 10.0f)]
    [InlineData("123456.123", 123456.123f)]
    [InlineData("+123.01", 123.01f)]
    [InlineData("-10.10", -10.10f)]
    [InlineData("-123456.123456", -123456.123456f)]
    public static void Test_ParsePositiveFloat(string input, float expected)
    {
      Assert.Equal(ParseStatements(input), new ExpressionStatement(new LiteralExpression(expected)));
    }

    /*[Theory]
    [InlineData("1+1", new ExpressionStatement(new BinaryExpression(new LiteralExpression(1), '+', new LiteralExpression(1))))]
    public static void Test_ParseArthimeticOperation(string input, ExpressionStatement expected)
    {
      Assert.Equal(ParseStatements(input), expected);
    }*/
  }
}