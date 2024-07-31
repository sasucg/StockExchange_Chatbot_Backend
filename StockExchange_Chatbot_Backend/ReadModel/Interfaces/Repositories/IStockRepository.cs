

using StockExchange_Chatbot_Backend.Models.DTOs;
using StockExchange_Chatbot_Backend.ReadModel.Entities;

namespace StockExchange_Chatbot_Backend.ReadModel.Interfaces.Repositories
{
    public interface IStockRepository
    {
        public Task<List<StockExchangeModel>> GetStockExchangeList(CancellationToken cancellationToken);
        public Task<List<StockModel>> GetStocksByStockExchangeId(int stockExchangeId, CancellationToken cancellationToken);
        public Task<StockModel> GetStockByStockId(int stockId, CancellationToken cancellationToken);
        public Task<EntityType> GetEntityTypeByCode(string entityTypeCode, CancellationToken cancellationToken);
        public Task SaveUserActivity(UserHistory userActivity, CancellationToken cancellationToken);

    }
}