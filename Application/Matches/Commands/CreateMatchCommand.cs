using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Application.Matches.Commands
{
    public class CreateMatchCommand : IRequest<int>
    {
        public string Description { get; set; }

        public DateTime MatchDate { get; set; }

        public DateTime MatchTime { get; set; }

        public string TeamA { get; set; }

        public string TeamB { get; set; }

       // public Sport Sport { get; set; }
    }

    public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateMatchCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
        {
            var entity = new Match
            {
                Description=request.Description,
                MatchDate=request.MatchDate,
                MatchTime=request.MatchTime,
                TeamA=request.TeamA,
                TeamB=request.TeamB
            };

            _context.Matches.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
