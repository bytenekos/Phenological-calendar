using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
namespace newDesignPhenologicalcalendar

{
    public class CallDB
    {
    public string[] calldbkak(string query) {

            string host = "localhost"; // Имя хоста
            string database = "mytestdb"; // Имя базы данных
            string user = "root"; // Имя пользователя
            string password = "ES1-731-p6zr"; // Пароль пользователя

            string Connect = "Database=" + database + ";Datasource=" + host + ";User=" + user + ";Password=" + password;


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
