using ML;
using System;
using System.Collections.Concurrent;
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
            //add

            //ML.Materia materia = new ML.Materia();

            //Console.WriteLine("Dame el nombre");
            //materia.Nombre = Console.ReadLine();

            //Console.WriteLine("Dame el promedio");
            //materia.Promedio = Convert.ToDecimal(Console.ReadLine());

            //Console.WriteLine("Dame la fecha de registro");
            //materia.FechaRegistro = Convert.ToDateTime(Console.ReadLine());

            //Console.WriteLine("Dame el costo");
            //materia.Costo = Convert.ToDecimal(Console.ReadLine());

            //ML.Result result = BL.Materia.Add(materia);


            //if (result.Correct)
            //{
            //    Console.WriteLine("Se inserto bien");
            //}
            //else
            //{
            //    Console.WriteLine("Hubo un error " + result.ErrorMessage);
            //}

            //Console.WriteLine("Dame el id que quieres eliminar");
            //int idMateria = Convert.ToInt32(Console.ReadLine());

            //ML.Result result = BL.Materia.Delete(idMateria);

            //if (result.Correct)
            //{
            //    Console.WriteLine("Se elimino correctamente");
            //}
            //else
            //{
            //    Console.WriteLine("Error " + result.ErrorMessage);
            //}
            //ML.Result result = BL.Materia.GetAll();


            //if (result.Correct)
            //{
            //    foreach (ML.Materia materia in result.Objects)
            //    {
            //        Console.WriteLine("EL id de la materia es " + materia.IdMateria);
            //        Console.WriteLine("EL Nombre de la materia es " + materia.Nombre);
            //        Console.WriteLine("EL Promedio de la materia es " + materia.Promedio);
            //        Console.WriteLine("EL Costo de la materia es " + materia.Costo);
            //        Console.WriteLine("=============================================");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("ERROR " + result.ErrorMessage);
            //}


            Console.WriteLine("Dame el id que quieres buscar");
            int idMateria = Convert.ToInt32(Console.ReadLine());
            //ML.Result result = BL.Materia.GetById(idMateria);

            //if (result.Correct)
            //{
            //    //si encontro un registro
            //    //mostrarlo
            //    ML.Materia materia = (ML.Materia)result.Object; //unboxing

            //    Console.WriteLine("EL id de la materia es " + materia.IdMateria);
            //    Console.WriteLine("EL Nombre de la materia es " + materia.Nombre);
            //    Console.WriteLine("EL Promedio de la materia es " + materia.Promedio);
            //    Console.WriteLine("EL Costo de la materia es " + materia.Costo);
            //    Console.WriteLine("=============================================");
            //}
            //else
            //{
            //    Console.WriteLine("ERROR " + result.ErrorMessage);
            //}

        }
    }
}
