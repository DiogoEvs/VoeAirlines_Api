using VoeAirlines.Contexts;
using VoeAirlines.ViewModels;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


namespace VoeAirlines.Validators;

public class CancelarVooValidator : AbstractValidator<CancelarVooViewModel>
{
    private readonly VoeAirlinesContext _context;

    public CancelarVooValidator(VoeAirlinesContext context)
    {
        _context = context;

        RuleFor(c => c).Custom((cancelamento, validationContext) => {
            var voo = _context.Voos.Include(v => v.Cancelamento)
                                   .FirstOrDefault(v => v.Id == cancelamento.VooId);

            if (voo == null)
            {
                validationContext.AddFailure("Id de voo inválido.");
            }
            else
            {
                if (voo.Cancelamento != null)
                {
                    validationContext.AddFailure("Não é possível cancelar um voo que já foi cancelado.");
                }

                if (voo.DataHoraPartida <= DateTime.Now && voo.DataHoraChegada >= DateTime.Now)
                {
                    validationContext.AddFailure("Não é possível cancelar um voo em andamento.");
                }

                if (voo.DataHoraChegada <= DateTime.Now)
                {
                    validationContext.AddFailure("Não é possível cancelar um voo já finalizado.");
                }
            }
        });
    }
}