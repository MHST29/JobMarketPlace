using JobMarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMarketPlace.Infrastructure.Data.Configurations
{
    public class ContractorConfiguration : IEntityTypeConfiguration<Contractor>
    {
        public void Configure(
            EntityTypeBuilder<Contractor> builder)
        {
            builder.ToTable("Contractor");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(400);
            builder.HasIndex(x => x.Name);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

        }
    }
}