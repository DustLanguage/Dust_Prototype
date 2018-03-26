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
    public static void Test_ParseInt(string input, int expected)
    {
      Assert.Equal(ParseStatements(input), new ExpressionStatement(new LiteralExpression(expected)));
    }

    [Theory]
    [InlineData("10.0", 10.0f)]
    [InlineData("123456.123", 123456.123f)]
    [InlineData("+123.01", 123.01f)]
    [InlineData("-10.10", -10.10f)]
    [InlineData("-123456.123456", -123456.123456f)]
    public static void Test_ParseFloat(string input, float expected)
    {
      Assert.Equal(ParseStatements(input), new ExpressionStatement(new LiteralExpression(expected)));
    }

    [Theory]
    [InlineData("\"Expression\"", "Expression")]
    [InlineData("\'Sad Expression\'", "Sad Expression")]
    [InlineData("\"Dust File Syntax\"", "Dust File Syntax")]
    public static void Test_ParseString(string input, string expected)
    {
      Assert.Equal(ParseStatements(input), new ExpressionStatement(new LiteralExpression(expected)));
    }

    [Theory]
    [InlineData("true", true)]
    [InlineData("false", false)]
    public static void Test_ParseBoolean(string input, bool expected)
    {
      Assert.Equal(ParseStatements(input), new ExpressionStatement(new LiteralExpression(expected)));
    }

    [Theory]
    [InlineData("123+456")]
    [InlineData("45.6*32.1")]
    [InlineData("20.0/5.4")]
    [InlineData("1.0-1")]
    public static void Test_ParseArithmeticOperation(string input)
    {
      string currentValue = "", firstSide = "";
      foreach (char c in input)
      {
        if (c == '+' || c == '-' || c == '/' || c == '*')
        {
          var operatorType = BinaryOperatorTypeHelper.FromString(c.ToString());
          if (firstSide != "")
          {
            string secondSide = currentValue;
            float firstSideFloat = float.Parse(firstSide);
            float secondSideFloat = float.Parse(secondSide);
            Assert.Equal(ParseStatements(input), new ExpressionStatement(new BinaryExpression(new LiteralExpression(firstSideFloat),
              operatorType, new LiteralExpression(secondSideFloat))));
          }
          else
          {
            firstSide = currentValue;
          }

          currentValue = "";
        }

        currentValue += c;
      }
    }
  }
}