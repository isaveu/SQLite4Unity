using UnityEngine;
using Mono.Data.Sqlite;
using System.Reflection;

public class TableManager {

    SqliteConnection mSqliteConnection = null;
    private static TableManager mInstance;
    public static TableManager Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new TableManager();
                mInstance.LoadDB();
            }            
            return mInstance;
        }
    }

    public void LoadDB()
    {
        float time = Time.realtimeSinceStartup;
        if (mSqliteConnection != null)
        {
            mSqliteConnection.Close();
            mSqliteConnection = null;
        }
        mSqliteConnection = new SqliteConnection("data source=test.db");
        mSqliteConnection.Open();
        Debug.LogFormat("open time={0}s", Time.realtimeSinceStartup - time);
    }

    public T GetTableData<T>(eTableName table, string id)
    {
        T data = System.Activator.CreateInstance<T>();
        float time = Time.realtimeSinceStartup;
        SqliteCommand cmd = mSqliteConnection.CreateCommand();
        cmd.CommandText = string.Format("select * from {0} where id={1}", table.ToString(), id);
        SqliteDataReader reader = cmd.ExecuteReader();
        Debug.LogFormat("search time={0}s", Time.realtimeSinceStartup - time);
        if (reader.HasRows)
        {
            FieldInfo[] fields = data.GetType().GetFields();
            foreach (var item in fields)
            {
                int index = reader.GetOrdinal(item.Name);
                object v = reader.GetValue(index);
                if (v != null)
                    item.SetValue(data, v);
            }
            return data;
        }
        return data;
    }


}
