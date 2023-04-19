using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Ivan_Torres.Server.BL;
using Prueba_Ivan_Torres.Shared.Models;

namespace Prueba_Ivan_Torres.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        #region Gets
        /// <summary>
        /// Controlador se encarga de enviar la lista de los pacientes
        /// </summary>
        /// <returns></returns>
        [HttpGet("Lista")]
        public async Task<ActionResult<IEnumerable<PacienteListModel>>> ListaPacientes()
        {
            try
            {
                var respuesta = await PacienteBL.ListaPacientes();
                return Ok(respuesta);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

 
        /// <summary>
        /// Controlador se encarga de enviar el paciente que fue filtrado por el id
        /// </summary>
        /// <param name="idPaciente">Id del paciente</param>
        /// <returns></returns>
        [HttpGet("Solo")]
        public async Task<ActionResult<IEnumerable<PacienteListModel>>> Paciente([FromHeader] decimal idPaciente)
        {
            try
            {
                var respuesta = await PacienteBL.Paciente(idPaciente);
                return Ok(respuesta);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion

        #region Post
        /// <summary>
        /// Controlador se encarga de crear un paciente por medio del modelo paciente que se recibe.
        /// </summary>
        /// <param name="model">Modelo paciente</param>
        /// <returns></returns>
        [HttpPost("crear")]
        public async Task<ActionResult<int>> RegistrarPaciente([FromBody] PacienteModel model)
        {
            try
            {
                var validarInsert = await PacienteBL.RegistrarPaciente(model);
                if (validarInsert)
                {
                    var respuesta = await PacienteBL.ListaPacientes();
                    return Ok(respuesta);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion

        #region Puts
        /// <summary>
        /// Controlador se encarga de actualizar un paciente por medio del modelo paciente que se recibe.
        /// </summary>
        /// <param name="model">Modelo paciente</param>
        /// <returns></returns>
        [HttpPut("actualizar")]
        public async Task<ActionResult<int>> ActualizarPaciente([FromBody] PacienteModel model)
        {
            try
            {
                var validarInsert = await PacienteBL.ActualizarPaciente(model);
                if (validarInsert)
                {
                    var respuesta = await PacienteBL.ListaPacientes();
                    return Ok(respuesta);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Controlador se encarga de eliminar el paciente por medio del id
        /// </summary>
        /// <param name="idPaciente">Id del paciente</param>
        /// <returns></returns>
        [HttpDelete("eliminar")]
        public async Task<ActionResult<int>> EliminarPaciente([FromHeader] decimal idPaciente)
        {
            try
            {
                var validarInsert = await PacienteBL.EliminarPaciente(idPaciente);
                if (validarInsert)
                {
                    var respuesta = await PacienteBL.ListaPacientes();
                    return Ok(respuesta);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion
    }
}
