using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using newDesignPhenological_calendar.Components.Pages;


public class DataService
{
    private readonly string connectionString = "Server=localhost;Database=mytestdb;User ID=root;Password=ES1-731-p6zr;"; 

    public async Task<List<DataRow>> GetDataAsync(string monthName)
    {
        var dataRows = new List<DataRow>();

        // SQL-запрос для получения данных по месяцу
        string query = "SELECT * FROM zaza WHERE month = @MonthName";

        using (var connection = new MySqlConnection(connectionString))
        {
            var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@MonthName", monthName);

            try
            {
                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var dataRow = new DataRow
                        {
                            Column1 = reader.GetInt32(0),
                            Column2 = reader.GetInt32(1),
                            Column3 = reader.GetInt32(2),
                            Column4 = reader.GetInt32(3),
                            Column5 = reader.GetInt32(4),
                            Column6 = reader.GetInt32(5),
                            Column7 = reader.GetInt32(6),
                            Column8 = reader.GetInt32(7),
                            Column9 = reader.GetInt32(8),
                            Column10 = reader.GetInt32(9),
                            Column11 = reader.GetInt32(10),
                            Column12 = reader.GetInt32(11),
                            Column13 = reader.GetInt32(12),
                            Column14 = reader.GetInt32(13),
                            Column15 = reader.GetInt32(14),
                            Column16 = reader.GetInt32(15),
                            Column17 = reader.GetInt32(16),
                            Column18 = reader.GetInt32(17),
                            Column19 = reader.GetInt32(18),
                            Column20 = reader.GetInt32(19),
                            Column21 = reader.GetInt32(20),
                            Column22 = reader.GetInt32(21),
                            Column23 = reader.GetInt32(22),
                            Column24 = reader.GetInt32(23),
                            Column25 = reader.GetInt32(24),
                            Column26 = reader.GetInt32(25),
                            Column27 = reader.GetInt32(26),
                            Column28 = reader.GetInt32(27),
                            Column29 = reader.GetInt32(28),
                            Column30 = reader.GetInt32(29),
                            Column31 = reader.GetInt32(30)
                        };

                        dataRows.Add(dataRow);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                Console.WriteLine($"Ошибка при получении данных: {ex.Message}");
            }
        }

        return dataRows;
    }
}