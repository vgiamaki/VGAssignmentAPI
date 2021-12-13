using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Application.Matches.Commands
{
    public class CreateMatchOddCommand : IRequest<int>
    {
        public int MatchId { get; set; }
     
        public string Specifier { get; set; }

        public decimal Odd { get; set; }

    }

    public class CreateMatchOddCommandHandler : IRequestHandler<CreateMatchOddCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateMatchOddCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMatchOddCommand request, CancellationToken cancellationToken)
        {
            var entity = new MatchOdd
            {
                MatchId=request.MatchId,
                Specifier = request.Specifier,
                Odd = request.Odd
            };

            _context.MatchOdds.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
