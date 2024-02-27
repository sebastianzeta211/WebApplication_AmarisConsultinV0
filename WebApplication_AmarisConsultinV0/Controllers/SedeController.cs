using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_AmarisConsultinV0.Clases;
using WebApplication_AmarisConsultinV0.Models;

namespace WebApplication_AmarisConsultinV0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedeController : ControllerBase
    {
        /// <summary>
        /// obtener listado de sedes para mostrar en el formulario
        /// </summary>
        /// <returns></returns>
       private readonly ConexionSQLServer context;

        public SedeController(ConexionSQLServer context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Sede>> Sede()
        {
            try
            {

                return context.Sede.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
