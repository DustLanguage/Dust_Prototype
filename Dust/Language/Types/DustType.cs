using System;
using Dust.Language.Nodes;
using Dust.Language.Nodes.Expressions;

namespace Dust.Language
{
  public class DustType : IEquatable<DustType>
  {
    public static DustType Object => new DustType("object", isRoot: true);
    public static DustType Number => new DustType("number", Object, true);
    public static DustType String => new DustType("string", Object);
    public static DustType Bool => new DustType("bool", Object);
    public static DustType Int => new DustType("int", Number);
    public static DustType Float => new DustType("float", Number);
    public static DustType Array => new DustType("array", Object);

    public string Name { get; }
    public DustType Parent { get; }
    public DustType Root { get; }
    public bool IsRoot { get; }

    public DustType(string name, DustType parent = null, bool isRoot = false)
    {
      Name = name;
      Parent = parent;
      Root = isRoot ? this : parent.Root;
      IsRoot = isRoot;
    }

    public static bool operator ==(DustType left, DustType right)
    {
      if (right.IsRoot)
      {
        return left.Name == right.Name || left.Root.Name == right.Name || left.Root.Name == right.Root.Name || left.Name == right.Root.Name;
      }

      return left.Name == right.Name;
    }

    public static bool operator !=(DustType left, DustType right)
    {
      if (right.IsRoot)
      {
        return left.Name != right.Name || left.Root.Name != right.Name || left.Root.Name != right.Root.Name || left.Name != right.Root.Name;
      }

      return left.Name != right.Name;
    }

    public static DustType GetDustType(object @object)
    {
      switch (@object)
      {
        case string _:
          return String;
        case int _:
          return Int;
        case float _:
          return Float;
        case bool _:
          return Bool;
        default:
          throw new Exception($"Could not find type for {@object.GetType()}");
      }
    }

    public static bool CheckNodeDustType(Node node1, Node node2)
    {
      if (node1.GetType() != node2.GetType())
      {
        throw new Exception("Nodes are not of the same type");
      }

      switch (node1)
      {
        //This will probably break with non-literal expressions
        case LiteralExpression expression:
          return expression.Type == ((LiteralExpression) node2).Type;
        default:
          throw new Exception($"Cannot check type for {node1.GetType()}");
      }
    }

    public bool Equals(DustType other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return string.Equals(Name, other.Name) && Equals(Parent, other.Parent);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      return obj.GetType() == GetType() && Equals((DustType) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Parent != null ? Parent.GetHashCode() : 0);
      }
    }

    public override string ToString()
    {
      return Name;
    }
  }
}