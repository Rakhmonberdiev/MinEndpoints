using MinEndpoints.Data.Models;

namespace MinEndpoints.Data.Seed
{
    public static class Seed
    {
        public static async Task SeedUsers(AppDbContext db)
        {
            using var transaction = db.Database.BeginTransaction();
            try
            {
                if (db.Users.Any())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nusers exist\n");
                    transaction.Rollback();
                    return;
                }
                var users = new List<User>
                {
                    new User{Id = Guid.NewGuid(),UserName="John"},
                    new User{Id = Guid.NewGuid(),UserName="Jane" },
                    new User{Id = Guid.NewGuid(),UserName="Alex" },
                    new User{Id = Guid.NewGuid(),UserName="Elena" },
                    new User{Id = Guid.NewGuid(),UserName="Maxim" }
                };
                await db.Users.AddRangeAsync(users);
                await db.SaveChangesAsync();
                transaction.Commit();

            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n"+e.Message+"\n");
            }

        }
    }
}
