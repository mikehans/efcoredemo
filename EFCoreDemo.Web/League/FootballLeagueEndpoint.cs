using FastEndpoints;
using EFCoreDemo.DataAccess;
using EFCoreDemo.Web.Contracts;
using System.Runtime.CompilerServices;

namespace EFCoreDemo.Web.League
{
    public class GetLeaguesEndpoint : EndpointWithoutRequest<List<LeagueResponse>>
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
            var results = await _svc.GetAll();
            List<LeagueResponse> responses = new();

            foreach (var result in results)
            {
                responses.Add(new() { Id = result.Id, Name = result.Name });
            }

            await Send.OkAsync(responses);
        }
    }

    public class AddLeagueEndpoint:Endpoint<LeagueRequest, LeagueAddedResponse>
    {
        readonly ILeagueService _svc;
        public AddLeagueEndpoint(ILeagueService svc)
        {
            _svc = svc;
        }
        public override void Configure()
        {
            Post("/league");
            AllowAnonymous();
        }

        public override async Task HandleAsync(LeagueRequest req, CancellationToken ct)
        {
            var rowsUpdated = await _svc.AddLeague(req.Name);
            
            await Send.CreatedAtAsync<AddLeagueEndpoint>(new LeagueAddedResponse(){RowsUpdated = rowsUpdated});
      
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

    public class LeagueAddedResponse
    {
        public int RowsUpdated { get; set; }
    }
}
