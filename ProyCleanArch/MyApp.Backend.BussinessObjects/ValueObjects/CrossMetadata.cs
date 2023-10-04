namespace MyApp.Backend.BussinessObjects.ValueObjects;

public class CrossMetadata
{
    public const string Group = "/cross";

    public const string Product_Register = "/product/register";
    public const string Product_Update = "/product/update";
    public const string Product_Get = "/product/{id:int}";
    public const string Product_List = "/product/list";
}
