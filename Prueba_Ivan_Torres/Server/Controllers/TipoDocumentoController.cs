using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Ivan_Torres.Server.BL;
using Prueba_Ivan_Torres.Shared.Models;

namespace Prueba_Ivan_Torres.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        /// <summary>
        /// Controlador esta encargado de enviar la lista de tipo de documentos
        /// </summary>
        /// <returns></returns>
        [HttpGet("Lista")]
        public async Task<ActionResult<IEnumerable<TipoDocumentoModel>>> TipoDocumentos()
        {
            try
            {
                var respuesta = await TipoDocumentoBL.ListaTipoDocumentos();
                return Ok(respuesta);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
