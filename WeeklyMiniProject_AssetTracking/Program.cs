// See https://aka.ms/new-console-template for more information
using WeeklyMiniProject_AssetTracking;

Console.WriteLine("Welcome to your asset tracker");
//DateTime exampleDate = new DateTime(1995, 1, 1);
//DateTime exampleDate2 = DateTime.Now;
AssetList assetList = new AssetList();
//assetList.AddToAssetList("Laptop", "Benovo", exampleDate, "B11");
//assetList.AddToAssetList("Laptop", "Lenovo", exampleDate2, "L11");
Console.WriteLine("Enter the type of asset you want to track | You can only track laptops, phones and pcs.\n");

void error(string errorMsg)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(errorMsg);
    Console.ResetColor();
}

while (true)
{
    Console.Write("Type of asset: ");
    string type = Console.ReadLine();
    if (type == "exit")
    {
        break;
    }
    else if (type == "")
    {
        error("Field cannot be empty!");
        continue;
    }


    Console.Write("Brand: ");
    string brand = Console.ReadLine();
    if (brand == "exit")
    {
        break;
    }
    else if (brand == "")
    {
        error("Field cannot be empty!");
        continue;
    }

    Console.Write("Model : ");
    string model = Console.ReadLine();
    if (model == "exit")
    {
        break;
    }
    else if (model == "")
    {
        error("Field cannot be empty!");
        continue;
    }

    DateTime purchaseDate;
    Console.Write("Enter date of purchase in format MM/DD/YYYY: ");
    purchaseDate = DateTime.Parse(Console.ReadLine());
    if (purchaseDate.ToString() == "exit")
    {
        break;
    }
    else if (purchaseDate.ToString() == "")
    {
        error("Field cannot be empty!");
        continue;
    }

    Console.Write("Enter purchase price of asset: ");
    double purchasePrice = Convert.ToDouble(Console.ReadLine());
    if (purchasePrice.ToString() == "exit")
    {
        break;
    }
    else if (purchasePrice.ToString() == "")
    {
        error("Field cannot be empty!");
        continue;
    }

    Console.Write("Enter the office which the asset belongs to: ");
    string office = Console.ReadLine();

    if (office  == "exit")
    {
        break;
    }
    else if (office == "")
    {
        error("Field cannot be empty!");
        continue;
    }


    assetList.AddToAssetList(type.Trim(), brand.Trim(), purchaseDate, model.Trim(),purchasePrice,office);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("You have succesfully added your asset to the list");
    Console.ResetColor();
}

assetList.DisplayList();
Console.WriteLine("Exited");
Console.ReadLine();



class AssetList
{
    List<Asset> assetList = new List<Asset>();


    public void AddToAssetList(string data, string brand, DateTime purchaseDate, string model,double purchasePrice,string office)
    {
        if (data == "Phone")
        {
            assetList.Add(new Phone(data, brand,purchaseDate,model,purchasePrice,office));
        }
        else if (data == "Laptop")
        {
            assetList.Add(new Laptop(data, brand, purchaseDate, model, purchasePrice,office));
        }
        else if (data == "Stationary computer")
        {
            assetList.Add(new StationaryComputer(data, brand, purchaseDate, model, purchasePrice,office));
        }

    }


    public void DisplayList()
    {

        foreach (Asset asset in assetList)
        {
            DateTime currentDate = DateTime.Now;
            DateTime expirationDate = asset.ExpirationDate.AddYears(3);
            if (currentDate.AddMonths(-3) >= expirationDate)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Asset category " + asset.AssetType + " " + asset.Brand + " " + asset.Model + " " + asset.ExpirationDate.ToShortDateString());
                Console.ResetColor();
            }
            else if (currentDate.AddMonths(-6) >= expirationDate)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Asset category " + asset.AssetType + " " + asset.Brand + " " + asset.Model + " " + asset.ExpirationDate.ToShortDateString());
                Console.ResetColor();
            }
            else Console.WriteLine("Asset category " + asset.AssetType + " " + asset.Brand + " " + asset.Model + " " + asset.ExpirationDate.ToShortDateString());



        }
    }
}



class Laptop : Asset
{
    public Laptop()
    {
    }


    public Laptop(string assetType, string brand, DateTime purchaseDate, string model, double purchasePrice,string office)
    {
        AssetType = assetType;
        Brand = brand;
        ExpirationDate = purchaseDate;
        Model = model;
        PurchasePrice = purchasePrice;
        Office = office;
    }


}

class Phone : Asset
{
    public Phone(string assetType, string brand, DateTime purchaseDate, string model, double purchasePrice, string office)
    {
        AssetType = assetType;
        Brand = brand;
        ExpirationDate = purchaseDate;
        Model = model;
        PurchasePrice = purchasePrice;
        Office = office;
    }


}

class StationaryComputer : Asset
{
    public StationaryComputer(string assetType, string brand, DateTime purchaseDate, string model, double purchasePrice, string office)
    {
        AssetType = assetType;
        Brand = brand;
        ExpirationDate = purchaseDate;
        Model = model;
        PurchasePrice = purchasePrice;
        Office = office;
    }


}
