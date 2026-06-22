namespace SupermarketSpreadsheetReader;

public static class Menu
{

    public static void ShowMenuBorders()
    {
        for (int i = 0; i < 30; i++)
        {
            Console.Write("-");
        }
    }

    public static void ShowMainMenu()
    {
        Console.Clear();
        ShowMenuBorders();

        Console.ReadLine();

    }
    
    
    
}