using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_AmarisConsultinV0.Clases;
using WebApplication_AmarisConsultinV0.Models;

namespace WebApplication_AmarisConsultinV0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidarController : Controller
    {
        private readonly ConexionSQLServer context;

        public ValidarController(ConexionSQLServer context)
        {
            this.context = context;
        }
        /// <summary>
        /// este metodo se implementa para validar si una cita puede ser tomada con normalidad o no, suponinedo en el caso de que
        /// una persona puede somanete solicitar una cita para un sola sola sede , activa la cita validando si se encuentra en los 15 minutos de anticipacion
        /// </summary>

        /// <param name="collection"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Reserva reserva)
        {
            try
            {
                var _reserva =  context.IReserva.FirstOrDefault(x => x.identificacion == reserva.identificacion);

                if (_reserva != null)
                {
                    Reserva a = new Reserva();

                    if (a.validacionCita(reserva.identificacion))
                    {
                        //codigo para validar por base de datos que si se puede hacer la cita
                        return Ok(new { message = "La reserva se ha confirmado con exito" });
                    }
                    else
                    {
                        return Ok(new { message = "la fecha de la cita ha superado el limite de espera" });
                    }
                    a = null;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
