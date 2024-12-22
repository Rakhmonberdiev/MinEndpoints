using MinEndpoints.Abstractions;


namespace MinEndpoints.Endpoints
{
    public class Get : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("get",()=>"Hello world");
        }
    }
}
