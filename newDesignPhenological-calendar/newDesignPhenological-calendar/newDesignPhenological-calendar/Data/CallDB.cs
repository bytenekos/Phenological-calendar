﻿using MySql.Data.MySqlClient;
using DotNetEnv;
namespace newDesignPhenologicalcalendar

{
    public class CallDB
    {
    public string[] calldbkak(string query) {
        
        Env.Load();
        
        string dbhost = Environment.GetEnvironmentVariable("DBHOST");
        string dbname = Environment.GetEnvironmentVariable("DBNAME");
        string dbuser = Environment.GetEnvironmentVariable("DBUSER");
        string dbpassword = Environment.GetEnvironmentVariable("DBPWD");
        
            string Connect = string.Format("Database={0};Datasource={1};User={2};Password={3};Max Pool Size=200;", dbname, dbhost, dbuser, dbpassword);


            MySqlConnection mysql_connection = new MySqlConnection(Connect);

            MySqlCommand mysql_query = mysql_connection.CreateCommand();
            mysql_query.CommandText = query;
            mysql_connection.Open();

            MySqlDataReader mysql_result;

            mysql_result = mysql_query.ExecuteReader();

            string[] result = new string[4];

            while (mysql_result.Read())
            {
                result[0] += mysql_result.GetString(1).ToString();
                result[1] += mysql_result.GetString(2).ToString();
                result[2] += mysql_result.GetString(3).ToString();
                result[3] += mysql_result.GetString(4).ToString();
            }

            mysql_result.Close();

            return result;

        }
    }
}
