using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Data.Common;
using MySql.Data.MySqlClient;

public class DataService
{
    public class DayData
    {
        public int Day { get; set; }
        public int Stage { get; set; }
    }
    
    private string _connectionString = "Server=localhost;Database=mytestdb;Uid=root;Pwd=ES1-731-p6zr;";

    public async Task<List<DayData>> GetDataByMonthAsync(string month)
    {
        var dataList = new List<DayData>();

        using (MySqlConnection conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            MySqlCommand cmd = new MySqlCommand("SELECT day, stage FROM zaza WHERE month = @month", conn);
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