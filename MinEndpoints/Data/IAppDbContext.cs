using Microsoft.EntityFrameworkCore;
using MinEndpoints.Data.Models;

namespace MinEndpoints.Data
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
