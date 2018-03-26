using System;
using System.Globalization;

namespace Dust.Language.Nodes.Expressions
{
  public class LiteralExpression : Expression
  {
    public LiteralExpression(object value)
    {
      Value = value;
    }

    public static LiteralExpression ParseString(string text)
    {
      text = text.Substring(1, text.Length - 2);

      return new LiteralExpression(text);
    }

    public static LiteralExpression ParseInt(string text)
    {
      if (!int.TryParse(text, out int number))
      {
        throw new Exception($"Could not parse int {text}");
      }

      return new LiteralExpression(number);
    }

    public static LiteralExpression ParseFloat(string text)
    {
      if (!float.TryParse(text, NumberStyles.Any, CultureInfo.CurrentUICulture, out float number))
      {
        throw new Exception($"Could not parse float {text}");
      }

      return new LiteralExpression(number);
    }

    public static LiteralExpression ParseBool(string text)
    {
      if (!bool.TryParse(text, out bool value))
      {
        throw new Exception($"Could not parse float {text}");
      }

      return new LiteralExpression(value);
    }

    protected bool Equals(LiteralExpression other)
    {
      return Equals(Value, other.Value);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != GetType()) return false;
      return Equals((LiteralExpression) obj);
    }

    public override int GetHashCode()
    {
      return (Value != null ? Value.GetHashCode() : 0);
    }
  }
}