﻿namespace MyApp.EFCore.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly MasterContext Context;
    private readonly IPasswordHasher PasswordHasher;

    public UserRepository(MasterContext context, IPasswordHasher passwordHasher)
    {
        Context = context;
        PasswordHasher = passwordHasher;
    }

    public async Task<string> RegisterAsync(RegisterUserDto user)
    {
        var NewUser = user.ToUser(PasswordHasher);
        NewUser.Id = Guid.NewGuid().ToString();

        try
        {
            Context.Add(NewUser);
            await Context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new PersistenceException(ex.Message, ex.InnerException ?? ex);
        }

        return NewUser.Id;
    }

    public async Task<UserDto> GetByUserNameAsync(string userName)
    {
        try
        {
            return await Context.Users
                .AsNoTracking()
                .Where(u => u.Email == userName)
                .Select(u => u.ToUserDto())
                .FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            throw new RetrieveDataException(ex.Message, ex.InnerException ?? ex);
        }
    }
}
