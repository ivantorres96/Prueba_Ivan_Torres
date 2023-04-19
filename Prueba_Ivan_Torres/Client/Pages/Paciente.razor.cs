using Microsoft.AspNetCore.Components;
using Prueba_Ivan_Torres.Client.Services;
using Prueba_Ivan_Torres.Shared.Models;
using System.Runtime.CompilerServices;

namespace Prueba_Ivan_Torres.Client.Pages
{
    public partial class Paciente
    {
        #region Variables
        [Inject] private HttpClient httpClient { get; set; }
        private List<string> EstadoAfiliaciones = new() { "activo", "inactivo" };
        private List<TipoDocumentoModel> ListaTipoDocumento = new();
        private List<PacienteListModel> ListaPacientes = new();
        private PacienteModel PacienteModel = new();
        private bool flagVistaPaciente = true;
        private string nombreBoton = "";
        private bool flagCrearACtualizar = true; 
        #endregion

        //Ejuctar metodos cuando se carga la vista
        protected async override Task OnInitializedAsync()
        {
            ListaPacientes = await PeticionesHttpService.GetAll<List<PacienteListModel>>("api/Paciente/Lista", httpClient);
        }

        #region Registrar
        /// <summary>
        /// Abrir el formulario para registrar el paciente
        /// </summary>
        /// <param name="InUP"></param>
        /// <returns></returns>
        private async Task VistaResgitrarPaciente(bool InUP)
        {
            flagCrearACtualizar = InUP;
            nombreBoton = "Resgitrar";
            PacienteModel = new();
            ListaTipoDocumento = await PeticionesHttpService.GetAll<List<TipoDocumentoModel>>("api/TipoDocumento/Lista", httpClient);
            flagVistaPaciente = false;
        }

        /// <summary>
        /// El metodo se encarga de Actualozar o registrar segun el proceso
        /// </summary>
        /// <returns></returns>
        private async Task EnviarRegistro()
        {
            if (flagCrearACtualizar)
            {
                ListaPacientes = await PeticionesHttpService.Post<List<PacienteListModel>, PacienteModel>("api/Paciente/Crear", PacienteModel, httpClient);
            }
            else
            {
                ListaPacientes = await PeticionesHttpService.Put<List<PacienteListModel>, PacienteModel>("api/Paciente/actualizar", PacienteModel, httpClient);
            }
            flagVistaPaciente = true;
        }
        #endregion

        #region Eliminar
        /// <summary>
        /// El metodo se encarga de eliminar la informacion selecionada
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private async Task EliminarRegistro(PacienteListModel model)
        {
            ListaPacientes = await PeticionesHttpService.Delete<List<PacienteListModel>>("api/Paciente/Eliminar", "idPaciente", model.IdPaciente, httpClient);
            flagVistaPaciente = true;
        }
        #endregion

        #region Actualizar
        /// <summary>
        /// Metodo se encarga de abrir el formulacion con el paciente selecionado
        /// </summary>
        /// <param name="model"></param>
        /// <param name="up"></param>
        /// <returns></returns>
        private async Task ActualizarRegistro(PacienteListModel model, bool up)
        {
            flagCrearACtualizar = up;
            nombreBoton = "Actulizar";
            ListaTipoDocumento = await PeticionesHttpService.GetAll<List<TipoDocumentoModel>>("api/TipoDocumento/Lista", httpClient);
            PacienteModel = await PeticionesHttpService.Get<PacienteModel>("api/Paciente/Solo", "idPaciente", model.IdPaciente, httpClient);
            flagVistaPaciente = false;
        }
        #endregion

        #region Atras
        /// <summary>
        /// Metodo es para volver atras donde se muestras los pacientes registrados
        /// </summary>
        public void Atras()
        {
            flagVistaPaciente = true;
        }
        #endregion
    }
}
