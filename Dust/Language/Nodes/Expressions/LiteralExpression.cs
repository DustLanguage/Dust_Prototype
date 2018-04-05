using System;
using System.Globalization;
using LanguageServer.Parameters;

namespace Dust.Language.Nodes.Expressions
{
  public class LiteralExpression : Expression
  {
    public LiteralExpression(object value, Range range)
      : base(range)
    {
      Value = value;
    }

    public static LiteralExpression ParseString(string text, Range range)
    {
      text = text.Substring(1, text.Length - 2);
      
      return new LiteralExpression(text, range);
    }

    public static LiteralExpression ParseInt(string text, Range range)
    {
      if (!int.TryParse(text, out int number))
      {
        throw new Exception($"Could not parse int {text}");
      }

      return new LiteralExpression(number, range);
    }

    public static LiteralExpression ParseFloat(string text, Range range)
    {
      if (!float.TryParse(text, NumberStyles.Any, CultureInfo.CurrentUICulture, out float number))
      {
        throw new Exception($"Could not parse float {text}");
      }

      return new LiteralExpression(number, range);
    }

    public static LiteralExpression ParseBool(string text, Range range)
    {
      if (!bool.TryParse(text, out bool value))
      {
        throw new Exception($"Could not parse float {text}");
      }

      return new LiteralExpression(value, range);
    }

    protected bool Equals(LiteralExpression other)
    {
      return Equals(Value, other.Value);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      return obj.GetType() == GetType() && Equals((LiteralExpression) obj);
    }

    public override int GetHashCode()
    {
      return (Value != null ? Value.GetHashCode() : 0);
    }
  }
}