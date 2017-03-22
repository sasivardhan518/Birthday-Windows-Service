// Decompiled with JetBrains decompiler
// Type: InRhythm.DataAccess.Extensions
// Assembly: InRhythm.DataAccess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD09B139-0FA8-4017-9BC0-ED6261A4D8F3
// Assembly location: \\irs-dev-02\DevBuilds\1.9.8.3\1. MobileBIWeb\bin\InRhythm.DataAccess.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace InRhythm.DataAccess
{
  public static class Extensions
  {
    public static int AsId(this object item, int defaultId = -1)
    {
      int result;
      if (item == null || !int.TryParse(item.ToString(), out result))
        return defaultId;
      return result;
    }

    public static int AsInt(this object item, int defaultInt = 0)
    {
      int result;
      if (item == null || !int.TryParse(item.ToString(), out result))
        return defaultInt;
      return result;
    }

    public static double AsDouble(this object item, double defaultDouble = 0.0)
    {
      double result;
      if (item == null || !double.TryParse(item.ToString(), out result))
        return defaultDouble;
      return result;
    }

    public static string AsString(this object item, string defaultString = null)
    {
      if (item == null || item.Equals((object) DBNull.Value))
        return defaultString;
      return item.ToString().Trim();
    }

    public static DateTime AsDateTime(this object item, DateTime defaultDateTime)
    {
      DateTime result;
      if (item == null || string.IsNullOrEmpty(item.ToString()) || !DateTime.TryParse(item.ToString(), out result))
        return defaultDateTime;
      return result;
    }

    public static bool AsBool(this object item, bool defaultBool = false)
    {
      if (item == null)
        return defaultBool;
      List<string> stringList = new List<string>();
      stringList.Add("yes");
      stringList.Add("y");
      stringList.Add("true");
      string lower = item.ToString().ToLower();
      return stringList.Contains(lower);
    }

    public static string OrderBy(this string sql, string sortExpression)
    {
      if (string.IsNullOrEmpty(sortExpression))
        return sql;
      return sql + " ORDER BY " + sortExpression;
    }

    public static string CommaSeparate<T, U>(this IEnumerable<T> source, Func<T, U> func)
    {
      return string.Join(",", source.Select<T, string>((Func<T, string>) (s => func(s).ToString())).ToArray<string>());
    }
  }
}
