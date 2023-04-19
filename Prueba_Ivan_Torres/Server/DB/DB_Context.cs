using Dapper;
using System.Data.SqlClient;

namespace Prueba_Ivan_Torres.Server.DB
{
    public class DB_Context
    {

        private static string? ConexionString { get; set; }
        public DB_Context(string conexionString) => ConexionString = conexionString;

        public static SqlConnection DbContextSQL()
        {
            return new SqlConnection(ConexionString);
        }

        #region Gets
        /// <summary>
        /// Consultar una lista con la informacion solicitada por medio de solo el query y sin parametros
        /// </summary>
        /// <typeparam name="T">Modelo en que se resiviran la informacion despues de realizar la consulta</typeparam>
        /// <param name="sql">Query para la consulta</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> GetAllSql<T>(string sql)
        {
            try
            {
                return await DbContextSQL().QueryAsync<T>(sql);
            }
            catch (Exception)
            {
                return Enumerable.Empty<T>();
            }
        }

        /// <summary>
        /// Consultar una lista con la informacion solicitada por medio de solo el query y con parametros
        /// </summary>
        /// <typeparam name="T">Modelo en que se resiviran la informacion despues de realizar la consulta</typeparam>
        /// <typeparam name="U">El modelo o parametros para realizar la consulta</typeparam>
        /// <param name="sql">Query para la consulta</param>
        /// <param name="model">El modelo o parametros para la consulta</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> GetAll<T, U>(string sql, U model)
        {
            try
            {
                return await DbContextSQL().QueryAsync<T>(sql, model);
            }
            catch (Exception)
            {
                return Enumerable.Empty<T>();
            }
        }

        /// <summary>
        /// Consulta una informacion en especifico por medio del query y parametros
        /// </summary>
        /// <typeparam name="T">Modelo en que se resiviran la informacion despues de realizar la consulta</typeparam>
        /// <typeparam name="U">El modelo o parametros para realizar la consulta</typeparam>
        /// <param name="sql">Query para la consulta</param>
        /// <param name="model">El modelo o parametros para la consulta</param>
        /// <returns></returns>
        public static async Task<T> Get<T, U>(string sql, U model)
        {
            return await DbContextSQL().QueryFirstAsync<T>(sql, model);
        }
        #endregion

        #region Insert, Update, Delete
        /// <summary>
        /// Realizar Insert, Update o Delete solicitada por medio de un query y con parametros
        /// </summary>
        /// <typeparam name="T">El modelo o parametros para realizar la consulta<</typeparam>
        /// <param name="sql">Query para la consulta</param>
        /// <param name="model">El modelo o parametros para la consulta</param>
        /// <returns></returns>
        public static async Task<bool> InUpDe<T>(string sql, T model)
        {
            try
            {
                return await DbContextSQL().ExecuteAsync(sql, model) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
