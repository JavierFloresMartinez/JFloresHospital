using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace SL.Controllers
{
    public class PacienteController : ApiController
    {
        // GET: Paciente
        [HttpGet]
        [Route("api/Paciente/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = new ML.Result();
            result = BL.Paciente.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [HttpGet]
        [Route("api/Paciente/GetById/{idPaciente}")]
        public IHttpActionResult GetById(int idPaciente)
        {
            ML.Result result = new ML.Result();
            result = BL.Paciente.GetById(idPaciente);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [HttpPost]
        [Route("api/Paciente/Add")]
        public IHttpActionResult Add([FromBody] ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            result = BL.Paciente.Add(paciente);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [HttpPut]
        [Route("api/Paciente/Update")]
        public IHttpActionResult Update([FromBody] ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            result = BL.Paciente.Update(paciente);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [HttpDelete]
        [Route("api/Paciente/Delete/{idPaciente}")]
        public IHttpActionResult Delete(int idPaciente)
        {
            ML.Result result = new ML.Result();
            result = BL.Paciente.Delete (idPaciente);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }


    }
}