using StockExchange_Chatbot_Backend.Models.QueryModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockExchange_Chatbot_Backend.Models.DTOs;
using StockExchange_Chatbot_Backend.Commands;
using StockExchange_Chatbot_Backend.Events;


namespace StockExchange_Chatbot_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatbotController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChatbotController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("stockExchange")]
        public async Task<List<StockExchangeModel>> GetStockExchange(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetStockExchangeQueryModel(), cancellationToken);
        }

        [HttpGet]
        [Route("stockExchange/{stockExchangeId}/stocks")]
        public async Task<List<StockModel>> GetStocksByStockExchangeId(int stockExchangeId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetStocksByStockExchangeIdQueryModel(stockExchangeId), cancellationToken);
        }

        [HttpGet]
        [Route("stockExchange/stocks/{stockId}")]
        public async Task<StockModel> GetStockById(int stockId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetStockByStockIdQueryModel(stockId), cancellationToken);
        }

        [HttpPost]
        [Route("stockExchange")]
        public async Task<ActionResult<ApiResponse>> RecordUserActivity(RecordUserActivityCommand command)
        {
            ApiResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}

