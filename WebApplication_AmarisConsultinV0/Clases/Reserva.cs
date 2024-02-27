using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace WebApplication_AmarisConsultinV0.Clases
{
    


    public class Reserva
    {
        public int Id { get; set; }

        public string email { get; set; }

        public string nombre { get; set; }

        public string identificacion { get; set; }

        public string campus { get; set; }

        public DateTime fecha { get; set; }
        public int estado { get; set; }
        //0 nuevo
        //1 esta en la sede
        //2 se desactivo
        /// <summary>
        /// metodo para obtener los datos desde lo publico
        /// </summary>
        /// <param name="reserva"></param>
        /// <returns></returns>
        public bool validacionCita(string identificacion)
        {
            return calculoCita(identificacion);
        }

        /// <summary>
        /// metodo privado quien realiza la validacion
        /// </summary>
        /// <param name="reserva"></param>
        /// <returns></returns>
        private bool calculoCita(string identificacion)
        {
            SqlCommand var_comando = new SqlCommand();
            SqlDataAdapter var_adaptador = new SqlDataAdapter();
            int var_resultado = 0;

            try
            {
                // abrirconexion();
           
                var_comando.CommandText = @"select .[dbo].ValidarReserva";
                var_comando.Parameters.AddWithValue("@identificacion", identificacion);
                var_comando.Parameters.AddWithValue("@fecha", DateTime.Now);
               // var_comando.Connection = var_conexion;
                var_adaptador.SelectCommand = var_comando;

                //--- acá es donde creo que me falta algo

               // cerrarconexion();
            }
            catch (SqlException ex)
            {

                string err = ex.Message;
                err = "";
            }

            return true;
         
        }
    }
}
