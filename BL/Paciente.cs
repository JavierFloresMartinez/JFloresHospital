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
                using (DL.JFloresHospitalEntities1 contex = new DL.JFloresHospitalEntities1())
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
                            paciente.ApellidoMaterno = fila.ApellidoMaterno;
                            paciente.FechaDeNacimiento = fila.FechaDeNacimiento.ToString();
                            paciente.FechaDeIngreso = fila.FechaDeIngreso.ToString();
                            paciente.Sexo = fila.Sexo;
                            paciente.Sintomas = fila.Sintomas;
                            paciente.TipoSangre = new ML.TipoSangre();
                            paciente.TipoSangre.IdTipoSangre = fila.IdTipoSangre;
                            paciente.TipoSangre.Nombre = fila.TipoDeSangre;
                            paciente.Foto = fila.Foto;
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

        public static ML.Result GetById(int idPaciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JFloresHospitalEntities1 contex = new DL.JFloresHospitalEntities1())
                {
                    var rowsAffected = contex.PacienteGetById(idPaciente).FirstOrDefault();

                    if (rowsAffected != null)
                    {
                        result.Object = new object();

                        ML.Paciente paciente = new ML.Paciente();
                        paciente.IdPaciente = rowsAffected.IdPaciente;
                        paciente.Nombre = rowsAffected.Nombre;
                        paciente.ApellidoPaterno = rowsAffected.ApellidoPaterno;
                        paciente.ApellidoMaterno = rowsAffected.ApellidoMaterno;
                        paciente.FechaDeNacimiento = rowsAffected.FechaDeNacimiento.ToString();
                        paciente.FechaDeIngreso = rowsAffected.FechaDeIngreso.ToString();
                        paciente.Sexo = rowsAffected.Sexo;
                        paciente.Sintomas = rowsAffected.Sintomas;
                        paciente.Foto = rowsAffected.Foto;
                        paciente.TipoSangre = new ML.TipoSangre();
                        paciente.TipoSangre.IdTipoSangre = rowsAffected.IdTipoSangre;
                        paciente.TipoSangre.Nombre = rowsAffected.TipoDeSangre;
                        result.Object = paciente;
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
            }
            return result;
        }

        public static ML.Result Add(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JFloresHospitalEntities1 context = new DL.JFloresHospitalEntities1())
                {
                    var rowsAffected = context.PacienteAdd(paciente.Nombre, paciente.ApellidoPaterno, paciente.ApellidoMaterno, paciente.FechaDeNacimiento,paciente.TipoSangre.IdTipoSangre, paciente.Sexo,paciente.Sintomas, paciente.Foto);

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio Un error al agregar el paciente";
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

        public static ML.Result Update(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JFloresHospitalEntities1 contex = new DL.JFloresHospitalEntities1())
                {
                    var rowsAffected = contex.PacienteUpdate(paciente.IdPaciente, paciente.Nombre, paciente.ApellidoPaterno, paciente.ApellidoMaterno, paciente.FechaDeNacimiento, paciente.TipoSangre.IdTipoSangre, paciente.Sexo, paciente.Sintomas, paciente.Foto);
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio Un error al Actualizar el paciente";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


        public static ML.Result Delete(int idPaciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JFloresHospitalEntities1 context = new DL.JFloresHospitalEntities1())
                {
                    var rowsAffected = context.PacienteDelete(idPaciente);
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio Un error al eliminar el paciente";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct= false;
                result.ErrorMessage= ex.Message;

            }
            return result;
        }
    }
}
