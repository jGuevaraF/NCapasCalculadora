using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        //ActionResult => retorna una respuesta visible al usuario

        //Controlador => maneja TODAS las peticiones
        public ActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAll();
            List<object> materias = result.Objects; 

            return View(materias);
        }
    }
}