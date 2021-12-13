using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Match : AuditableEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime MatchDate { get; set; }

        public DateTime MatchTime { get; set; }

        public string TeamA { get; set; }

        public string TeamB { get; set; }

        public Sport Sport { get; set; }

        public IList<MatchOdd> MatchOdds { get; private set; } = new List<MatchOdd>();

    }
}
