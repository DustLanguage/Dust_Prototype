namespace Dust.Language.Errors
{
  public class Error
  {
    public string Message { get; }

    protected Error(string message)
    {
      Message = message;
    }

    public override string ToString()
    {
      return Message;
    }
  }
}