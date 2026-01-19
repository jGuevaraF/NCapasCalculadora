using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {    
        public int IdMateria { get; set; }
        public string Nombre { get; set; }
        public decimal Promedio { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public decimal Costo { get; set; }
        public string UserName { get; set; }

        // Propiedad de navegación
        public ML.Semestre Semestre { get; set; }
        public ML.Grupo Grupo { get; set; }
        public byte[] Imagen {  get; set; }
        public List<object> Materias { get; set; }
    }

    //1 Nombre Promedio FechaRegistro
}
