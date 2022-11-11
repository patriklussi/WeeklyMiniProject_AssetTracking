// See https://aka.ms/new-console-template for more information
using WeeklyMiniProject_AssetTracking;

Console.WriteLine("Welcome to your asset tracker");



AssetList assetList = new AssetList();

Console.WriteLine("Enter the type of asset you want to track | You can only track laptops, phones and pcs.");

while (true)
{
    Console.Write("Type: ");
    string type = Console.ReadLine();
    if (type == "exit")
    {
        break;
    }


    Console.Write("Brand: ");
    string brand = Console.ReadLine();
    if (brand == "exit")
    {
        break;
    }

    Console.Write("Model : ");
    string model = Console.ReadLine();
    if(model == "exit")
    {
        break;
    }
    DateTime purchaseDate;
    Console.WriteLine("Enter date of purchase in format MM/DD/YYYY: ");
    purchaseDate = DateTime.Parse(Console.ReadLine());



    assetList.AddToAssetList(type.Trim(),brand.Trim(),purchaseDate,model.Trim());
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

    
    public void AddToAssetList(string data ,string brand,DateTime purchaseDate,string model)
    {
        if (data == "Phone") 
        {
            assetList.Add(new Phone(data,brand));
        }
        else if (data == "Laptop")
        {
            assetList.Add(new Laptop(data,brand,purchaseDate,model));
        }
        else if (data == "Stationary computer")
        {
            assetList.Add(new StationaryComputer(data,brand));
        }

    }


    public void DisplayList()
    {
        Console.WriteLine("Hello i do stuff");
        foreach (Asset asset in assetList)
        {
            Console.WriteLine("Asset category " + asset.AssetType + " " +  asset.Brand + " " + asset.Model + " "+ asset.ExpirationDate.ToString());
        }
    }
}



class Laptop : Asset
{
    public Laptop()
    {
    }

  
    public Laptop(string assetType,string brand,DateTime purchaseDate,string model)
    {
        AssetType = assetType;
        Brand = brand;
        ExpirationDate = purchaseDate;
        Model = model;
    }

   
}

class Phone : Asset
{
    public Phone(string typeOfAsset, string brand)
    {
        AssetType = typeOfAsset;
        Brand = brand;
    }

  
}

class StationaryComputer : Asset
{
    public StationaryComputer(string typeOfAsset, string brand)
    {
        AssetType = typeOfAsset;
        Brand = brand;
    }

   
}
