using System.Collections.Generic;
using Dust.Extensions;
using Dust.Language.Nodes.Expressions;

namespace Dust.Language
{
  public class DustContext
  {
    private readonly List<IdentifierExpression> _properties = new List<IdentifierExpression>();
    private readonly List<Function> _functions = new List<Function>();
    private readonly DustContext _parent;

    public DustContext()
    {
    }

    public DustContext(DustContext parent)
    {
      _parent = parent;
    }

    public IdentifierExpression GetProperty(string name)
    {
      return _properties.Get(element => element.Name == name);
    }

    public void AddProperty(IdentifierExpression property, object value)
    {
      property.Value = value;

      _properties.Add(property);
    }

    public void SetProperty(IdentifierExpression property, object value)
    {
      _properties.Get(property).Value = value;
    }

    public bool ContainsPropety(string name)
    {
      return GetProperty(name) != null;
    }

    public void DeleteProperty(IdentifierExpression property)
    {
      _properties.Remove(property);
    }

    public void AddFunction(Function function)
    {
      _functions.Add(function);
    }

    public Function GetFunction(string name)
    {
      return _functions.Get(element => element.Name == name) ?? _parent._functions.Get(element => element.Name == name);
    }

    public bool ContainsFunction(string name)
    {
      return GetFunction(name) != null;
    }

    public void DeleteFunction(Function function)
    {
      _functions.Remove(function);
    }
  }
}