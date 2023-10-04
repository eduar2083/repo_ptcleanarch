namespace MyApp.Master.EFCore.Repositories.DataContexts;

internal sealed class MasterContextFactory : IDesignTimeDbContextFactory<MasterContext>
{
    public MasterContext CreateDbContext(string[] args)
    {
        var ConnectionStringsOptions = new MasterConnectionStringsOptions
        {
            MasterDb =
            "Server=(localdb)\\mssqllocaldb; Database=MasterDb; Application Name=MyApp"
        };

        return new MasterContext(Options.Create(ConnectionStringsOptions));
    }
}
