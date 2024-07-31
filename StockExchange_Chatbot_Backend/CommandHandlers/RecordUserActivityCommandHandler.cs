using StockExchange_Chatbot_Backend.ReadModel.Interfaces.Repositories;
using StockExchange_Chatbot_Backend.Commands;
using MediatR;
using FluentValidation;
using StockExchange_Chatbot_Backend.ReadModel.Entities;
using StockExchange_Chatbot_Backend.Events;

namespace StockExchange_Chatbot_Backend.CommandHandlers
{
    public class RecordUserActivityCommandHandler : IRequestHandler<RecordUserActivityCommand, ApiResponse>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IValidator<RecordUserActivityCommand> _validator;

        public RecordUserActivityCommandHandler(IStockRepository stockRepository, IValidator<RecordUserActivityCommand> validator)
        {
            _stockRepository = stockRepository;
            _validator = validator;
        }

        public async Task<ApiResponse> Handle(RecordUserActivityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                EntityType entityType = await _stockRepository.GetEntityTypeByCode(request.EntityTypeCode, cancellationToken);
                UserHistory userActivity = new UserHistory()
                {
                    EntityTypeId = entityType.EntityTypeId,
                    UserId = request.UserId,
                    EntityId = request.UserId,
                    Date = DateTime.UtcNow,
                };
               
                await _stockRepository.SaveUserActivity(userActivity, cancellationToken);

                return new ApiResponse
                {
                    Event = "USER_ACTIVITY_SAVED"
                };
               
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Event = "USER_ACTIVITY_SAVED_FAILED",
                    Message = ex.Message
                };
            }
        }
    }
}
