using System;
using System.Collections.Generic;
using Dust.Extensions;
using Dust.Language.Nodes.Expressions;

namespace Dust.Language
{
  public class DustContext
  {
    public List<IdentifierExpression> Properties { get; } = new List<IdentifierExpression>();
    public List<Function> Functions { get; } = new List<Function>();

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
      return Properties.Get(element => element.Name == name) ?? parent?.GetProperty(name);
    }

    public void AddProperty(IdentifierExpression property)
    {
      Properties.Add(property);
    }

    public void SetProperty(IdentifierExpression property, object value)
    {
      Properties.Get(property).Value = value;
    }

    public bool ContainsPropety(string name)
    {
      return Properties.Get(element => element.Name == name) != null;
    }

    public void DeleteProperty(IdentifierExpression property)
    {
      InvokeOnAllChildren(context => context.DeleteProperty(property));
      Properties.Remove(property);
    }

    public void AddFunction(Function function)
    {
      Functions.Add(function);
    }

    public Function GetFunction(string name)
    {
      return Functions.Get(element => element.Name == name) ?? parent?.Functions.Get(element => element.Name == name);
    }

    public bool ContainsFunction(string name)
    {
      return GetFunction(name) != null;
    }

    public void DeleteFunction(Function function)
    {
      InvokeOnAllChildren(context => context.DeleteFunction(function));
      Functions.Remove(function);
    }

    private void InvokeOnAllChildren(Action<DustContext> action)
    {
      foreach (DustContext context in children)
      {
        action(context);
      }

      if (parent != null)
      {
        foreach (DustContext context in parent.children)
        {
          action(context);
        }
      }
    }
  }
}