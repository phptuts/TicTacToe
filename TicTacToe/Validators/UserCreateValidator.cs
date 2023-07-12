using FluentValidation;
using TicTacToe.Interfaces;
using TicTacToe.Models.Users;

namespace TicTacToe.Validators;

public class UserCreateValidator : AbstractValidator<UserCreate>
{
    public UserCreateValidator(IUserService userService)
    {
        RuleFor(u => u.Email).NotEmpty().EmailAddress()
            .WithMessage("Email must be valid")
            .MustAsync(async (email, cancelToken) =>
            {
                var  isAvailable = await userService.IsEmailAvailable(email);
                return isAvailable;
            })
            .WithMessage("Email already taken.");

        RuleFor(u => u.Password)
            .NotEmpty()
            .MinimumLength(8).MaximumLength(30)
            .Matches(@"^(?=.*?[^\w\s]).{8,}$")
            .WithMessage("Password must be at least 8 characters long and contain at least one special character.");
    }
}

