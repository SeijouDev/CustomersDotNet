using Controlador;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Front
{
    class Program
    {
        static void Main(string[] args)
        {
            Iniciar();
        }

        public static void Iniciar()
        {
            var control = new Control();
            var lista = MostrarPrimerMenu(control);

            while (lista.Count < 1)
            {
                Console.WriteLine("\nNo hay clientes guardados, presione una tecla para continuar. \n");
                Console.ReadKey();
                lista = MostrarPrimerMenu(control);
            }

            MostrarSegundoMenu(lista);
            MostrarTercerMenu();
        }

        public static List<Cliente> MostrarPrimerMenu(Control control)
        {
            char opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("Por favor seleccione la operación que desea realizar: ");
                Console.WriteLine("1.Generar nueva lista");
                Console.WriteLine("2.Leer lista existente\n");
                opcion = Console.ReadKey().KeyChar;
            }
            while (opcion != '1' && opcion != '2');

            return (opcion == '1') ? control.GenerarClientes() : control.ObtenerLista();
        }

        public static void MostrarSegundoMenu(List<Cliente> lista)
        {
            char opcion;
            
            do
            {
                Console.Clear();
                Console.WriteLine("Por favor seleccione la operación que desea realizar: ");
                Console.WriteLine("1.Mostrar clientes entre 25 y 30 años");
                Console.WriteLine("2.Mostrar clientes en orden alfabetico\n");
                opcion = Console.ReadKey().KeyChar;
            }
            while (opcion != '1' && opcion != '2');

            if(opcion == '1')
            {
                var listaTemporal = lista.Where((c) => c.Edad >= 25 && c.Edad <= 30).ToList().OrderBy( c => c.Edad).ToList();

                if (listaTemporal.Count() > 0)
                {
                    listaTemporal.ForEach((c) => Console.WriteLine(c.ToString()));
                    Console.WriteLine($"- Total registros: {listaTemporal.Count()} de {lista.Count()}");
                }
                else
                    Console.WriteLine("Ningun elemento cumple con el criterio de busqueda.\n");
            }
            else
            {
                lista = lista.OrderBy((c) => c.Nombre).ToList();
                lista.ForEach((c) => Console.WriteLine(c.ToString()));
            }

            Console.ReadKey();
        }

        public static void MostrarTercerMenu()
        {
            char opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("Por favor seleccione la operación que desea realizar: ");
                Console.WriteLine("1.Volver al inicio");
                Console.WriteLine("2.Salir\n");
                opcion = Console.ReadKey().KeyChar;
            }
            while (opcion != '1' && opcion != '2');

            if (opcion == '1')
                Iniciar();
        }
    }
}
