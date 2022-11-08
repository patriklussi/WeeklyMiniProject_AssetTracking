// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to your asset tracker");



while (true)
{
    Console.Write("Category: ");
    string data = Console.ReadLine();
    if(data == "exit")
    {
        break;
    }
}

class AssetList
{
    List<> assetList = new List<> ();
}






class Asset 
{
    public Asset()
    {
    }

    public Asset(string type, string brand, string model, string office, DateTime purchaseDate, int price, string currency, double localPrice)
    {
        Type = type;
        Brand = brand;
        Model = model;
        Office = office;
        PurchaseDate = purchaseDate;
        Price = price;
        Currency = currency;
        LocalPrice = localPrice;
    }

    string Type { get; set; }
    string Brand { get; set; }
    string Model { get; set; }
    string Office { get; set; }
    DateTime PurchaseDate { get; set; }
    int Price { get; set; }
    string Currency { get; set; }
    double LocalPrice { get; set; }
}