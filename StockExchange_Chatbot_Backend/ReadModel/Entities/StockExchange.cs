using Microsoft.AspNetCore.Http.HttpResults;

namespace StockExchange_Chatbot_Backend.ReadModel.Entities
{
    public class StockExchange
    {
        public int StockExchangeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}
