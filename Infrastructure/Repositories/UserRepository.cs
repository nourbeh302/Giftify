using Domain.Users;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<IReadOnlyList<User>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.ToListAsync(cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<User> AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await _dbContext.Users.AddAsync(user, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _dbContext.Users
            .Where(u => u.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        await _dbContext.Users
            .Where(u => u.Id == user.Id)
            .ExecuteUpdateAsync(
                s => s
                    .SetProperty(u => u.FirstName, user.FirstName) 
                    .SetProperty(u => u.LastName, user.LastName) 
                    .SetProperty(u => u.Email, user.Email) 
                    .SetProperty(u => u.PhoneNumber, user.PhoneNumber) 
                    .SetProperty(u => u.Gender, user.Gender)
                    .SetProperty(u => u.IsVerified, user.IsVerified) 
                    .SetProperty(u => u.IsLocked, user.IsLocked) 
                    .SetProperty(u => u.Address, user.Address) 
                    .SetProperty(u => u.ProfileImageUrl, user.ProfileImageUrl), 
                cancellationToken: cancellationToken);

        return user;
    }
}