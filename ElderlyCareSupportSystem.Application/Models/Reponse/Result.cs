namespace ElderlyCareSupportSystem.Application.Models.Reponse;

public class Result
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

public class Result<T>(T data, bool isSuccess, string message = "") : Result(isSuccess, message)
{
    public T Data { get; set; } = data;

    public static Result<T> Success(T data)
    {
        return new Result<T>(data, true);
    }

    public new static Result<T> Fail(string message)
    {
        return new Result<T>(default, false, message);
    }
}