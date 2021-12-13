using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Identity;
using Application.Common.Interfaces;
using Domain.Entities;
using System;
using Domain.Common;

namespace Infrastructure.Db
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        //private readonly ICurrentUserService _currentUserService;
        //private readonly IDateTime _dateTime;
        //private readonly IDomainEventService _domainEventService;

        //public ApplicationDbContext(
        //    DbContextOptions options,
        //    IOptions<OperationalStoreOptions> operationalStoreOptions,
        //    ICurrentUserService currentUserService,
        //    IDomainEventService domainEventService,
        //    IDateTime dateTime) : base(options, operationalStoreOptions)
        //{
        //    _currentUserService = currentUserService;
        //    _domainEventService = domainEventService;
        //    _dateTime = dateTime;
        //}

        public ApplicationDbContext(
          DbContextOptions options,
          IOptions<OperationalStoreOptions> operationalStoreOptions
         ) : base(options, operationalStoreOptions)
        {
            
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchOdd> MatchOdds { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.CreatedBy = _currentUserService.UserId;
                        //entry.Entity.Created = _dateTime.Now;
                        entry.Entity.CreatedBy ="admin";
                        entry.Entity.Created = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = "admin";
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

           //await DispatchEvents();

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        //private async Task DispatchEvents()
        //{
        //    while (true)
        //    {
        //        var domainEventEntity = ChangeTracker.Entries<IHasDomainEvent>()
        //            .Select(x => x.Entity.DomainEvents)
        //            .SelectMany(x => x)
        //            .Where(domainEvent => !domainEvent.IsPublished)
        //            .FirstOrDefault();
        //        if (domainEventEntity == null) break;

        //        domainEventEntity.IsPublished = true;
        //        await _domainEventService.Publish(domainEventEntity);
        //    }
        //}
    }
}
