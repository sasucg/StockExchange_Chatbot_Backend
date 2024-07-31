using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockExchange_Chatbot_Backend.ReadModel.Entities;
using System.Reflection.Emit;

namespace StockExchange_Chatbot_Backend.Entities.EntityTypeConfiguration
{
    public class UserHistoryEntityConfiguration : IEntityTypeConfiguration<UserHistory>
    {
        public void Configure(EntityTypeBuilder<UserHistory> entity)
        {
            entity.ToTable(nameof(UserHistory));

            entity.HasKey(uxa => uxa.UserHistoryId);

            entity.Property(uxa => uxa.UserHistoryId)
                .ValueGeneratedOnAdd();

            entity.Property(uxa => uxa.Date)
                .IsRequired();
        }
    }
}
