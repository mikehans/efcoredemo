using FastEndpoints;
using EFCoreDemo.DataAccess;
using EFCoreDemo.Web.Contracts;

namespace EFCoreDemo.Web.League
{
    public class GetLeaguesEndpoint : EndpointWithoutRequest<LeagueResponse>
    {
        readonly ILeagueService _svc;
        public GetLeaguesEndpoint(ILeagueService svc)
        {
            _svc = svc;
        }
        public override void Configure()
        {
            Get("/league");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            // read from DB
            await Send.OkAsync(new()
            {
                Id=1,
                Name="Cats"
            });
        }
    }

    public class AddLeagueEndpoint:Endpoint<LeagueRequest, LeagueResponse>
    {
        public override void Configure()
        {
            Post("/league");
            AllowAnonymous();
        }

        public override async Task HandleAsync(LeagueRequest req, CancellationToken ct)
        {
            
            await Send.CreatedAtAsync<AddLeagueEndpoint>();
        }
    }


    public class LeagueRequest
    {
        public string Name { get; set; }
    }

    public class LeagueResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
