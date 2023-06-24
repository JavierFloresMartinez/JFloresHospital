using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paciente
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JFloresHospitalEntities contex = new DL.JFloresHospitalEntities())
                {
                    var filasAfectadas = contex.PacienteGetAll().ToList();
                    if(filasAfectadas != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var fila in filasAfectadas)
                        {
                            ML.Paciente paciente = new ML.Paciente();
                            paciente.IdPaciente = fila.IdPaciente;
                            paciente.Nombre = fila.Nombre;
                            paciente.ApellidoPaterno = fila.ApellidoPaterno;
                            paciente.ApellidoPaterno = fila.ApellidoMaterno;
                            paciente.FechaDeNacimiento = fila.FechaDeNacimiento.ToString();
                            paciente.FechaDeIngreso = fila.FechaDeIngreso.ToString();
                            paciente.Sexo = fila.Sexo;
                            paciente.Sintomas = fila.Sintomas;
                            paciente.TipoSangre = new ML.TipoSangre();
                            paciente.TipoSangre.IdTipoSangre = fila.IdTipoSangre;
                            paciente.TipoSangre.Nombre = fila.TipoDeSangre;
                            result.Objects.Add(paciente);

                        }
                        result.Correct = true;
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
