namespace RashaPrimeWeb.Application.Common;

public class ResultDto
{
    public bool IsSuccess { get; init; }
    public bool IsFailure
        => !IsSuccess;

    public string Message { get; init; }

    public ResultDto()
      => IsSuccess = true;

    public ResultDto(string message)
    {
        IsSuccess = false;
        Message = message;
    }


    public static ResultDto Failure(string msg)
         => new(msg);

    public static ResultDto Success()
        => new();
}