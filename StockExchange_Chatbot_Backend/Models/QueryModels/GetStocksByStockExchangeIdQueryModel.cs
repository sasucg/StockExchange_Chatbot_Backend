using StockExchange_Chatbot_Backend.Models.DTOs;
using MediatR;

namespace StockExchange_Chatbot_Backend.Models.QueryModels
{
    public class GetStocksByStockExchangeIdQueryModel : IRequest<List<StockModel>>
    {
        public int StockExchangeId { get; set; }

        public GetStocksByStockExchangeIdQueryModel(int stockExchangeId)
        {
            StockExchangeId = stockExchangeId;
        }
    }
}
