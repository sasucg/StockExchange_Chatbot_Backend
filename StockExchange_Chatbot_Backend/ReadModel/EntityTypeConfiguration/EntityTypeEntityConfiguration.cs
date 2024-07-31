using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EntityType = StockExchange_Chatbot_Backend.ReadModel.Entities.EntityType;

namespace StockExchange_Chatbot_Backend.Entities.EntityTypeConfiguration
{
    public class EntityTypeEntityConfiguration : IEntityTypeConfiguration<EntityType>
    {
        public void Configure(EntityTypeBuilder<EntityType> entity)
        {
            entity.ToTable(nameof(EntityType));

            entity.HasKey(a => a.EntityTypeId);

            entity.Property(a => a.EntityTypeId)
                .ValueGeneratedOnAdd(); 

            entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(a => a.Code)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
