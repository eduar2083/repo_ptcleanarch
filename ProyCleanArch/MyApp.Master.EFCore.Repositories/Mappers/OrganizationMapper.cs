﻿namespace MyApp.EFCore.Repositories.Mappers;

internal static class OrganizationMapper
{
    public static Organization ToOrganization(this RegisterOrganizationDto newOrganization) =>
        new Organization
        {
            Name = newOrganization.Name
        };
}
