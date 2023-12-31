﻿namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddUseCaseServices(this IServiceCollection services)
    {
        services.AddScoped<IRegisterUserInputPort, RegisterUserInteractor>();
        services.AddScoped<IRegisterOrganizationInputPort, RegisterOganizationInteractor>();
        services.AddScoped<ILoginInputPort, LoginInteractor>();
        services.AddScoped<IRegisterProductInputPort, RegisterProductInteractor>();
        services.AddScoped<IGetProductByIdInputPort, GetProductByIdInteractor>();
        services.AddScoped<IListProductsInputPort, ListProductsInteractor>();
        services.AddScoped<IDeleteProductInputPort, DeleteProductInteractor>();
        services.AddScoped<IUpdateProductInputPort, UpdateProductInteractor>();

        return services;
    }
}
