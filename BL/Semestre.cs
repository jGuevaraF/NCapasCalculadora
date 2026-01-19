using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Semestre
    {
        public static ML.Result GetAllSPEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGuevaraDiciembreEntities context = new DL_EF.JGuevaraDiciembreEntities())
                {
                    var semestreGetAll = context.SemestreGetAll().ToList();

                    if (semestreGetAll.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var semestreObj in semestreGetAll)
                        {
                            ML.Semestre semestre = new ML.Semestre();
                            semestre.IdSemestre = semestreObj.IdSemestre;
                            semestre.Nombre = semestreObj.Nombre;

                            result.Objects.Add(semestre);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron Semestres.";
                    }

                }

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
    }
}
