using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Application.Matches.Commands.UpdateMatch
{
    public class UpdateMatchOddCommand : IRequest
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public string Specifier { get; set; }
        public decimal Odd { get; set; }
    }

    public class UpdateMatchOddCommandHandler : IRequestHandler<UpdateMatchOddCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMatchOddCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMatchOddCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.MatchOdds.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(MatchOdd), request.Id);
            }

            entity.Id = request.Id;
            entity.MatchId = request.MatchId;
            entity.Specifier = request.Specifier;
            entity.Odd = request.Odd;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
