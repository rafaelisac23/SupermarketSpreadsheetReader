using SupermarketSpreadsheetReader.Static.Repository;

namespace SupermarketSpreadsheetReader;

public class Menu
{

    private List<CsvBaseModel> _data = [];

    public List<CsvBaseModel> Data
    {
        get { return _data; }
        set { _data = value; }
    }
    
    public void ShowMenuBorders()
    {
        Console.Clear();

        int width = Console.WindowWidth;
        int height = 43;

        string horizontal = new string('═', width - 2);
        
        Console.WriteLine("╔" + horizontal + "╗");
        
        for (int i = 0; i < height - 2; i++)
        {
            Console.WriteLine("║" + new string(' ', width - 2) + "║");
        }

        Console.WriteLine("╚" + horizontal + "╝");
    }
    public string SetArchiveMenu()
    {
        Console.Clear();
        ShowMenuBorders();
        Console.SetCursorPosition(80,2);
        Console.Write("Welcome to Supermarket Spreadsheet Reader ");
        Console.SetCursorPosition(5,10);
        Console.Write("Path of CSV: ");
        string path = Console.ReadLine();

        return path;

    }
    public void ShowFileExist()
    {
        Console.Clear();
        ShowMenuBorders();
        Console.SetCursorPosition(10,10);
        Console.Write("File Exist");
        Console.WriteLine();
        Console.SetCursorPosition(10,12);
        Console.Write("Wait 3 seconds ....");
        Thread.Sleep(5000);
    }
    
    public void ShowFileDontExist()
    {
        Console.Clear();
        ShowMenuBorders();
        Console.SetCursorPosition(10,10);
        Console.Write("File Don't Exist");
        Console.WriteLine();
        Console.SetCursorPosition(10,12);
        Console.Write("Wait 3 seconds ....");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
    }
    public void ShowMainMenu()
    {
        Console.Clear();
        ShowMenuBorders();
        ShowOptions();
    }
    public void ShowOptions()
    {
        try
        {
            Console.SetCursorPosition(80, 2);
            Console.Write("Welcome to Supermarket Spreadsheet Reader");

            Console.SetCursorPosition(80, 10);
            Console.WriteLine("1 - Show All Products");
            Console.SetCursorPosition(80, 12);
            Console.WriteLine("2 - Exit Application");

            Console.SetCursorPosition(80, 15);
            Console.Write("Select you option:");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    showAllProductsMenu();
                    break;
                case 2:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    ShowMainMenu();
                    break;
            }

        }
        catch (Exception e)
        {
            Console.Clear();
           ShowMainMenu();
        }
    }
    
    public void showAllProductsMenu()
    {
        Console.Clear();
        ShowMenuBorders();
        Console.SetCursorPosition(80,2);
        Console.WriteLine("1 - Show All Products");

        int skip = 0;
        int take = 11;

        List<CsvBaseModel> products = [];

        foreach (var data in _data)
        {

            if (!products.Exists(x => x.Product_Name == data.Product_Name))
            {
                products.Add(data);
            }
        }
        
        SetPaginationAllProducts(products, skip, take);


        while (true)
        {
            var key = Console.ReadKey(intercept:true);
            
            switch (key.Key)
            {
                
                
                case ConsoleKey.F7:

                    if(skip < products.Count) skip += 11;
                    
                    SetPaginationAllProducts(products, skip, take);
                    
                    break;
                
                case ConsoleKey.F6:

                    if(skip > 0 && skip <= products.Count) skip -= 11;

                    SetPaginationAllProducts(products, skip, take);
                    
                    break;
                
                case ConsoleKey.Escape:
                    Console.Clear();
                    ShowMainMenu();
                    break;
                
            }
        }
        
     
    }

    public void SetPaginationAllProducts(List<CsvBaseModel> products,int skip,int take)
    {
        var pagination = products.Skip(skip).Take(take).ToList();
        
        for (int i = 0; i < pagination.Count; i++)
        {
            Console.SetCursorPosition(10, 4+i);
            Console.WriteLine($"{i+1} - {pagination[i].Product_Name }");
        }
    }
  
    
}
