using SupermarketSpreadsheetReader.Static.Repository;

namespace SupermarketSpreadsheetReader.Static;

class Program
{
    static void Main(string[] args)
    {
       Menu menu = new Menu();
       string path = menu.SetArchiveMenu();
       var csvRepository = new CsvRepository(path,menu);
       csvRepository.InitReadCsv();
       menu.Data = csvRepository.data;
       menu.ShowMainMenu();
       
    }


   
    
    
}
