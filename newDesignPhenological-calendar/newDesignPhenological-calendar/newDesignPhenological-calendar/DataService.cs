
using Mysqlx.Crud;
using newDesignPhenological_calendar.Components.Pages;


public class DataService
{
    private readonly newDesignPhenologicalcalendar.CallDB callDB = new newDesignPhenologicalcalendar.CallDB();
    public Task<List<DataRow>> GetDataAsync(string MonthName)
    {
        var data = new List<DataRow>();
        
        string[] stage = callDB.calldbkak($"SELECT * FROM zaza WHERE month = '{MonthName}'");
        
        for (int i = 0; i < 6; i++)
        {
            data.Add(new DataRow
            {
                Column1 = stage[3];
               
                /*Column1 = i * 1,
                Column2 = i * 2,
                Column3 = i * 3,
                Column4 = i * 4,
                Column5 = i * 5,
                Column6 = i * 1,
                Column7 = i * 2,
                Column8 = i * 3,
                Column9 = i * 4,
                Column10 = i * 5,
                Column11 = i * 1,
                Column12 = i * 2,
                Column13 = i * 3,
                Column14 = i * 4,
                Column15 = i * 5,
                Column16 = i * 1,
                Column17 = i * 2,
                Column18 = i * 3,
                Column19 = i * 4,
                Column20 = i * 5,
                Column21 = i * 1,
                Column22 = i * 2,
                Column23 = i * 3,
                Column24 = i * 4,
                Column25 = i * 5,
                Column26 = i * 1,
                Column27 = i * 2,
                Column28 = i * 3,
                Column29 = i * 4,
                Column30 = i * 5,
                Column31 = i * 6*/
    
            });
        }
        return Task.FromResult(data);
    }
}