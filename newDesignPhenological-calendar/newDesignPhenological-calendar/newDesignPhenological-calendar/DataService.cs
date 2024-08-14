using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Data.Common;
using MySql.Data.MySqlClient;
using DotNetEnv;


public static class Config
{
    static Config()
    {
        Env.Load();
        DbHost = Environment.GetEnvironmentVariable("DBHOST");
        DbName = Environment.GetEnvironmentVariable("DBNAME");
        DbUser = Environment.GetEnvironmentVariable("DBUSER");
        DbPassword = Environment.GetEnvironmentVariable("DBPWD");
        
    }
    
    public static string DbHost { get; }
    public static string DbName { get; }
    public static string DbUser { get; }
    public static string DbPassword { get; }
}

public class DataService
{
    public class DayData
    {
        public int Day { get; set; }
        public int Stage { get; set; }
    }
    
    private string _connectionString = $"Server={Config.DbHost};Database={Config.DbName};Uid={Config.DbUser};Pwd={Config.DbPassword};Max Pool Size=200;";
    

    public async Task<List<DayData>> GetDataByTableAsync(string tableName, string month)
    {
        
        var allowedTables = new List<string> { "тепличнаябелокрылка", "тепличныйтрипс" };

        // Если таблица не найдена в списке допустимых, выбрасываем исключение
        if (!allowedTables.Contains(tableName))
        {
            throw new ArgumentException("Недопустимое название таблицы.");
        }

        var dataList = new List<DayData>();

        string query = $"SELECT day, stage FROM {tableName} WHERE month = @month";

        using (MySqlConnection conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@month", month);
            using (DbDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var data = new DayData
                    {
                        Day = reader.GetInt32("day"),
                        Stage = reader.GetInt32("stage")
                    };
                    dataList.Add(data);
                }
            }
        }
        return dataList;
    }

}