using System;

namespace Dust.Language
{
  public enum UnaryOperatorType
  {
    PLUS_PLUS,
    MINUS_MINUS,
    TIMES_TIMES,
    DIVIDE_DIVIDE
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
        default:
          throw new Exception($"Cannot find literal for {type} UnaryOperatorType");
      }
    }
  }
}