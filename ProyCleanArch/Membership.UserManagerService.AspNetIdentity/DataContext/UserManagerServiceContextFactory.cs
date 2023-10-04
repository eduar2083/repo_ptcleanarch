namespace Membership.UserManagerService.AspNetIdentity.DataContext;

internal sealed class UserManagerServiceContextFactory : IDesignTimeDbContextFactory<UserManagerServiceContext>
{
    public UserManagerServiceContext CreateDbContext(string[] args)
    {
        string ConnectionString = args.Length == 0 ? "" : args[0];
        if (args.Length == 0)
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("Must provide ConnectionString when Update Database");
            Console.Write("Example: Update-Database ...-Args ");
            Console.WriteLine("\"Server=(localdb)\\mssqllocaldb; Database=UsersDB\"");
            Console.WriteLine("**************************************************");
        }

        return new UserManagerServiceContext(Microsoft.Extensions.Options.Options.Create(new AspNetIdentityOptions
        {
            MembershipDb = ConnectionString
        }));
    }
}
