// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to your asset tracker");



AssetList assetList = new AssetList();

while (true)
{
    Console.Write("Category: ");
    string data = Console.ReadLine();
    


    if(data == "exit")
    {
        break;
    }
    assetList.AddToAssetList(data);
   
}
Console.ReadLine();

class AssetList
{
    List<Asset> assetList = new List<Asset> ();
    public void AddToAssetList(string data)
    {
        assetList.Add(new Laptop(data));
    }
}

class Asset 
{
    public Asset()
    {
    }

    
    
}

class Laptop : Asset
{
    public Laptop(string type)
    {
        Type = type;
    }

    public string Type {get;set;}
}
class Phone :Asset
{

}

class StationaryComputer: Asset
{

}
