using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Matches.Commands.DeleteMatch
{
    public class DeleteMatchOddCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteMatchOddCommandHandler : IRequestHandler<DeleteMatchOddCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMatchOddCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMatchOddCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.MatchOdds.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Match), request.Id);
            }

            _context.MatchOdds.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
