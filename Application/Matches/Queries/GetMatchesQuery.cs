using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Matches.Queries.GetMatchesWithPagination
{ 
    public class GetMatchesWithPaginationQuery : IRequest<PaginatedList<MatchDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetMatchesWithPaginationQueryHandler : IRequestHandler<GetMatchesWithPaginationQuery, PaginatedList<MatchDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMatchesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<MatchDto>> Handle(GetMatchesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Matches.Include(n=>n.MatchOdds)
                .ProjectTo<MatchDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
