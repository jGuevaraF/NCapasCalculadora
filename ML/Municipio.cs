using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Municipio
    {
        public int IdMunicipio { get; set; }
        public string Nombre { get; set; }
        public int IdEstado { get; set; }
    }


    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public ML.Direccion Direccion { get; set; }
    }

    public class Direccion
    {
        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public int NumeroInterior { get; set; }
    }
}
