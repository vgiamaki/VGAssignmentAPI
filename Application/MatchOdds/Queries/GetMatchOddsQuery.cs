using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using System.Collections.Generic;

namespace Application.MatchOdds.Queries
{
    public class GetMatchOddsQuery : IRequest<IList<MatchOddDto>>
    {
    }

    public class GetMatchOddsQueryHandler : IRequestHandler<GetMatchOddsQuery, IList<MatchOddDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMatchOddsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<MatchOddDto>> Handle(GetMatchOddsQuery request, CancellationToken cancellationToken)
        {
            //var  list = await _context.MatchOdds.Include(n=>n.Match).ProjectTo<MatchOddDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var list = await _context.MatchOdds.ProjectTo<MatchOddDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return list;
        }
    }
}
