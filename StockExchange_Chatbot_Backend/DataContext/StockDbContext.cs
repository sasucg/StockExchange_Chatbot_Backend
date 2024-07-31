using StockExchange_Chatbot_Backend.Entities.EntityTypeConfiguration;
using StockExchange_Chatbot_Backend.ReadModel.Entities;
using EntityType = StockExchange_Chatbot_Backend.ReadModel.Entities.EntityType;
using Microsoft.EntityFrameworkCore;

namespace StockExchange_Chatbot_Backend.DataContext
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<StockExchange> StockExchanges { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<EntityType> EntityTypes { get; set; }
        public virtual DbSet<UserHistory> UserHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntityTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StockExchangeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StockEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserHistoryEntityConfiguration());
        }
    }
}
