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

            Console.WriteLine("Ingresa el ID");      
            int IdMateria = Convert.ToInt32(Console.ReadLine());

            ML.Materia materia = BL.Materia.GetById(IdMateria);

            if (materia != null)
            {
                // Pintar los datos
                Console.WriteLine(materia.IdMateria);
                Console.WriteLine(materia.Nombre);
                Console.WriteLine(materia.Promedio);
                Console.WriteLine(materia.FechaRegistro);
            }


            // Boxing 
            List<object> numero = new List<object>();
            numero.Add(1);
            numero.Add(2);
            numero.Add(3);

            object obj = "fgf";

            // Unboxing
            int primerNumero = (int)numero[0];

            int numero2 = Convert.ToInt32(obj);
            string numero3 = (string)obj;


            List<ML.Materia> materias = BL.Materia.GetAll();
            if (materias.Count > 0)
            {
                foreach (ML.Materia materiaDB in materias)
                {
                    Console.WriteLine("ID " + materiaDB.IdMateria);
                    Console.WriteLine("Nombre " + materiaDB.Nombre);
                    Console.WriteLine("Promedio " + materiaDB.Promedio);
                }
            }

        }
    }
}
