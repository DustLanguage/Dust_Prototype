using System;
using System.Collections.Generic;
using Dust.Extensions;
using Dust.Language.Errors;
using Dust.Language.Nodes.Expressions;

namespace Dust.Language
{
  public class DustContext
  {
    public List<IdentifierExpression> Properties { get; } = new List<IdentifierExpression>();
    public List<Function> Functions { get; } = new List<Function>();

    public ErrorHandler ErrorHandler { get; }
    
    private readonly DustContext parent;

    public List<DustContext> Children { get; } = new List<DustContext>();

    public DustContext()
    {
      ErrorHandler = new ErrorHandler();
    }

    public DustContext(DustContext parent)
    {
      this.parent = parent;
      ErrorHandler = parent.ErrorHandler;
      
      parent.Children.Add(this);
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
      return GetProperty(name) != null;
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

      if (parent != null && parent != this)
      {
        foreach (DustContext context in parent.Children)
        {
          if (context != this)
          {
            action(context);            
          }
        }
      }
    }
  }
}