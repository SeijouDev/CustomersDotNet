using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Identificacion { get; set; }

        public Cliente()
        {

        }

        public Cliente (string nombre, DateTime fechaNacimiento, string identificacion)
        {
            this.Nombre = nombre;
            this.FechaNacimiento = fechaNacimiento;
            this.Identificacion = identificacion;
            this.Edad = CalcularEdad();
        }

        private int CalcularEdad()
        {
            return (DateTime.Today.Year - this.FechaNacimiento.Year);
        }

        public override string ToString()
        {
            return $"-Nombre: {this.Nombre}\n-Fecha nacimiento: {this.FechaNacimiento}\n-Id: {this.Identificacion}\n-Edad: {this.Edad}\n---";
        }
    }
}
