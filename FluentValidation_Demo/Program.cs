using FluentValidation_Demo.Entities;
using FluentValidation_Demo.Validations;
using System;

namespace FluentValidation_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region [Asignando valores]
            AltaTarjeta altaTarjeta = new AltaTarjeta();
            altaTarjeta.Nombre = "Miguel";
            altaTarjeta.Apellido = "Morales";
            altaTarjeta.Email = "miguelmorales@churas.com";
            altaTarjeta.TipoTarjeta = "VIS";
            altaTarjeta.Tarjeta = "0000-0000-0000-0000";
            altaTarjeta.FechaVencimiento = new DateTime(2023, 01, 01);
            altaTarjeta.FechaNacimiento = new DateTime(2000, 01, 01);

            #endregion

            #region [Validador de datos personales]
            var validator1 = new Validation_AltaTarjeta_DatosPersonales();
            var resultado = validator1.Validate(altaTarjeta);

            //bool resp = resultado.IsValid;
            foreach (var error in resultado.Errors)
            {
                Console.WriteLine($"{error.PropertyName}: {error.ErrorMessage}");
            }

            #endregion

            #region [Validador de datos de pago]
            var validator2 = new Validation_AltaTarjeta_DatosPago();
            var resultado2 = validator2.Validate(altaTarjeta);

            foreach (var error in resultado2.Errors)
            {
                Console.WriteLine($"{error.PropertyName}: {error.ErrorMessage}");
            }

            #endregion


        }
    }
}
