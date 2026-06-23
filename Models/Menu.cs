namespace SupermarketSpreadsheetReader;

public static class Menu
{

    public static void ShowMenuBorders()
    {
        Console.Clear();

        int width = 80;
        int height = 23;

        string horizontal = new string('═', width - 2);
        
        Console.WriteLine("╔" + horizontal + "╗");
        
        for (int i = 0; i < height - 2; i++)
        {
            Console.WriteLine("║" + new string(' ', width - 2) + "║");
        }

        Console.WriteLine("╚" + horizontal + "╝");
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
        
        Console.SetCursorPosition(2,2);
        Console.WriteLine("aa");
        Console.ReadLine();
    }
    
    
    
}