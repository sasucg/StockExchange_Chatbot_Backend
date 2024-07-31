using StockExchange_Chatbot_Backend.DataContext;
using StockExchange_Chatbot_Backend.ReadModel.Interfaces.Repositories;
using StockExchange_Chatbot_Backend.Models.DTOs;
using StockExchange_Chatbot_Backend.ReadModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace StockExchange_Chatbot_Backend.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly StockDbContext _context;
        public StockRepository(StockDbContext context)
        {
            _context = context;
        }
        public async Task<List<StockExchangeModel>> GetStockExchangeList(CancellationToken cancellationToken)
        {

            return await _context.StockExchanges.Select(stockExchange => new StockExchangeModel()
            {
                Code = stockExchange.Code,
                Name = stockExchange.Name,
                StockExchangeId = stockExchange.StockExchangeId,
            }).ToListAsync(cancellationToken);
        }

        public async Task<List<StockModel>> GetStocksByStockExchangeId(int stockExchangeId, CancellationToken cancellationToken)
        {
            return await _context.Stocks
             .Where(stock => stock.StockExchangeId == stockExchangeId)
             .Select(stock => new StockModel()
             {
                 StockId = stock.StockId,
                 StockExchangeId = stock.StockExchangeId,
                 Code = stock.Code,
                 Name = stock.Name,
                 Price = stock.Price,
             })
             .ToListAsync(cancellationToken);
        }
        
        public async Task<StockModel> GetStockByStockId(int stockId, CancellationToken cancellationToken)
        {
            return await _context.Stocks
             .Where(stock => stock.StockId == stockId)
             .Select(stock => new StockModel()
             {
                 StockId = stock.StockId,
                 StockExchangeId = stock.StockExchangeId,
                 Code = stock.Code,
                 Name = stock.Name,
                 Price = stock.Price,
             })
             .FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<EntityType> GetEntityTypeByCode(string entityTypeCode, CancellationToken cancellationToken)
        {
            return await _context.EntityTypes
             .Where(entityType => entityType.Code == entityTypeCode)
             .FirstOrDefaultAsync(cancellationToken);
        }
        
        public async Task SaveUserActivity(UserHistory userActivity, CancellationToken cancellationToken)
        {
            await _context.UserHistories.AddAsync(userActivity, cancellationToken);
            _context.SaveChanges();
        }
    }
}
