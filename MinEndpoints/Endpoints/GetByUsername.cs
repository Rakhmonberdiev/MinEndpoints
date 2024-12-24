using Microsoft.EntityFrameworkCore;
using MinEndpoints.Abstractions;
using MinEndpoints.Data;

namespace MinEndpoints.Endpoints
{
    public sealed class GetByUsername : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("get/{username}", async (IAppDbContext db, string username, CancellationToken cancellationToken) =>
            {
                var user = await db.Users.SingleOrDefaultAsync(x => x.UserName == username, cancellationToken);
                if(user != null) return Results.Ok(user);
                return Results.NotFound();

            });

           
        }
    }
}
