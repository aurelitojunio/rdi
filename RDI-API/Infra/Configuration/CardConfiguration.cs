using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configuration
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("tb_cards");

            builder.HasKey(t => t.CardId);
            builder.Property(t => t.CustomerId).IsRequired(true);
            builder.Property(t => t.CardNumber).HasMaxLength(16).IsRequired(true);
            builder.Property(t => t.CVV).HasMaxLength(5).IsRequired(true);
            builder.Property(t => t.RegistrationDate);
            builder.Property(t => t.Token);
        }
    
    }
}
