using SupermarketSpreadsheetReader.Static.Enum;

namespace SupermarketSpreadsheetReader;

public class CsvBaseModel
{
    public string Product_Name {get;set;}//ok
    
    public string Catagory {get;set;}//ok
    
    public string Supplier_Name {get;set;}//ok
    
    public string Warehouse_Location {get;set;}//ok
    
    public StatusCsv Status {get;set;} //ok
    
    public int Product_ID {get;set;}//ok
    
    public int Supplier_ID {get;set;}//ok
    
    public DateTime Date_Received {get;set;}//ok
    
    public DateTime Last_Order_Date {get;set;}//ok
    
    public DateTime Expiration_Date {get;set;}//ok
    
    public int Stock_Quantity {get;set;}//ok
    
    public int Reorder_Level {get;set;}//ok
    
    public int Reorder_Quantity {get;set;}//ok
    
    public double  Unit_Price {get;set;}//ok
    
    public int  Sales_Volume {get;set;}//ok
    
    public int  Inventory_Turnover_Rate {get;set;}
    
    public double  percentage {get;set;}
    
    
    
}