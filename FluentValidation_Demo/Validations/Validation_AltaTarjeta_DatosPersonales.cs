using FluentValidation;
using FluentValidation_Demo.Entities;

namespace FluentValidation_Demo.Validations
{
    public class Validation_AltaTarjeta_DatosPersonales : AbstractValidator<AltaTarjeta>
    {
        public Validation_AltaTarjeta_DatosPersonales()
        {
            RuleFor(r => r.Nombre)
                .NotEmpty()
                .WithMessage("El nombre es obligatorio");

            RuleFor(r => r.Apellido)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotEqual(r => r.Nombre);

            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
