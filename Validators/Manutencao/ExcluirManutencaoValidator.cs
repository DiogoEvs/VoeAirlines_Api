using VoeAirlines.Contexts;
using VoeAirlines.ViewModels;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace VoeAirlines.Validators;

public class ExcluirManutencaoValidator: AbstractValidator<int>
{
    private readonly VoeAirlinesContext _context;

    public ExcluirManutencaoValidator(VoeAirlinesContext context)
    {
        _context = context;

        RuleFor(id => _context.Manutencoes.Find(id))
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Id da manutenção inválido.")
            .Must(manutencao => manutencao!.DataHora > DateTime.Now).WithMessage("Não é possível excluir uma manutenção já realizada.");
    }
}