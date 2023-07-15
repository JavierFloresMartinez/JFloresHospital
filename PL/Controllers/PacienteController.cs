using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente http://localhost:54040/
        [HttpGet]
        public ActionResult GetAll()
        {
            //ML.Result result = new ML.Result();
            ML.Paciente paciente = new ML.Paciente();
            paciente.Pacientes = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54040/api/");
                var responseTask = client.GetAsync("Paciente/GetAll");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Paciente pacienteList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Paciente>(resultItem.ToString());
                        paciente.Pacientes.Add(pacienteList);
                    }
                }
            }
            return View(paciente);
        }

        [HttpGet]
        public ActionResult Form(int? idPaciente)
        {
           // ML.Result result = new ML.Result();
            ML.Paciente paciente = new ML.Paciente();
            ML.TipoSangre tipoSangre = new ML.TipoSangre();
            tipoSangre.TiposDeSangre = new List<object>();
            paciente.TipoSangre = new ML.TipoSangre();
            paciente.TipoSangre.TiposDeSangre = new List<object>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54040/api/");
                var responseTask = client.GetAsync("TipoSangre/GetAll");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.TipoSangre tipoSangreList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.TipoSangre>(resultItem.ToString());
                        tipoSangre.TiposDeSangre.Add(tipoSangreList);
                    }
                }
            }
            if (idPaciente == null)
            {
                paciente.TipoSangre.TiposDeSangre = tipoSangre.TiposDeSangre;
                return View(paciente);
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54040/api/");
                    var responseTask = client.GetAsync("Paciente/GetById/"+ idPaciente);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                            paciente = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Paciente>(readTask.Result.Object.ToString());
                      
                    }
                }
                paciente.TipoSangre.TiposDeSangre = tipoSangre.TiposDeSangre;
                return View(paciente);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Paciente paciente)
        {
            //ML.Result result = new ML.Result();
            if (paciente.IdPaciente == 0)
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54040/api/");
                    var responseTask = client.PostAsJsonAsync<ML.Paciente>("Paciente/Add",paciente);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se agrego correctamente el paciente";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al intentar ingresar el paciente";
                    }
                }
               
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54040/api/");
                    var responseTask = client.PutAsJsonAsync<ML.Paciente>("Paciente/Update", paciente);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se actualizo correctamente el paciente";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al intentar actualizar el paciente";
                    }
                }
            }
            return View("Modal");
        }



        public ActionResult Delete(int idPaciente)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54040/api/");

                var postTask = client.DeleteAsync("Paciente/Delete/" + idPaciente);
                postTask.Wait();

                var resultDelete = postTask.Result;
                if (resultDelete.IsSuccessStatusCode)
                {
                    ViewBag.Message = "El paciente se elimino correctamente";

                }
                else
                {
                    ViewBag.Message = "Hubo un error al eliminar el paciente";
                }
            }
            return View("Modal");
        }


    }
}