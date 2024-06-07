using bookstore.api.Models;
using FluentValidation;

namespace bookstore.api.Validations
{
	public class UserValidator : AbstractValidator<User>
	{
		public UserValidator() 
		{
			RuleFor(user => user.Name).NotNull().NotEmpty();
			RuleFor(user => user.Email).NotNull().NotEmpty().EmailAddress();

			RuleFor(user => user.Password)
				.NotNull().NotEmpty()
				.MinimumLength(8)
				.Must(password => password.FirstOrDefault(character => character >= 'a' &&
				character <= 'z') != 0)
					.WithMessage("Password should contain at least one lowercase letter")
				.Must(password => password.FirstOrDefault(character => character >= 'A' &&
				character <= 'Z') != 0)
					.WithMessage("Password should contain at least one uppercase letter")
				.Must(password => password.FirstOrDefault(character => character >= '0' &&
				character <= '9') != 0)
					.WithMessage("Password should contain at least one digit");
		}
	}
}
