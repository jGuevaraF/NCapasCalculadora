using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<ML.Materia> materias = BL.Materia.GetAll();

            if (materias.Count > 0)
            {
                foreach (ML.Materia materia in materias)
                {
                    Console.WriteLine("ID " + materia.IdMateria);
                    Console.WriteLine("Nombre " + materia.Nombre);
                    Console.WriteLine("Promedio " + materia.Promedio);
                }
            }

        }
    }
}
