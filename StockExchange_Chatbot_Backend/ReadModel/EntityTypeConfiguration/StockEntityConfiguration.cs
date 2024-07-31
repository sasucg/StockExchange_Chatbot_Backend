using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockExchange_Chatbot_Backend.ReadModel.Entities;

namespace StockExchange_Chatbot_Backend.Entities.EntityTypeConfiguration
{
    public class StockEntityConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> entity)
        {
            entity.ToTable(nameof(Stock));

            entity.HasKey(s => s.StockId);

            entity.Property(s => s.StockId)
                .ValueGeneratedOnAdd(); 

            entity.Property(s => s.Code)
                .IsRequired()
                .HasMaxLength(10); 

            entity.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100); 

            entity.Property(s => s.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)"); 

            entity.HasOne(s => s.StockExchange)
                .WithMany(se => se.Stocks)
                .HasForeignKey(s => s.StockExchangeId)
                .OnDelete(DeleteBehavior.Cascade); 

        }
    }
}
