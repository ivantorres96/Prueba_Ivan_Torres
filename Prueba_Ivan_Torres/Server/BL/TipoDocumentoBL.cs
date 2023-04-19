using Prueba_Ivan_Torres.Server.DB;
using Prueba_Ivan_Torres.Shared.Models;

namespace Prueba_Ivan_Torres.Server.BL
{
    public class TipoDocumentoBL
    {
        /// <summary>
        /// El metodo se encarga de tener el sql y consultar a la capa de datos para traer los tipo de documentos
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<TipoDocumentoModel>> ListaTipoDocumentos()
        {
            var sql = @"SELECT * FROM TipoDocumentos;";
            return await DB_Context.GetAllSql<TipoDocumentoModel>(sql);
        }
    }
}
