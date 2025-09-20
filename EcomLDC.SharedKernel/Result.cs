namespace Ecom.SharedKernel;

// نتيجة موحدة لعمليات الدومين/التطبيق (نجاح/فشل + رسالة)
public class Result
{
    public bool IsSuccess { get; }
    public string? Error { get; }

    protected Result(bool ok, string? error) { IsSuccess = ok; Error = error; }

    public static Result Success() => new(true, null); //Factory method 34an ta3mil success result
    public static Result Failure(string error) => new(false, error); //Factory method 34an ta3mil error result
    public static Result<T> Success<T>(T value) => new(value, true, null); //Factory method 34an ta3mil success result with value (data min 3mlya mslan )
    public static Result<T> Failure<T>(string error) => new(default!, false, error); //Factory method 34an ta3mil error result with value al fashlit (btrag3 value fadya )
}

public class Result<T> : Result
{
    //bshil al value lama ykoon success 
    public T Value { get; }

    internal Result(T value, bool isSuccess, string? error) : base(isSuccess, error) //Constructor byrbot byn al base class w al derived class
        => Value = value;
}

