namespace MyApp.EFCore.Repositories.Entities;

internal class Organization
{
    public string Id { get; set; }
    public string Name { get; set; }

    public List<User> Users { get; set; }
}
