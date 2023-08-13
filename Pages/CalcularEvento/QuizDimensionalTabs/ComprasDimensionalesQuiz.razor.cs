using Microsoft.AspNetCore.Components;
using ProjectQT.Componentes.VentanaModal;
using ProjectQT.Data.DataQuizDimensional;

namespace ProjectQT.Pages.CalcularEvento.QuizDimensionalTabs
{
    public class ComprasDimensionalesQuizBase : ComponentBase
    {

        public VentanaModal ModalMentas { get; set; } = new VentanaModal();
        public VentanaModal ModalJRegalos { get; set; } = new VentanaModal();

        public List<string> TitulosMentas { get; set; } = new();
        public List<string> TitulosRegalos { get; set; } = new();

        public InfoQuizDimensional InfoEvento { get; set; } = new();



        [Parameter]
        public List<int> MaximoRegalos { get; set; } = new();
        [Parameter]
        public List<int> MaximoMentas { get; set; } = new();

        [Parameter]
        public List<int> CompraMentas { get; set; } = new();
        [Parameter]
        public List<int> CompraRegalos { get; set; } = new();


        [Parameter]
        public List<string> TituloVentanas { get; set; } = new();


        [Parameter]
        public EventCallback ActualizarActuales { get; set; }

        [Parameter]
        public EventCallback NoActualizarActuales { get; set; }


        protected override void OnInitialized()
        {

            TitulosMentas = InfoEvento.PaqueteMentas.Select(x => $"Gemas: {x.CostoGemas}").ToList();
            TitulosRegalos = InfoEvento.PaqueteRegalos.Select(x => $"Gemas: {x.CostoGemas}").ToList();

        }

        public async Task ActualizarMentas() {
            await ActualizarActuales.InvokeAsync();
            ModalMentas.Close();

        }

        public async Task ActualizarRegalos()
        {
            await ActualizarActuales.InvokeAsync();
            ModalJRegalos.Close();

        }

        public async Task CerrarRegalos() 
        {
            await NoActualizarActuales.InvokeAsync();
            ModalJRegalos.Close();
        }

        public async Task CerrarMentas()
        {
            await NoActualizarActuales.InvokeAsync();
            ModalMentas.Close();
        }


    }
}
