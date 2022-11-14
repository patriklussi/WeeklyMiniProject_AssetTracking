// See https://aka.ms/new-console-template for more information
using WeeklyMiniProject_AssetTracking;

Console.WriteLine("Welcome to your asset tracker");

AssetList assetList = new AssetList(); //Aasset list instantiation


DateTime exampelDate = new DateTime(2010, 8, 18);
assetList.AddToAssetList("Laptop", "Lenovo", exampelDate, "B11", 555, "Germany");
assetList.AddToAssetList("Phone", "Iphone", exampelDate, "B11", 414, "Sweden");
assetList.AddToAssetList("Pc", "Lenovo", exampelDate, "B11", 7124, "America");

Console.WriteLine("Enter the type of asset you want to track | You can only track laptops, phones and pcs | If you wish to see your asset list type exit \n");

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

    if (type.Trim().ToLower() == "exit")
    {
        break;
    }
    else if (!(type.Trim().ToLower() == "laptop" || type.Trim().ToLower() == "phone" || type.Trim().ToLower() == "pc"))
    {
        error("You can only enter Laptop, Phone or Pc as an asset!");
        continue;
    }
    Console.Write("Brand: ");
    string brand = Console.ReadLine();
    if (brand.Trim().ToLower() == "")
    {
        error("Field cannot be empty!");
        continue;
    }
    Console.Write("Model : ");
    string model = Console.ReadLine();
    if (model.Trim().ToLower() == "")
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
    Console.Write("Enter the office which the asset belongs to: ");
    string office = Console.ReadLine();
    if (!(office.Trim().ToLower() == "america" || office.Trim().ToLower() == "sweden" || office.Trim().ToLower() == "germany"))
    {
        error("Field can only contain America, Sweden and Germany!");
        continue;
    }
    assetList.AddToAssetList(type, brand, purchaseDate, model, purchasePrice, office);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("You have succesfully added your asset to the list");
    Console.ResetColor();
    Console.Write("If you want to add another asset type restart | If you want to exit and look at your items type exit \n ");
    string exitText = Console.ReadLine();
    if (exitText.Trim().ToLower() == "exit")
    {
        break;

    }
    else if (exitText.Trim().ToLower() == "restart")
    {
        continue;
    }

}

assetList.DisplayList();
Console.ReadLine();



class AssetList
{
    List<Asset> assetList = new List<Asset>();
    public void AddToAssetList(string data, string brand, DateTime purchaseDate, string model, int purchasePrice, string office)
    {

        string dataToLower = data.ToLower();
        string officeToLower = office.ToLower();
        string currency = string.Empty;
        currency = DetermineCurrency(currency, officeToLower);
        double currenyConverted = convertCurrency(currency, purchasePrice);

        if (dataToLower == "phone")
        {
            assetList.Add(new Phone(data, brand, purchaseDate, model, purchasePrice, office, currency, currenyConverted));
        }
        else if (dataToLower == "laptop")
        {
            assetList.Add(new Laptop(data, brand, purchaseDate, model, purchasePrice, office, currency, currenyConverted));
        }
        else if (dataToLower == "pc")
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

        Console.WriteLine("Type".PadRight(13) + "Brand".PadRight(13) + "Model".PadRight(13) + "Office".PadRight(13) + "Purchase date".PadRight(18) + "Price in USD".PadRight(18) + "Currency".PadRight(13) + "Local price today".PadRight(13));
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
        Console.WriteLine(asset.AssetType.PadRight(13) + asset.Brand.PadRight(13) + asset.Model.PadRight(13) + asset.Office.PadRight(13) + asset.ExpirationDate.ToShortDateString().PadRight(18) + $"{asset.PurchasePrice}$".PadRight(18) + asset.Currency.PadRight(13) + asset.ConvertedCurrency);
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
