using ClienteAPI.Models.Entity;
using FluentValidation;

namespace ClienteAPI.Util.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator(ICPFValidator cpfValidator)
        {
            RuleFor(cliente => cliente.Cpf)
                .NotEmpty()
                .Must(cpfValidator.IsValid)
                .WithMessage("Invalid CPF format");

            RuleFor(cliente => cliente.Nome).NotEmpty();
            RuleFor(cliente => cliente.Estado).NotEmpty();
        }
    }
}