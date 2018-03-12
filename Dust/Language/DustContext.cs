using System.Collections.Generic;
using Dust.Extensions;
using Dust.Language.Nodes.Expressions;

namespace Dust.Language
{
  public class DustContext
  {
    private readonly List<IdentifierExpression> properties;

    public DustContext()
    {
      properties = new List<IdentifierExpression>();
    }

    public DustContext(DustContext parent)
    {
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
  }
}