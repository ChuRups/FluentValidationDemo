using FluentValidation;
using FluentValidation_Demo.Entities;
using System;

namespace FluentValidation_Demo.Validations
{
    public class Validation_AltaTarjeta_DatosPago : AbstractValidator<AltaTarjeta>
    {
        public Validation_AltaTarjeta_DatosPago()
        {
            RuleFor(r => r.TipoTarjeta)
                .NotEmpty()
                .Must(ValidaTipoTarjeta);

            RuleFor(r => r.Tarjeta)
                // .NotEmpty() ---> Esto se usaría si es que siempre debería tener un valor, pero no es el caso porque solo si el tipo de tarjeta tiene valor entonces Tarjeta tambien
                .NotEmpty().When(ValidaIngresoTarjeta)
                .CreditCard();

            RuleFor(r => r.FechaVencimiento).GreaterThan(DateTime.Now.AddMonths(3));

            RuleFor(r => r.FechaNacimiento).Must(ValidaEdad);

            // Agregar expresion regular
            RuleFor(r => r.Nombre).Matches("@/[1-3]");
        }

        private bool ValidaTipoTarjeta(string tipo)
        {
            if (tipo == "VIS" || tipo == "MAS")
                return true;

            return false;
        }

        private bool ValidaIngresoTarjeta(AltaTarjeta alta)
        {
            return string.IsNullOrEmpty(alta.TipoTarjeta) ? false : true;
        }

        private bool ValidaEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;

            if (DateTime.Now.Month > fechaNacimiento.Month) --edad; // restarle la edad -1 porque todavia no ha cumplido

            if (edad >= 18 && edad <= 70) return true;

            return false;
        }
    }
}
