using System.Net;
using System.Net.Http.Json;

namespace Prueba_Ivan_Torres.Client.Services
{
    public class PeticionesHttpService
    {
        #region Gets
        /// <summary>
        /// Este metodo se encarga de pedir a la api la lista de pacientes
        /// </summary>
        /// <typeparam name="T">Modelo de pacientes para la lista</typeparam>
        /// <param name="uri">Uri de la api</param>
        /// <param name="httpClient">HttpClient para la consulta</param>
        /// <returns></returns>
        public static async Task<T> GetAll<T>(string uri, HttpClient httpClient)
        {
            return await httpClient.GetFromJsonAsync<T>(uri);
        }

        /// <summary>
        /// Este metodo se encarga de pedir a la api el paciente segun el id
        /// </summary>
        /// <typeparam name="T">Modelo de pacientes para la lista</typeparam>
        /// <param name="uri">Uri de la api</param>
        /// <param name="key">Nombre del parametroi</param>
        /// <param name="id">Valor del parametro</param>
        /// <param name="httpClient">HttpClient para la consulta</param>
        /// <returns></returns>
        public static async Task<T> Get<T>(string uri, string key, decimal id, HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add(key, $"{id}");
            var respuesta = await httpClient.GetFromJsonAsync<T>(uri);
            httpClient.DefaultRequestHeaders.Remove(key);
            return respuesta;
        }
        #endregion


        #region Post
        /// <summary>
        /// Este metodo realiza la peticion a la api para el registro del paciuente
        /// </summary>
        /// <typeparam name="T">Lista que responde para actualizar la tabla de pacientes</typeparam>
        /// <typeparam name="U">Modelo para registrar</typeparam>
        /// <param name="uri">Uri de la api</param>
        /// <param name="model">Modelo que se maneja</param>
        /// <param name="httpClient">HttpClient para la consulta</param>
        /// <returns></returns>
        public static async Task<T> Post<T, U>(string uri, U model, HttpClient httpClient)
        {
            var respuestaServer = await httpClient.PostAsJsonAsync(uri, model);
            return await respuestaServer.Content.ReadFromJsonAsync<T>();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Este metodo se encarga de peticion a la api para eliminar un paciente segun su id
        /// </summary>
        /// <typeparam name="T">Modelo de pacientes para la lista</typeparam>
        /// <param name="uri">Uri de la api</param>
        /// <param name="key">Nombre del parametroi</param>
        /// <param name="id">Valor del parametro</param>
        /// <param name="httpClient">HttpClient para la consulta</param>
        /// <returns></returns>
        public static async Task<T> Delete<T>(string uri, string key, decimal id, HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add(key, $"{id}");
            var respuestaServer = await httpClient.DeleteAsync(uri);
            var respuesta = await respuestaServer.Content.ReadFromJsonAsync<T>();
            httpClient.DefaultRequestHeaders.Remove(key);
            return respuesta;
        }
        #endregion


        #region Put
        /// <summary>
        /// Este metodo realiza la peticion a la api para la actualizacion del paciuente
        /// </summary>
        /// <typeparam name="T">Lista que responde para actualizar la tabla de pacientes</typeparam>
        /// <typeparam name="U">Modelo para registrar</typeparam>
        /// <param name="uri">Uri de la api</param>
        /// <param name="model">Modelo que se maneja</param>
        /// <param name="httpClient">HttpClient para la consulta</param>
        /// <returns></returns>
        public static async Task<T> Put<T, U>(string uri, U model, HttpClient httpClient)
        {
            var respuestaServer = await httpClient.PutAsJsonAsync(uri, model);
            return await respuestaServer.Content.ReadFromJsonAsync<T>();
        } 
        #endregion
    }
}
