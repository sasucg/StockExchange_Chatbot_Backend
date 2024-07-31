using StockExchange_Chatbot_Backend.Models.DTOs;
using StockExchange_Chatbot_Backend.Models.QueryModels;
using StockExchange_Chatbot_Backend.ReadModel.Interfaces.Repositories;
using MediatR;

namespace StockExchange_Chatbot_Backend.Handlers
{
    public class GetStockByStockIdQueryHandler : IRequestHandler<GetStockByStockIdQueryModel, StockModel>
    {
        private readonly IStockRepository _stockRepository;

        public GetStockByStockIdQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<StockModel> Handle(GetStockByStockIdQueryModel request, CancellationToken cancellationToken)
        {
            StockModel stock = await _stockRepository.GetStockByStockId(request.StockId, cancellationToken);

            if (stock == null) {
                throw new Exception("Stock not found");
            }

            return stock;
        }
    }
}
