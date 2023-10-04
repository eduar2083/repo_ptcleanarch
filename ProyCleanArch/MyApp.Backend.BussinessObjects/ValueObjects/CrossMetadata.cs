namespace MyApp.Backend.BussinessObjects.ValueObjects;

public class CrossMetadata
{
    public const string Group = "/cross";

    public const string Product_Register = "/products/register";
    public const string Product_Update = "/products/update";
    public const string Product_Get = "/products/{id:int}";
    public const string Product_List = "/products/list";
}
