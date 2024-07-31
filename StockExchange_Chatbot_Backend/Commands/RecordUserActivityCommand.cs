using MediatR;
using StockExchange_Chatbot_Backend.Events;

namespace StockExchange_Chatbot_Backend.Commands
{
    public class RecordUserActivityCommand : IRequest<ApiResponse>
    {
        public int UserId { get; set; }
        public int EntityId { get; set; }
        public string EntityTypeCode { get; set; }
    }
}
