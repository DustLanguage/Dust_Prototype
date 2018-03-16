using System;
using System.Collections.Generic;
using Dust.Extensions;
using Dust.Language.Nodes.Expressions;

namespace Dust.Language
{
  public class DustContext
  {
    private readonly List<IdentifierExpression> properties = new List<IdentifierExpression>();
    private readonly List<Function> functions = new List<Function>();
    private readonly DustContext parent;


    private List<DustContext> children = new List<DustContext>();

    public DustContext()
    {
    }

    public DustContext(DustContext parent)
    {
      this.parent = parent;

      children.Add(this);
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
      properties.Remove(property);
      parent?.properties.Remove(property);
    }

    public void AddFunction(Function function)
    {
      _functions.Add(function);
    }

    public Function GetFunction(string name)
    {
      return functions.Get(element => element.Name == name) ?? parent?.functions.Get(element => element.Name == name);
    }

    public bool ContainsFunction(string name)
    {
      return GetFunction(name) != null;
    }


    public void DeleteFunction(Function function)
    {
      DoActionInChildren(context => context.DeleteFunction(function));
      functions.Remove(function);
    }

    private void DoActionInChildren(Action<DustContext> action)
    {
      foreach (DustContext context in children)
        action(context);

      foreach (DustContext context in parent?.children)
        action(context);
    }
  }
}