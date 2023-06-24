using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TipoSangre
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JFloresHospitalEntities context = new DL.JFloresHospitalEntities())
                {
                    var filasAfectadas = context.TipoSangreGetall().ToList();

                    if(filasAfectadas != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var fila in filasAfectadas)
                        {
                            ML.TipoSangre tipoSangre = new ML.TipoSangre();
                            tipoSangre.IdTipoSangre = fila.IdTipoSangre;
                            tipoSangre.Nombre = fila.Nombre;
                            result.Objects.Add(tipoSangre);
                        }
                        result.Correct = true;
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
    }
}
