namespace MyApp.Cross.EFCore.Repositories.DataContexts;

internal sealed class CrossContextFactory : IDesignTimeDbContextFactory<CrossContext>
{
    public CrossContext CreateDbContext(string[] args)
    {
        var ConnectionStringsOptions = new CrossConnectionStringsOptions
        {
            CrossDb =
            "Server=(localdb)\\mssqllocaldb; Database=CrossDb; Application Name=MyApp"
        };

        return new CrossContext(Options.Create(ConnectionStringsOptions));
    }
}
