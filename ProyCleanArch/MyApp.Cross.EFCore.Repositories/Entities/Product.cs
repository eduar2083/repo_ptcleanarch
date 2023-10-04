namespace MyApp.Cross.EFCore.Repositories.Entities;

internal class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public string OrganizationId { get; set; }
}
