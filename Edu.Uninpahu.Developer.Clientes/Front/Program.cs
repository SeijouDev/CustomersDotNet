using Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front
{
    class Program
    {
        static void Main(string[] args)
        {
            var control = new Control();
            var lista = control.GenerarClientes();
            lista.ForEach((c)=> Console.WriteLine(c.Edad));
            Console.ReadKey();
        }
    }
}
