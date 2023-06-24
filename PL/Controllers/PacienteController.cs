using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult GetAll()
        {
            ML.Result result = new ML.Result();
            ML.Paciente paciente = new ML.Paciente();
            paciente.TipoSangre = new ML.TipoSangre();
            result = BL.TipoSangre.GetAll();
            if (result.Correct)
            {
                paciente.TipoSangre.TiposDeSangre = new List<object>();
                paciente.TipoSangre.TiposDeSangre = result.Objects;
            }

            result = BL.Paciente.GetAll();
            if (result.Correct)
            {
                paciente.Pacientes = new List<object>();
                paciente.Pacientes = result.Objects;
            }
            return View(paciente);
        }


    }
}