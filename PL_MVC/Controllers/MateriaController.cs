using BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            materia.Semestre = new ML.Semestre();

            ML.Result resultSemestres = BL.Semestre.GetAllSPEF();
            if (resultSemestres.Correct)
            {
                materia.Semestre.Semestres = resultSemestres.Objects;
            }

            ML.Result result = BL.Materia.GetAllSPEF(materia);
            // Lista de materia, esta en result.Objects

            materia.Materias = result.Objects;
            //List<object> materia = result.Objects;

            return View(materia);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Materia materia)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Formulario(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            materia.Semestre = new ML.Semestre();
            materia.Grupo = new ML.Grupo();
            materia.Grupo.Plantel = new ML.Plantel();

            ML.Result resultSemestres = BL.Semestre.GetAllSPEF();
            if (resultSemestres.Correct)
            {
                materia.Semestre.Semestres = resultSemestres.Objects;
            }

            ML.Result resultPlanteles = BL.Plantel.GetAllSPEF();
            if (resultPlanteles.Correct)
            {
                materia.Grupo.Plantel.Planteles = resultPlanteles.Objects;
            }

            if (IdMateria > 0)
            {
                ML.Result result = BL.Materia.GetByIdSPEF(IdMateria.Value);
                //Controlador
                materia = (ML.Materia)result.Object; // BL
                materia.Semestre.Semestres = resultSemestres.Objects;
                materia.Grupo.Plantel.Planteles = resultPlanteles.Objects;

                ML.Result resultGrupos = BL.Grupo.GetByIdPlantel(materia.Grupo.Plantel.IdPlantel);
                if (resultGrupos.Correct)
                {
                    materia.Grupo.Grupos = resultGrupos.Objects;
                }

            }

            return View(materia);
        }

        [HttpPost]
        public ActionResult Formulario(ML.Materia materia, HttpPostedFileBase inptImagen)
        {
            // Guardar en la DB
            if (inptImagen != null && inptImagen.ContentLength > 0)
            {
                using (Stream inputStream = inptImagen.InputStream)
                {

                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    materia.Imagen = memoryStream.ToArray();
                }

            }



            if (materia.IdMateria > 0)
            {
                // Update
                BL.Materia.UpdateSPEF(materia);
            }
            else
            {
                // Add
                BL.Materia.AddSPEF(materia);
            }

            // Redirigir a GetAll
            return RedirectToAction("GetAll");
        }
        public ActionResult Delete(int IdMateria)
        {
            BL.Materia.Delete(IdMateria);

            // Redirigir a GetAll
            //return View("GetAll");
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public JsonResult GrupoGetByIdPlantel(int IdPlantel)
        {
            ML.Result result = BL.Grupo.GetByIdPlantel(IdPlantel);
            return Json(result,JsonRequestBehavior.AllowGet);
        }

    }
}