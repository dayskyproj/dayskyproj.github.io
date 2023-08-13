using Microsoft.AspNetCore.Components;
using ProjectQT.Componentes.Tabs;

namespace ProjectQT.Componentes.HorariosNiveles
{
    public class HorarioNivelesBase : ComponentBase
    {
        [Parameter]
        public List<DateTime> Tiempos { get; set; } = new();

        [Parameter]
        public List<string> Titulos { get; set; } = new();
        [Parameter]
        public List<string> TitulosDefecto { get; set; } = new();

        public List<Tab> Tabs { get; set; } = new();

        [Parameter]
        public List<string> NotaDelNivel { get; set; } = new();


        [Parameter]
        public int Cantidad { get; set; }= 0;

       
        public int IndexTab { get; set; } = 0;

        public TabsSetBase TabsSet { get; set; }



        protected override void OnInitialized()
        {
            for (int i = 0; i < Cantidad; i++) {
                Tabs.Add(new Tab());
            }
        }


        public void ActualizarFinal()
        {


            if (Tabs[0].Titulo != null)
            {
                TabsSet.CambiarTab(Tabs[0]);
            }

        }

    }
}
