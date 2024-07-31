using StockExchange_Chatbot_Backend.Models.DTOs;
using StockExchange_Chatbot_Backend.Models.QueryModels;
using StockExchange_Chatbot_Backend.ReadModel.Interfaces.Repositories;
using MediatR;

namespace StockExchange_Chatbot_Backend.Handlers
{
    public class GetStockExchangeQueryHandler : IRequestHandler<GetStockExchangeQueryModel, List<StockExchangeModel>>
    {
        private readonly IStockRepository _stockRepository;
        public GetStockExchangeQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public async Task<List<StockExchangeModel>> Handle(GetStockExchangeQueryModel request, CancellationToken cancellationToken)
        {
            List<StockExchangeModel> stockList = await _stockRepository.GetStockExchangeList(cancellationToken);
            
            if (!stockList.Any())
            {
                throw new Exception("Stock exchange list is empty");
            }

            return stockList;
        }
    }
}
