namespace ElderlyCareSupportSystem.Application.Models.Response;

public record Result
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public Result(bool isSuccess, string message = "")
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public static Result Success(string message = "")
    {
        return new Result(true, message);
    }

    public static Result Fail(string message)
    {
        return new Result(false, message);
    }
}

public record Result<T>(T Data, bool IsSuccess, string Message = "") : Result(IsSuccess, Message)
{
    public T Data { get; set; } = Data;

    public static Result<T> Success(T data)
    {
        return new Result<T>(data, true);
    }

    public new static Result<T> Fail(string message)
    {
        return new Result<T>(default, false, message);
    }
}