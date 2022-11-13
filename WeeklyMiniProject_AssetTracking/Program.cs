// See https://aka.ms/new-console-template for more information
using WeeklyMiniProject_AssetTracking;

Console.WriteLine("Welcome to your asset tracker");

AssetList assetList = new AssetList(); //Aasset list instantiation


DateTime exampelDate = new DateTime(2015 - 02 - 13);
assetList.AddToAssetList("laptop","Lenovo",exampelDate,"B11",555,"germany");

Console.WriteLine("Enter the type of asset you want to track | You can only track laptops, phones and pcs.\n");

static void error(string errorMsg) // Error function to minimize error code
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(errorMsg);
    Console.ResetColor();
}

while (true)
{
    Console.Write("Type of asset: ");
    string type = Console.ReadLine();
    type = type.Trim().ToLower();
    if (type == "exit")
    {
        break;
    }
    else if (!(type == "laptop" || type == "phone" || type == "pc"))
    {
        error("You can only enter laptop, phone or pc as an asset!");
        continue;
    }


    Console.Write("Brand: ");
    string brand = Console.ReadLine();
    brand = brand.Trim().ToLower();
   
    if (brand == "")
    {
        error("Field cannot be empty!");
        continue;
    }

    Console.Write("Model : ");
    string model = Console.ReadLine();
    model = model.Trim().ToLower();
    if (model == "")
    {
        error("Field cannot be empty!");
        continue;
    }

    DateTime purchaseDate = new DateTime(1995, 1, 1);

    try
    {
        Console.Write("Enter date of purchase in format YYYY/MM/DD: ");
        purchaseDate = Convert.ToDateTime(Console.ReadLine());
        
    }
    catch (Exception e)
    {
        error(e.ToString());
        continue;
    }


    int purchasePrice = 0;
    try
    {
        Console.Write("Enter purchase price of asset: ");
        purchasePrice = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception e)
    {
        error(e.ToString());
        continue;
    }

    if (purchasePrice.ToString() == "exit")
    {
        break;
    }
   
    Console.Write("Enter the office which the asset belongs to: ");
    string office = Console.ReadLine();
    office = office.Trim().ToLower();
    if (office == "exit")
    {
        break;
    }
    else if (!(office == "america" || office == "sweden" || office == "germany"))
    {
        error("Field can only contain America, Sweden and Germany!");
        continue;
    }

    assetList.AddToAssetList(type, brand, purchaseDate, model, purchasePrice, office);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("You have succesfully added your asset to the list");
    Console.ResetColor();
}

assetList.DisplayList();
Console.ReadLine();



class AssetList
{
    List<Asset> assetList = new List<Asset>();
    public void AddToAssetList(string data, string brand, DateTime purchaseDate, string model, int purchasePrice, string office)
    {
    
       
        string currency = string.Empty;
        currency = DetermineCurrency(currency, office);
        double currenyConverted = convertCurrency(currency, purchasePrice);

        if (data == "phone")
        {
            assetList.Add(new Phone(data, brand, purchaseDate, model, purchasePrice, office, currency, currenyConverted));
        }
        else if (data == "laptop")
        {
            assetList.Add(new Laptop(data, brand, purchaseDate, model, purchasePrice, office, currency, currenyConverted));
        }
        else if (data == "pc")
        {
            assetList.Add(new StationaryComputer(data, brand, purchaseDate, model, purchasePrice, office, currency, currenyConverted));
        }

    }

    private string DetermineCurrency(string currency, string office)
    {
        if (office == "america")
        {
            currency = "USD";
        }
        else if (office == "sweden")
        {
            currency = "SEK";
        }
        else if (office == "germany")
        {
            currency = "EUR";
        }
        return currency;
    }

    double convertedPrice;
    private double convertCurrency(string currency, int purchasePrice)
    {
        if (currency == "SEK")
        {
            convertedPrice = purchasePrice * 10.3726;
        }
        else if (currency == "EUR")
        {
            convertedPrice = purchasePrice * 0.96492;
        }
        else
        {
            convertedPrice = purchasePrice;
        }
        return convertedPrice;
    }

    public void DisplayList()
    {

        Console.WriteLine("Type".PadRight(10) + "Brand".PadRight(10) + "Model".PadRight(10) + "Office".PadRight(10) + "Purchase date".PadRight(15) + "Price in USD".PadRight(15) + "Currency".PadRight(10) + "Local price today".PadRight(10));
        foreach (Asset asset in assetList)
        {
            DateTime currentDate = DateTime.Now;
            DateTime expirationDate = asset.ExpirationDate.AddYears(3);
            if (currentDate.AddMonths(-3) >= expirationDate)
            {
                PrintAsset(asset, ConsoleColor.Red);
            }
            else if (currentDate.AddMonths(-6) >= expirationDate)
            {
                PrintAsset(asset, ConsoleColor.Yellow);
            }
            else
            {
                PrintAsset(asset, ConsoleColor.White);
            }
        }
    }
    private void PrintAsset(Asset asset, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(asset.AssetType.PadRight(10) + asset.Brand.PadRight(10) + asset.Model.PadRight(10) + asset.Office.PadRight(10) + asset.ExpirationDate.ToShortDateString().PadRight(15) + $"{asset.PurchasePrice}$".PadRight(15) + asset.Currency.PadRight(10) + asset.ConvertedCurrency);
        Console.ResetColor();
    }
}



class Laptop : Asset
{
    public Laptop()
    {
    }

    public Laptop(string assetType, string brand, DateTime purchaseDate, string model, int purchasePrice, string office, string currency, double convertedCurrency)
    {
        AssetType = assetType;
        Brand = brand;
        ExpirationDate = purchaseDate;
        Model = model;
        PurchasePrice = purchasePrice;
        Office = office;
        Currency = currency;
        ConvertedCurrency = convertedCurrency;
    }


}

class Phone : Asset
{
    public Phone(string assetType, string brand, DateTime purchaseDate, string model, int purchasePrice, string office, string currency, double convertedCurrency)
    {
        AssetType = assetType;
        Brand = brand;
        ExpirationDate = purchaseDate;
        Model = model;
        PurchasePrice = purchasePrice;
        Office = office;
        Currency = currency;
        ConvertedCurrency = convertedCurrency;
    }


}

class StationaryComputer : Asset
{
    public StationaryComputer(string assetType, string brand, DateTime purchaseDate, string model, int purchasePrice, string office, string currency, double convertedCurrency)
    {
        AssetType = assetType;
        Brand = brand;
        ExpirationDate = purchaseDate;
        Model = model;
        PurchasePrice = purchasePrice;
        Office = office;
        Currency = currency;
        ConvertedCurrency = convertedCurrency;
    }


}
