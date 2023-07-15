using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace SL.Controllers
{
    public class TipoSangreController : ApiController
    {
        //http://localhost:54040/
        // GET: TipoSangre
        [HttpGet]
        [Route("api/TipoSangre/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = new ML.Result();
            result = BL.TipoSangre.GetAll();
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