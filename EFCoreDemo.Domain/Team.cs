namespace EFCoreDemo.Domain
{
    public class Team
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public int LeagueId { get; set; }
        public virtual League League { get; set; }
    }
}
