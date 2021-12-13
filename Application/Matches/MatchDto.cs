using AutoMapper;
using System;
using Application.Common.Mappings;
using Domain.Entities;
using System.Collections.Generic;
using Application.MatchOdds;

namespace Application.Matches
{
    public class MatchDto : IMapFrom<Match>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime MatchDate { get; set; }

        public DateTime MatchTime { get; set; }

        public string TeamA { get; set; }

        public string TeamB { get; set; }

        public int Sport { get; set; }

        public IList<MatchOdd> MatchOdds { get; private set; } = new List<MatchOdd>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Match, MatchDto>()
                .ForMember(d => d.Sport, opt => opt.MapFrom(s => (int)s.Sport));

            profile.CreateMap<MatchOdd, MatchOddDto>();
        }
    }
}
