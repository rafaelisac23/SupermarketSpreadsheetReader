using SupermarketSpreadsheetReader.Static.Repository;

namespace SupermarketSpreadsheetReader.Static;

class Program
{
    static void Main(string[] args)
    {
        Menu.SetArchiveMenu();
        string path = Console.ReadLine();
        var csvRepository = new CsvRepository(path);
        csvRepository.InitReadCsv();
        
        Menu.ShowMainMenu();
        
    }


   
    
    
}
