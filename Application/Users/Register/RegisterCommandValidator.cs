using FluentValidation;

namespace Application.Users.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(u => u.FirstName)
            .NotEmpty()
            .MinimumLength(2);

        RuleFor(u => u.LastName)
            .NotEmpty()
            .MinimumLength(2);

        RuleFor(u => u.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(u => u.PhoneNumber)
            .Must(IsNumeric)
            .WithMessage("Phone number must contain only numeric characters.");
    }

    private static bool IsNumeric(string phoneNumber) => phoneNumber.All(char.IsDigit);
}