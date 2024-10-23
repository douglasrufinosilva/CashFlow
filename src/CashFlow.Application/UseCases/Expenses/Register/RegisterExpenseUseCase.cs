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
        var title = request.Title;

        if (string.IsNullOrWhiteSpace(title))
        {

        }
    }
}
