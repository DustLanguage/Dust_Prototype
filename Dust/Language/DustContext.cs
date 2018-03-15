using System.Collections.Generic;
using Dust.Extensions;
using Dust.Language.Nodes;
using Dust.Language.Nodes.Expressions;

namespace Dust.Language
{
  public class DustContext
  {
    private readonly List<IdentifierExpression> properties = new List<IdentifierExpression>();
    private readonly List<Function> functions = new List<Function>();
    private readonly DustContext parent;

    public DustContext()
    {
    }

    public DustContext(DustContext parent)
    {
      this.parent = parent;
    }

    public IdentifierExpression GetProperty(string name)
    {
      return properties.Get(element => element.Name == name);
    }

    public void AddProperty(IdentifierExpression property, object value)
    {
      property.Value = value;

      properties.Add(property);
    }

    public void SetProperty(IdentifierExpression property, object value)
    {
      properties.Get(property).Value = value;
    }

    public bool ContainsPropety(string name)
    {
      return GetProperty(name) != null;
    }

    public void DeleteProperty(IdentifierExpression property)
    {
      properties.Remove(property);
    }

    public void AddFunction(Function function)
    {
      functions.Add(function);
    }

    public Function GetFunction(string name)
    {
      return functions.Get(element => element.Name == name) ?? parent.functions.Get(element => element.Name == name);
    }

    public bool ContainsFunction(string name)
    {
      return GetFunction(name) != null;
    }

    public void DeleteFunction(Function function)
    {
      functions.Remove(function);
    }
  }
}