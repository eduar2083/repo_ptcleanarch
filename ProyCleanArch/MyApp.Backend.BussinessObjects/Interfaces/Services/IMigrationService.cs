﻿namespace MyApp.Backend.BussinessObjects.Interfaces.Services;

public interface IMigrationService
{
    Task ApplyMigration(MigratorTenantInfo tenant);
}
