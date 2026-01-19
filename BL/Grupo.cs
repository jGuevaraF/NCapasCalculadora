using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Grupo
    {
        public static ML.Result GetByIdPlantel(int IdPlantel)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGuevaraDiciembreEntities context = new DL_EF.JGuevaraDiciembreEntities())
                {
                    var GrupoGetByIdPlantel = context.GrupoGetByIdPlantel(IdPlantel).ToList();

                    if (GrupoGetByIdPlantel.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var grupoObj in GrupoGetByIdPlantel)
                        {
                            ML.Grupo grupo = new ML.Grupo();
                            grupo.IdGrupo = grupoObj.IdGrupo;
                            grupo.Nombre = grupoObj.Nombre;

                            result.Objects.Add(grupo);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct =false;
                        result.ErrorMessage = "No se econtraron Grupos";
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
