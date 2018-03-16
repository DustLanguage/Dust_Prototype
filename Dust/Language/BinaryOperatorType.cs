using System;

namespace Dust.Language
{
  public enum BinaryOperatorType
  {
    PLUS,
    MINUS,
    TIMES,
    DIVIDE,
    EQUAL,
    NOT_EQUAL,
    BIGGER,
    SMALLER,
    BIGGER_EQUAL,
    SMALLER_EQUAL
  }

  public static class BinaryOperatorTypeHelper
  {
    public static BinaryOperatorType FromString(string @operator)
    {
      switch (@operator)
      {
        case "+":
          return BinaryOperatorType.PLUS;
        case "-":
          return BinaryOperatorType.MINUS;
        case "*":
          return BinaryOperatorType.TIMES;
        case "/":
          return BinaryOperatorType.DIVIDE;
        case "==":
          return BinaryOperatorType.EQUAL;
        case "!=":
          return BinaryOperatorType.NOT_EQUAL;
        case ">":
          return BinaryOperatorType.BIGGER;
        case "<":
          return BinaryOperatorType.SMALLER;
        case ">=":
          return BinaryOperatorType.BIGGER_EQUAL;
        case "<=":
          return BinaryOperatorType.SMALLER_EQUAL;
        default:
          throw new Exception($"Cannot find BinaryOperatorType for {@operator}");
      }
    }

    public static string ToString(BinaryOperatorType type)
    {
      switch (type)
      {
        case BinaryOperatorType.PLUS:
          return "+";
        case BinaryOperatorType.MINUS:
          return "-";
        case BinaryOperatorType.TIMES:
          return "*";
        case BinaryOperatorType.DIVIDE:
          return "/";
        case BinaryOperatorType.EQUAL:
          return "==";
        case BinaryOperatorType.NOT_EQUAL:
          return "!=";
        case BinaryOperatorType.BIGGER:
          return ">";
        case BinaryOperatorType.SMALLER:
          return "<";
        case BinaryOperatorType.BIGGER_EQUAL:
          return ">=";
        case BinaryOperatorType.SMALLER_EQUAL:
          return "<=";
        default:
          throw new Exception($"Cannot find literal for {type} BinaryOperatorType");
      }
    }
  }
}