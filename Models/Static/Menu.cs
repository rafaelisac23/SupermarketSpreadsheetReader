namespace SupermarketSpreadsheetReader.Static;

public static class Menu
{

    public static void ShowMenuBorders()
    {
        Console.Clear();

        int width = Console.WindowWidth;
        int height = 44;

        string horizontal = new string('═', width - 2);
        
        Console.WriteLine("╔" + horizontal + "╗");
        
        for (int i = 0; i < height - 2; i++)
        {
            Console.WriteLine("║" + new string(' ', width - 2) + "║");
        }

        Console.WriteLine("╚" + horizontal + "╝");
    }
    public static void SetArchiveMenu()
    {
        Console.Clear();
        Menu.ShowMenuBorders();
        Console.SetCursorPosition(80,2);
        Console.Write("Welcome to Supermarket Spreadsheet Reader ");
        Console.SetCursorPosition(5,10);
        Console.Write("Path of CSV: ");
    }
    public static void ShowFileExist()
    {
        Console.Clear();
        ShowMenuBorders();
        Console.SetCursorPosition(10,10);
        Console.Write("File Exist");
        Console.WriteLine();
        Console.SetCursorPosition(10,12);
        Console.Write("Wait 3 seconds ....");
        Thread.Sleep(5000);
        ShowMainMenu();
    }
    public static void ShowFileDontExist()
    {
        Console.Clear();
        Menu.ShowMenuBorders();
        Console.SetCursorPosition(10,10);
        Console.Write("File Don't Exist");
        Console.WriteLine();
        Console.SetCursorPosition(10,12);
        Console.Write("Wait 3 seconds ....");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
    }
    public static void ShowMainMenu()
    {
        Console.Clear();
        ShowMenuBorders();
        ShowOptions();
    }
    public static void ShowOptions()
    {
        int option = 0;
        
        Console.SetCursorPosition(80,2);
        Console.Write("Welcome to Supermarket Spreadsheet Reader ");
        
        Console.ReadLine();
    }
    
    
    
    
    
}