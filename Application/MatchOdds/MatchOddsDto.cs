using Application.Common.Mappings;
using Application.Matches;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MatchOdds
{
    public class MatchOddDto : IMapFrom<MatchOdd>
    {
        public int Id { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public string Specifier { get; set; }

        public decimal Odd { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MatchOdd, MatchOddDto>();
            profile.CreateMap<Match, MatchDto>();

        }
    }
}
