using FluentValidation;
using StockExchange_Chatbot_Backend.Commands;

public class RecordUserActivityCommandValidator : AbstractValidator<RecordUserActivityCommand>
{
    public RecordUserActivityCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
        RuleFor(x => x.EntityId).NotEmpty().WithMessage("EntityId is required.");
        RuleFor(x => x.EntityTypeCode).NotEmpty().WithMessage("EntityTypeCode is required.");
    }
}