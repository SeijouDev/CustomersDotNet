using Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Datos
{
    public class Data
    {
        private XmlSerializer serializador;
        private string NombreArchivo;

        public Data()
        {
            this.NombreArchivo = "Clientes.xml";
            this.serializador = new XmlSerializer(typeof(List<Cliente>));
        }

        public void GuardarListaClientes(List<Cliente> lista)
        {
            using (var writer = new StreamWriter(this.NombreArchivo))
            {
                this.serializador.Serialize(writer, lista);
            }
        }

        public List<Cliente> LeerClientes()
        {
            var lista = new List<Cliente>();
            try
            {
                using (var lector = new StreamReader(this.NombreArchivo))
                {
                    lista = this.serializador.Deserialize(lector) as List<Cliente>;
                }
            }
            catch (FileNotFoundException e)
            {
                //Console.WriteLine($"Error: {e.Message}");
            }

            return lista;
        }
    }
}
