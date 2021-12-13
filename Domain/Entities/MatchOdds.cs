using Domain.Common;

namespace Domain.Entities
{
    public class MatchOdd : AuditableEntity
    {
        public int Id { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public string Specifier { get; set; }

        public decimal Odd { get; set; }

    }
}
