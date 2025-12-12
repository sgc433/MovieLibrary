using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Abstractions;
using MovieLibrary.Core.Models;
using MovieLibrary.DataAccess.Entities;
using Serilog;

namespace MovieLibrary.DataAccess.Repositories;

public class UserRepository: IUserRepository
{
    private readonly MovieLibraryDbContext _context;
    public UserRepository(MovieLibraryDbContext context)
    {
        _context = context;
    }
    
    public async Task Create(User user)
    {
        var userEntity = new UserEntity
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            RegistrationDate = user.RegistrationDate,
            PasswordHash = user.PasswordHash,
        };
        
        await _context.AddAsync(userEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetByEmail(string email)
    {
        var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (userEntity is null)
        {
            Log.Information("User not found");
        }
        var user = User.Create(userEntity.Id, userEntity.Username, userEntity.PasswordHash, userEntity.Email,
            userEntity.RegistrationDate);
        return user;
    }
}