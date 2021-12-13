using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Match> Matches { get; set; }

        DbSet<MatchOdd> MatchOdds { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
