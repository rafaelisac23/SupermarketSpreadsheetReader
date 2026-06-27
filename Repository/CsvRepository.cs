using System.Globalization;
using SupermarketSpreadsheetReader.Static.Enum;

namespace SupermarketSpreadsheetReader.Static.Repository;

public class CsvRepository
{
    public string _path;
    public List<CsvBaseModel> data { get; private set; } = [];
    private Menu _menu;

    public CsvRepository(string path,Menu menu)
    {
        _path = path;
        _menu = menu;
    }

    public void InitReadCsv()
    {
        //Verifica se o arquivo existe

        if (File.Exists(_path))
        { 
            _menu.ShowFileExist();
        }
        else
        {
           _menu.ShowFileDontExist();
        }
        
        Console.Clear();

        //faz a leitura do arquivo e separa as linhas 
        
        try
        {
            
            using (FileStream fs = new FileStream(_path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    sr.ReadLine(); // pula a primeira linha do cabeçalho
                    
                    while (!sr.EndOfStream)
                    {
                        var line =  sr.ReadLine();
                        
                        //Pegando valores de cada linha 
                        var values = line.Split(',');
                        
                        //Pegando o valor do Product_id e transformando para int 

                        var productsValuesId = values[5].Split("-");
                        
                        var realProductId = int.Parse($"{productsValuesId[0]}{productsValuesId[1]}{productsValuesId[2]}");
                        
                        //Pegando o valor do Supplier_id e transformando para int 

                        var supplierValuesId = values[6].Split("-");
                        
                        var realSupplierId = int.Parse($"{supplierValuesId[0]}{supplierValuesId[1]}{supplierValuesId[2]}");
                        
                        //Pegando o valor do Data_received e transformando para DateTime
                        var dateReceived = DateTime.ParseExact(values[7],"M/d/yyyy",CultureInfo.InvariantCulture);
                        
                        //Pegando o valor do Last_Order_Date e transformando para DateTime
                        var lastOrderDate = DateTime.ParseExact(values[8],"M/d/yyyy",CultureInfo.InvariantCulture);
                        
                        //Pegando o valor do Expiration_Date e transformando para DateTime
                        var expirationDate = DateTime.ParseExact(values[9],"M/d/yyyy",CultureInfo.InvariantCulture);
                        
                        ////Pegando o valor do Unit_Price e transformando para int
                        var unitPrice = values[13].Split("$");
                        
                        var realUnitPrice = double.Parse(unitPrice[1],CultureInfo.InvariantCulture);
                        
                        //Pegando o valor do percentage e transformando para double
                        var percentage = values[16].Split("%");

                        var realPercentage = double.Parse(percentage[0],CultureInfo.InvariantCulture);
                        
                        
                        data.Add(new CsvBaseModel()
                        {
                            Product_Name = values[0],
                            Catagory = values[1],
                            Supplier_Name =  values[2],
                            Warehouse_Location =  values[3],
                            Status =  System.Enum.Parse<StatusCsv>(values[4],ignoreCase:true),
                            Product_ID = realProductId,
                            Supplier_ID = realSupplierId,
                            Date_Received =  dateReceived,
                            Last_Order_Date =  lastOrderDate,
                            Expiration_Date = expirationDate,
                            Stock_Quantity = int.Parse(values[10]),
                            Reorder_Level = int.Parse(values[11]),
                            Reorder_Quantity =  int.Parse(values[12]),
                            Unit_Price = realUnitPrice,
                            Sales_Volume = int.Parse(values[14]),
                            Inventory_Turnover_Rate = int.Parse(values[15]),
                            percentage = realPercentage
                        });
                        
                    }
                }
            }
            
        }
        
        
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
        
       
    }
    
}