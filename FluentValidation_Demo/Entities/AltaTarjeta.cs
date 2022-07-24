using System;

namespace FluentValidation_Demo.Entities
{
    public class AltaTarjeta
    {
        public string Nombre { get; set; } //Requerido
        public string Apellido { get; set; } // Requerido y no puede ser igual que el nombre
        public string Email { get; set; } // Requerido y que sea un mail
        public string TipoTarjeta { get; set; } // Requerido y debe ser VIS o MAS
        public string Tarjeta { get; set; } // Si se carga tipo tarjeta, es requerido y debe ser un numero de tarjeta valido
        public DateTime FechaVencimiento { get; set; } // Requerido y sea posterior a Hoy +3
        public DateTime FechaNacimiento { get; set; } // Mayor de 18 y menor de 70 años
    }
}
