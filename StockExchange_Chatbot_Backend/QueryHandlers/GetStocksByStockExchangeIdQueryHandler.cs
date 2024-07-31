using StockExchange_Chatbot_Backend.Models.DTOs;
using StockExchange_Chatbot_Backend.Models.QueryModels;
using StockExchange_Chatbot_Backend.ReadModel.Interfaces.Repositories;
using MediatR;

namespace StockExchange_Chatbot_Backend.Handlers
{
    public class GetStocksByExchangeIdQueryHandler : IRequestHandler<GetStocksByStockExchangeIdQueryModel, List<StockModel>>
    {
        private readonly IStockRepository _stockRepository;

        public GetStocksByExchangeIdQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<List<StockModel>> Handle(GetStocksByStockExchangeIdQueryModel request, CancellationToken cancellationToken)
        {
            List<StockModel> stockModelList = await _stockRepository.GetStocksByStockExchangeId(request.StockExchangeId, cancellationToken);
            
            if (!stockModelList.Any()) {
                throw new Exception("Stock list is empty");
            }

            return stockModelList;
        }
    }
}
