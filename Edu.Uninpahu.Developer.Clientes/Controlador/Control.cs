using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class Control
    {
        private const string consonantes = "bcdfghjklmnpqrstvwxyz";
        private const string vocales = "aeiou";
        private Random random = new Random();

        public List<Cliente> GenerarClientes()
        {
            var lista = new List<Cliente>();
            for(var i = 0; i < 1000; i++)
                lista.Add(CrearCliente());

            GuardarLista(lista);

            return lista;
        }

        private Cliente CrearCliente()
        {
            return new Cliente(GenerarNombre(), GenerarFechaNacimiento(), GenerarIdentificacion());
        }

        private string GenerarNombre()
        {
            var nombre = string.Empty;
            var builder = new StringBuilder();
            var cantidad_palabras = random.Next(3, 5);
            var longitud_palabra = random.Next(3, 13);      

            for (var j = 0; j < cantidad_palabras; j++)
            {
                builder.Append(vocales[random.Next(vocales.Length)].ToString().ToUpper());
                longitud_palabra--;

                for (var i = 0; i < longitud_palabra; i++)                
                    builder.Append(consonantes[random.Next(consonantes.Length)]);
                
                builder.Append(" ");
            }

            nombre = builder.ToString();

            return nombre;
        }

        private string GenerarIdentificacion()
        {
            return random.Next(10000, 1000000000).ToString();
        }

        private DateTime GenerarFechaNacimiento()
        {
            var fecha_inicio = DateTime.Today.AddYears(-100);
            var fecha_limite = DateTime.Today.AddYears(-18);
            var dias = Convert.ToInt32((fecha_limite - fecha_inicio).TotalDays);            
            return fecha_inicio.AddDays(random.Next(dias));
        }

        public void GuardarLista(List<Cliente> lista)
        {
            new Data().GuardarListaClientes(lista);
        }

        public List<Cliente> ObtenerLista()
        {
            return new Data().LeerClientes();
        }
    }
}
