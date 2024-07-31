namespace StockExchange_Chatbot_Backend.Models.DTOs
{
    public class StockModel
    {
        public int StockExchangeId { get; set; }
        public int StockId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
