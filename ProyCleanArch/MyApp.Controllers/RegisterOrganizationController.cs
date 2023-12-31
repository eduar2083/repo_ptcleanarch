﻿namespace MyApp.Controllers;

internal sealed class RegisterOrganizationController
{
    public static void Map(WebApplication app)
    {
        app.MapGroup(MasterMetadata.Group)
        .MapPost(MasterMetadata.Organization_Register, Register)
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status500InternalServerError)
        .WithMetadata(new SwaggerOperationAttribute(summary: "Registra una organización", description: "Registrar una organización en el medio de persistencia."))
        .WithTags("Master");
    }

    private static async Task<IResult> Register(RegisterOrganizationDto newOrganization, IRegisterOrganizationInputPort inputPort)
    {
        var Id = await inputPort.RegisterAsync(newOrganization);

        return Results.Ok(Id);
    }
}
