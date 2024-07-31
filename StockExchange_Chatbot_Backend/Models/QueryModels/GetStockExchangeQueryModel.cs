using StockExchange_Chatbot_Backend.Models.DTOs;
using MediatR;

namespace StockExchange_Chatbot_Backend.Models.QueryModels
{
    public class GetStockExchangeQueryModel : IRequest<List<StockExchangeModel>>
    {
    }
}
