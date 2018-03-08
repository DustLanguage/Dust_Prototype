using System;
using System.Collections.Generic;

namespace Dust.Extensions
{
  public static class ListExtensions
  {
    public static T Get<T>(this List<T> list, Predicate<T> predicate)
    {
      return list.Find(predicate);
    }
    
    public static T Get<T>(this List<T> list, T item)
    {
      return list.Find(element => item.Equals(element));
    }
  }
}