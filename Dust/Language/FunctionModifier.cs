namespace Dust.Language
{
  public class FunctionModifier
  {
    public static FunctionModifier Public => new FunctionModifier();
    public static FunctionModifier Internal => new FunctionModifier();
    public static FunctionModifier Private => new FunctionModifier();

    public static FunctionModifier Parse(string text)
    {
      switch (text)
      {
        case "public":
          return Public;
        case "internal":
          return Internal;
        case "private":
          return Private;
      }

      return null;
    }
  }
}