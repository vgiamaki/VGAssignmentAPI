using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Matches.Commands.DeleteMatch
{
    public class DeleteMatchCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteMatchCommandHandler : IRequestHandler<DeleteMatchCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMatchCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMatchCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Matches.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Match), request.Id);
            }

            _context.Matches.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
