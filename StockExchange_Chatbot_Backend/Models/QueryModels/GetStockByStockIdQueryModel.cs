using StockExchange_Chatbot_Backend.Models.DTOs;
using MediatR;

namespace StockExchange_Chatbot_Backend.Models.QueryModels
{
    public class GetStockByStockIdQueryModel : IRequest<StockModel>
    {
        public int StockId { get; set; }

        public GetStockByStockIdQueryModel(int stockId)
        {
            StockId = stockId;
        }
    }
}
