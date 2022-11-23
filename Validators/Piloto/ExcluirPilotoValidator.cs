using VoeAirlines.Contexts;
using VoeAirlines.ViewModels;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace VoeAirlines.Validators;

public class ExcluirPilotoValidator: AbstractValidator<int>
{
    private readonly VoeAirlinesContext _context;
    public ExcluirPilotoValidator(VoeAirlinesContext context)
    {
        _context = context;

        RuleFor(id => _context.Pilotos.Include(p => p.Voos).FirstOrDefault(p => p.Id == id))
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Id do piloto inválido")
            .Must(piloto => piloto!.Voos.Count == 0).WithMessage("Não é possível excluir um piloto que já realizou voos.");
    }
}