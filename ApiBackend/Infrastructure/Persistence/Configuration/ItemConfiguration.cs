using Domain.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasConversion(
                customerId => customerId.Value,
                value => new ItemId(value));

            builder.Property(c => c.ItemDescription).HasMaxLength(200);

            builder.Property(c => c.ItemState);

        }
    }
}