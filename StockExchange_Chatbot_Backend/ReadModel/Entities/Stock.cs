namespace StockExchange_Chatbot_Backend.ReadModel.Entities
{
    public class Stock
    {
        public int StockId { get; set; }
        public int StockExchangeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public StockExchange StockExchange { get; set; }
    }
}
