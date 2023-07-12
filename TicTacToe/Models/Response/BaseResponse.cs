namespace TicTacToe.Models.Response;

public abstract class BaseResponse<T>
{
    public Meta Meta { get; set; }

    public T Data { get; set; }
}

