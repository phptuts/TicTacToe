namespace TicTacToe.Models.Response;
public class FormErrorResponse: BaseResponse<Dictionary<string, List<string>>>
{
    public FormErrorResponse(Dictionary<string, List<string>> errors)
    {
        Meta = new()
        {
            Type = "form_error",
        };
        Data = errors;
    }
}

