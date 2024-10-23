using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        return new ResponseRegisteredExpenseJson
        {
            Title = request.Title
        };
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);

        if (titleIsEmpty)
        {
            throw new ArgumentException("O título é obrigatório.");
        }

        if(request.Amount <= 0)
        {
            throw new ArgumentException("O Valor deve ser maior que zero.");
        }

        var dateResult = DateTime.Compare(request.Date, DateTime.UtcNow);

        if(dateResult > 0)
        {
            throw new ArgumentException("Insira uma data válida.");
        }

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);

        if (!paymentTypeIsValid)
        {
            throw new ArgumentException("Tipo de pagamento inválido.");
        }

    }
}
