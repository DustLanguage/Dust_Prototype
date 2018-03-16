using System;

namespace Dust.Language
{
  public enum UnaryOperatorType
  {
    PLUS_PLUS,
    MINUS_MINUS,
    TIMES_TIMES,
    DIVIDE_DIVIDE,
    BANG,
    DELETE
  }

  public static class UnaryOperatorTypeHelper
  {
    public static UnaryOperatorType FromString(string @operator)
    {
      switch (@operator)
      {
        case "++":
          return UnaryOperatorType.PLUS_PLUS;
        case "--":
          return UnaryOperatorType.MINUS_MINUS;
        case "**":
          return UnaryOperatorType.TIMES_TIMES;
        case "//":
          return UnaryOperatorType.DIVIDE_DIVIDE;
        case "!":
          return UnaryOperatorType.BANG;
        case "delete":
          return UnaryOperatorType.DELETE;
        default:
          throw new Exception($"Cannot find UnaryOperatorType for {@operator}");
      }
    }

    public static string ToString(UnaryOperatorType type)
    {
      switch (type)
      {
        case UnaryOperatorType.PLUS_PLUS:
          return "++";
        case UnaryOperatorType.MINUS_MINUS:
          return "--";
        case UnaryOperatorType.TIMES_TIMES:
          return "**";
        case UnaryOperatorType.DIVIDE_DIVIDE:
          return "//";
        case UnaryOperatorType.BANG:
          return "!";
        case UnaryOperatorType.DELETE:
          return "delete";
        default:
          throw new Exception($"Cannot find literal for {type} UnaryOperatorType");
      }
    }
  }
}