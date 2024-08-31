namespace SharedKernel;

public readonly struct Result<TValue, TError>
{
    private readonly TValue? _value;
    private readonly TError? _error;

    private Result(TValue value)
    {
        IsSuccess = true;
        _value = value;
        _error = default;
    }

    private Result(TError error)
    {
        IsSuccess = false;
        _error = error;
        _value = default;
    }

    public bool IsSuccess { get; }
    public bool IsError => !IsSuccess;
    public TValue? Value => _value;
    public TError? Error => _error;

    public static implicit operator Result<TValue, TError>(TValue value) => new(value);
    public static implicit operator Result<TValue, TError>(TError error) => new(error);

    public TResult Match<TResult>(
        Func<TValue, TResult> success,
        Func<TError, TResult> failure) =>
            IsSuccess ? success(_value!) : failure(_error!);
}