using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_AmarisConsultinV0.Clases;
using WebApplication_AmarisConsultinV0.Models;

namespace WebApplication_AmarisConsultinV0.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
        public class ReservaController : ControllerBase
        {

            private readonly ConexionSQLServer context;
           
            public ReservaController(ConexionSQLServer context)
            {
                this.context = context;
            }
            /// <summary>
            /// obtener listado de reservas
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            public ActionResult<IEnumerable<Reserva>> Get()
            {
                try
                {
           
                    return context.IReserva.ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        /// <summary>
        /// crear una reserva
        /// </summary>
        /// <param name="reserva"> objeto que contiene los datos de la reserva</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Reserva reserva)

        {
            try
            {
                context.Add(reserva);
                await context.SaveChangesAsync();
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// editar una reserva, no se implementa ya que no esta especificado en los requerimientos
        /// </summary>
        /// <param name="id">id de elemento a editar</param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPut("(id)")]
        public async Task<ActionResult> Put(int id, [FromBody] Reserva reserva)
        {
            try
            {
                if (id != reserva.Id)
                    return NotFound();

                context.Update(reserva);
                await context.SaveChangesAsync();
                return Ok(new { message = "La reserva se ha modificado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// eliminar una reserva, no se implementa ya que no esta especificado en los requerimientos
        /// </summary>
        /// <param name="id">id de elemento a editar</param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {


                var _reserva = await context.IReserva.FindAsync(id);

                if (_reserva != null)
                {
                    context.Remove(_reserva);
                    await context.SaveChangesAsync();
                    return Ok(new { message = "La reserva se ha eliminado con exito" });
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
