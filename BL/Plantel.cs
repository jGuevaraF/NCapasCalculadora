using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Plantel
    {
        public static ML.Result GetAllSPEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGuevaraDiciembreEntities context = new DL_EF.JGuevaraDiciembreEntities())
                {
                    var plantelGetAll = context.PlantelGetAll().ToList();

                    if (plantelGetAll.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var plantelObj in plantelGetAll)
                        {
                            ML.Plantel plantel = new ML.Plantel();
                            plantel.IdPlantel = plantelObj.IdPlantel;
                            plantel.Nombre = plantelObj.Nombre;

                            result.Objects.Add(plantel);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron Planteles.";
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
