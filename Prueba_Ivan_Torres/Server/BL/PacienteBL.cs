using Prueba_Ivan_Torres.Server.DB;
using Prueba_Ivan_Torres.Shared.Models;

namespace Prueba_Ivan_Torres.Server.BL
{
    public class PacienteBL
    {
        #region Consulta
        /// <summary>
        /// El metodo se encarga de tener el sql y consultar a la capa de datos para traer los pacientes
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<PacienteListModel>> ListaPacientes()
        {
            var sql = @"SELECT P.IdPaciente, P.Nombre, P.Apellidos, P.CorreoElectronico, P.Telefono, P.FechaNacimiento, P.EstadoAfiliacion, D.Nombre AS 'TipoDocumento', P.NumeroDocumento FROM Pacientes P
                            INNER JOIN TipoDocumentos D ON D.IdTipoDocumento = P.IdTipoDocumento;";
            return await DB_Context.GetAllSql<PacienteListModel>(sql);
        }

        /// <summary>
        /// El metodo se encarga de enviar un paciente por medio del id con el cual se realiza el filtrado
        /// </summary>
        /// <param name="id">Id del paciente</param>
        /// <returns></returns>
        public static async Task<PacienteModel> Paciente(decimal id)
        {
            var sql = @"SELECT * FROM Pacientes WHERE IdPaciente = @IdPaciente;";
            return await DB_Context.Get<PacienteModel, object>(sql, new { IdPaciente = id });
        }
        #endregion

        #region Registrar
        /// <summary>
        /// El metodo se encarga de enviar el query y el modelo con la informacion para registrar el paciente
        /// </summary>
        /// <param name="model">Modelo para registrar paciente</param>
        /// <returns></returns>
        public static async Task<bool> RegistrarPaciente(PacienteModel model)
        {
            var sql = @"INSERT INTO Pacientes (Nombre, Apellidos, CorreoElectronico, Telefono, FechaNacimiento, EstadoAfiliacion, IdTipoDocumento, NumeroDocumento)
                            VALUES (@Nombre, @Apellidos, @CorreoElectronico, @Telefono, @FechaNacimiento, @EstadoAfiliacion, @IdTipoDocumento, @NumeroDocumento);";
            return await DB_Context.InUpDe(sql, model);
        }
        #endregion

        #region Actualizar
        /// <summary>
        /// El metodo se encarga de enviar el query y el modelo con la informacion para actualizar el paciente
        /// </summary>
        /// <param name="model">Modelo para actualizar paciente</param>
        /// <returns></returns>
        public static async Task<bool> ActualizarPaciente(PacienteModel model)
        {
            var sql = @"UPDATE Pacientes SET 
                        Nombre = @Nombre, 
                        Apellidos = @Apellidos,
                        CorreoElectronico = @CorreoElectronico, 
                        Telefono = @Telefono, 
                        FechaNacimiento = @FechaNacimiento, 
                        EstadoAfiliacion = @EstadoAfiliacion, 
                        IdTipoDocumento = @IdTipoDocumento,
                        NumeroDocumento = @NumeroDocumento
                        WHERE IdPaciente = @IdPaciente;";
            return await DB_Context.InUpDe(sql, model);
        }
        #endregion

        #region Eliminar
        /// <summary>
        /// El metodo se encarga de enviar el query y el idPaciente para eliminar el paciente
        /// </summary>
        /// <param name="id">Id del paciente</param>
        /// <returns></returns>
        public static async Task<bool> EliminarPaciente(decimal id)
        {
            var sql = @"DELETE Pacientes WHERE IdPaciente = @IdPaciente;";
            return await DB_Context.InUpDe(sql, new { IdPaciente = id });
        }
        #endregion
    }
}
