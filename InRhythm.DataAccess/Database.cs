// Decompiled with JetBrains decompiler
// Type: InRhythm.DataAccess.Database
// Assembly: InRhythm.DataAccess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD09B139-0FA8-4017-9BC0-ED6261A4D8F3
// Assembly location: \\irs-dev-02\DevBuilds\1.9.8.3\1. MobileBIWeb\bin\InRhythm.DataAccess.dll

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace InRhythm.DataAccess
{
  public class Database
  {
    private static DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
    private DbProviderFactory instanceDbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
    private static string connectionString;
    private string instanceConnectionString;

    public Database(string conn = null)
    {
      if (conn == null)
        return;
      this.instanceConnectionString = ConfigurationManager.ConnectionStrings[conn].ConnectionString;
    }

    public static void SetDbProvider(string providerName)
    {
      Database.dbProviderFactory = DbProviderFactories.GetFactory(providerName);
    }

    public static void SetConnectionString(string _connectionString)
    {
      Database.connectionString = _connectionString;
    }

    public static void SetConnectionStringFromConfig(string connectionName)
    {
      Database.connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
    }

    public void SetInstanceConnectionString(string connection)
    {
      this.instanceConnectionString = connection;
    }

    public void SetInstanceConnectionStringFromConfig(string connectionName)
    {
      this.instanceConnectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
    }

    public void SetInstanceDbProvider(string providerName)
    {
      this.instanceDbProviderFactory = DbProviderFactories.GetFactory(providerName);
    }

    public IEnumerable<T> Read<T>(string sql, Func<IDataReader, T> make, params object[] parms)
    {
      DbConnection connection = this.CreateConnection();
      try
      {
        DbCommand command = this.CreateCommand(sql, connection, parms);
        try
        {
          DbDataReader reader = command.ExecuteReader();
          try
          {
            while (reader.Read())
              yield return make((IDataReader) reader);
          }
          finally
          {
            if (reader != null)
              reader.Dispose();
          }
          reader = (DbDataReader) null;
        }
        finally
        {
          if (command != null)
            command.Dispose();
        }
        command = (DbCommand) null;
      }
      finally
      {
        if (connection != null)
          connection.Dispose();
      }
      connection = (DbConnection) null;
    }

    public IEnumerable<T> Read<T>(DataTable dataTable, Func<DataRow, T> make)
    {
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        DataRow dataRow = row;
        yield return make(dataRow);
        dataRow = (DataRow) null;
      }
    }

    public DataSet ReadDataSet(string storedProcudureName, params object[] parms)
    {
      using (DbConnection connection = this.CreateConnection())
      {
        using (DbCommand command = this.CreateCommand(storedProcudureName, connection, parms))
        {
          command.CommandType = CommandType.StoredProcedure;
          using (DbDataAdapter adapter = this.CreateAdapter(command))
          {
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return dataSet;
          }
        }
      }
    }

    public DataSet Execute(string sql, params object[] parms)
    {
      using (DbConnection connection = this.CreateConnection())
      {
        using (DbCommand command = this.CreateCommand(sql, connection, parms))
        {
          command.CommandType = CommandType.Text;
          using (DbDataAdapter adapter = this.CreateAdapter(command))
          {
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return dataSet;
          }
        }
      }
    }

    public object Scalar(string sql, params object[] parms)
    {
      using (DbConnection connection = this.CreateConnection())
      {
        using (DbCommand command = this.CreateCommand(sql, connection, parms))
          return command.ExecuteScalar();
      }
    }

    public int Insert(string sql, params object[] parms)
    {
      using (DbConnection connection = this.CreateConnection())
      {
        using (DbCommand command = this.CreateCommand(sql, connection, parms))
          return command.ExecuteNonQuery();
      }
    }

    public int Update(string sql, params object[] parms)
    {
      using (DbConnection connection = this.CreateConnection())
      {
        using (DbCommand command = this.CreateCommand(sql, connection, parms))
          return command.ExecuteNonQuery();
      }
    }

    public int Delete(string sql, params object[] parms)
    {
      return this.Update(sql, parms);
    }

    private DbConnection CreateConnection()
    {
      DbConnection connection = Database.dbProviderFactory.CreateConnection();
      connection.ConnectionString = this.GetConnectionString();
      connection.Open();
      return connection;
    }

    private string GetConnectionString()
    {
      if (this.instanceConnectionString != null)
        return this.instanceConnectionString;
      return Database.connectionString;
    }

    private DbCommand CreateCommand(string sql, DbConnection conn, params object[] parms)
    {
      DbCommand command = this.GetCommand();
      command.Connection = conn;
      command.CommandText = sql;
      command.AddParameters(parms);
      command.CommandTimeout = 0;
      return command;
    }

    private DbCommand GetCommand()
    {
      if (this.instanceDbProviderFactory != null)
        return this.instanceDbProviderFactory.CreateCommand();
      return Database.dbProviderFactory.CreateCommand();
    }

    private DbDataAdapter CreateAdapter(DbCommand command)
    {
      DbDataAdapter dataAdapter = Database.dbProviderFactory.CreateDataAdapter();
      dataAdapter.SelectCommand = command;
      return dataAdapter;
    }
  }
}
