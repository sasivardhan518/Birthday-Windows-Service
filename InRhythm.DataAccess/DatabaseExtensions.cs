// Decompiled with JetBrains decompiler
// Type: InRhythm.DataAccess.DatabaseExtensions
// Assembly: InRhythm.DataAccess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD09B139-0FA8-4017-9BC0-ED6261A4D8F3
// Assembly location: \\irs-dev-02\DevBuilds\1.9.8.3\1. MobileBIWeb\bin\InRhythm.DataAccess.dll

using System;
using System.Data.Common;

namespace InRhythm.DataAccess
{
  public static class DatabaseExtensions
  {
    public static void AddParameters(this DbCommand command, object[] parms)
    {
      if (parms == null || (uint) parms.Length <= 0U)
        return;
      int index = 0;
      while (index < parms.Length)
      {
        string str = parms[index].ToString();
        if (parms[index + 1] is string && (string) parms[index + 1] == "")
          parms[index + 1] = (object) null;
        object obj = parms[index + 1] ?? (object) DBNull.Value;
        DbParameter parameter = command.CreateParameter();
        parameter.ParameterName = str;
        parameter.Value = obj;
        command.Parameters.Add((object) parameter);
        index += 2;
      }
    }
  }
}
