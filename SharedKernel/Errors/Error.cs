namespace SharedKernel.Errors;

public sealed record Error(string Code, int StatusCode, string? Description = null)
{
    public static readonly Error None = new(string.Empty, 0, string.Empty);
}
