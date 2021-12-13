using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Application.Matches.Commands.UpdateMatch
{
    public class UpdateMatchCommand : IRequest
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime MatchDate { get; set; }

        public DateTime MatchTime { get; set; }

        public string TeamA { get; set; }

        public string TeamB { get; set; }
    }

    public class UpdateMatchCommandHandler : IRequestHandler<UpdateMatchCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMatchCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMatchCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Matches.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Match), request.Id);
            }

            entity.Description = request.Description;
            entity.MatchDate = request.MatchDate;
            entity.MatchTime = request.MatchTime;
            entity.TeamA = request.TeamA;
            entity.TeamB = request.TeamB;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
