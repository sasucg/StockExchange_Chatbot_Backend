using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockExchange_Chatbot_Backend.ReadModel.Entities;

namespace StockExchange_Chatbot_Backend.Entities.EntityTypeConfiguration
{
    public class StockExchangeEntityConfiguration : IEntityTypeConfiguration<StockExchange>
    {
        public void Configure(EntityTypeBuilder<StockExchange> entity)
        {
            entity.ToTable(nameof(StockExchange));

            entity.HasKey(se => se.StockExchangeId);

            entity.Property(se => se.StockExchangeId)
                .ValueGeneratedOnAdd(); 

            entity.Property(se => se.Code)
                .IsRequired()
                .HasMaxLength(10); 

            entity.Property(se => se.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasMany(se => se.Stocks)
                .WithOne(s => s.StockExchange);
        }
    }
}
