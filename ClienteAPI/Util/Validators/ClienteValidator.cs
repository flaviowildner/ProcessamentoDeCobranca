using ClienteAPI.Models.Entity;
using FluentValidation;

namespace ClienteAPI.Util.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        private readonly ICPFValidator _cpfValidator;

        public ClienteValidator(ICPFValidator cpfValidator)
        {
            _cpfValidator = cpfValidator;
        }

        public ClienteValidator()
        {
            RuleFor(cliente => cliente.Cpf)
                .NotEmpty()
                .Must(_cpfValidator.IsValid);

            RuleFor(cliente => cliente.Nome).NotEmpty();
            RuleFor(cliente => cliente.Estado).NotEmpty();
        }
    }
}