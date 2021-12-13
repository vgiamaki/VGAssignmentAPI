using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Db.Configurations
{
    public class MatchOddConfiguration : IEntityTypeConfiguration<MatchOdd>
    {
        public void Configure(EntityTypeBuilder<MatchOdd> builder)
        {
            builder.Property(t => t.Odd)
                .HasPrecision(19,2);
        }
    }
}
