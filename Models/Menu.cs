using System.Globalization;
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
    public string SetArchiveMenu()
    {
        Console.Clear();
        ShowMenuBorders();
        Console.SetCursorPosition(20,2);
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
            Console.SetCursorPosition(23, 2);
            Console.Write("Welcome to Supermarket Spreadsheet Reader");

            Console.SetCursorPosition(25, 6);
            Console.WriteLine("1 - Show All Products");
            Console.SetCursorPosition(25, 7);
            Console.WriteLine("2 - Search By Name");
            Console.SetCursorPosition(25, 8);
            Console.WriteLine("3 - Show Product by Id: ");
            Console.SetCursorPosition(25, 12);
            Console.WriteLine("0 - Exit Application");
            

            Console.SetCursorPosition(25, 13);
            Console.Write("Select you option:");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    showAllProductsMenu();
                    break;
                case 2:
                    SearchByName();
                    break;
                case 3:
                    ShowProductById();
                    break;
                case 0:
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

    public void setBaseMenuOptions(string title)
    {
        Console.Clear();
        ShowMenuBorders();
        Console.SetCursorPosition(25,2);
        Console.WriteLine(title);
    }
    
    
    //ShowAllProducts
    public void showAllProductsMenu()
    {
       
        setBaseMenuOptions("1 - Show All Products");

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

        Console.SetCursorPosition(15, 4+15);
        Console.WriteLine($"Next: F7  --  Previous: F6  -- Exit Menu: ESC");

        while (true)
        {
            var key = Console.ReadKey(intercept:true);
            
            switch (key.Key)
            {
                
                case ConsoleKey.F7:

                    if(skip < products.Count-11) skip += 11;
                    
                    
                    SetPaginationAllProducts(products, skip, take);
                    
                    Console.SetCursorPosition(15, 4+15);
                    Console.WriteLine($"Next: F7  --  Previous: F6  -- Exit Menu: ESC");
                    
                    break;
                
                case ConsoleKey.F6:

                    if(skip > 0 && skip <= products.Count) skip -= 11;

                    SetPaginationAllProducts(products, skip, take);
                    
                    Console.SetCursorPosition(15, 4+15);
                    Console.WriteLine($"Next: F7  --  Previous: F6  -- Exit Menu: ESC");
                    
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
        setBaseMenuOptions("1 - Show All Products");
        
        var pagination = products.Skip(skip).Take(take).ToList();
        
        for (int i = 0; i < pagination.Count; i++)
        {
            Console.SetCursorPosition(25, 4+i);
            Console.WriteLine($"{i+1} - {pagination[i].Product_Name }");
        }
        
    }
    
    //SearchByName
    public void SearchByName()
    {
        
       setBaseMenuOptions("2 - Search By Name");
        
        
        Console.SetCursorPosition(15, 10);
        Console.Write($"Enter the Product Name:");
        string name = Console.ReadLine();
        
        
        var product = _data.Where(x =>  x.Product_Name.ToLower() == name.ToLower()).ToList();
        
        setBaseMenuOptions("2 - Search By Name");

        Console.SetCursorPosition(25,4);      
        Console.WriteLine($"--Nome - ID - Fornecedor--");


        if (product.Any())
        {
            
            for (int i = 0; i < product.Count; i++)
            {
                Console.SetCursorPosition(15, 6+i);
                Console.WriteLine($"{i+1} - {product[i].Product_Name} - {product[i].Product_ID} - {product[i].Supplier_Name}");
            }

            Console.SetCursorPosition(25,21);      
            Console.WriteLine($"Press ESC to return");
            
        }
        else
        {
            Console.SetCursorPosition(15, 7);
            Console.WriteLine("Don't Have any Products");
            Console.SetCursorPosition(25,21);      
            Console.WriteLine($"Press ESC to return");
        }
        
        
        
        while (true)
        {
            var key = Console.ReadKey(intercept:true);

            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    Console.Clear();
                    ShowMainMenu();
                    break;
            }
        }
    }
    
    //Show Product by ID
    public void ShowProductById()
    {

        while (true)
        {
            
        
            setBaseMenuOptions("3 - Show Product By ID");
    
            Console.SetCursorPosition(15, 10);
            Console.Write($"Enter the Product ID:");
            int id = int.Parse(Console.ReadLine());
            
            var product = _data.FirstOrDefault(x => x.Product_ID == id);

            if (product == null)
            {
                Console.SetCursorPosition(15, 7);
                Console.WriteLine("Don't Have any Products");
                Console.SetCursorPosition(25,21);      
                Console.WriteLine($"Press ESC to return");
            }
            else
            {
                Console.Clear();
                setBaseMenuOptions("3 - Show Product By ID");
                Console.SetCursorPosition(5, 7);
                Console.WriteLine("Name: " + product.Product_Name);
                Console.SetCursorPosition(5, 8);
                Console.WriteLine("Category: " + product.Catagory);
                Console.SetCursorPosition(5, 9);
                Console.WriteLine("Supplier Name: " + product.Supplier_Name);
                Console.SetCursorPosition(5, 10);
                Console.WriteLine("Warehouse: " + product.Warehouse_Location);
                Console.SetCursorPosition(5, 11);
                Console.WriteLine("Status: " + product.Status);
                Console.SetCursorPosition(5, 12);
                Console.WriteLine("ID: " + product.Product_ID);
                Console.SetCursorPosition(5, 13);
                Console.WriteLine("Supplier ID: " + product.Supplier_ID);
                Console.SetCursorPosition(5, 14);
                Console.WriteLine("Data Received: " + product.Date_Received.ToShortDateString());
                Console.SetCursorPosition(42, 7);
                Console.WriteLine("Last Order : " + product.Last_Order_Date.ToShortDateString());
                Console.SetCursorPosition(42, 8);
                Console.WriteLine("Expiration Date : " + product.Expiration_Date.ToShortDateString());
                Console.SetCursorPosition(42, 9);
                Console.WriteLine("Stock Quantity : " + product.Stock_Quantity);
                Console.SetCursorPosition(42, 10);
                Console.WriteLine("Reorder Level : " + product.Reorder_Level);
                Console.SetCursorPosition(42, 11);
                Console.WriteLine("Unit Price : " + product.Unit_Price.ToString("F2",CultureInfo.InvariantCulture));
                Console.SetCursorPosition(42, 12);
                Console.WriteLine("Sales Volume : " + product.Sales_Volume);
                Console.SetCursorPosition(42, 13);
                Console.WriteLine("Inventory Turnover : " + product.Inventory_Turnover_Rate);
                Console.SetCursorPosition(42, 14);
                Console.WriteLine("Percentage : " + product.percentage+"%");
                
                
                
            }
            
            Console.SetCursorPosition(25,21);      
            Console.WriteLine($"Press ESC to return");

            var key = Console.ReadKey(intercept: true);

            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    Console.Clear();
                    
                    break;
            }
            
            
        }
            
            
    }
    
  
    
}
