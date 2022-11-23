using VoeAirlines.Contexts;
using FluentValidation;

namespace VoeAirlines.Validators;

public class ExcluirVooValidator: AbstractValidator<int>
{
    private readonly VoeAirlinesContext _context;

    public ExcluirVooValidator(VoeAirlinesContext context)
    {
        _context = context;

        RuleFor(id => _context.Voos.Find(id))
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Id de voo inválido.")
            .Must(voo => voo!.DataHoraChegada >= DateTime.Now).WithMessage("Não é possível excluir um voo já finalizado.");
    }
}