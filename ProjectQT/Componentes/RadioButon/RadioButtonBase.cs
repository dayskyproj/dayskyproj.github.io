using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectQT.Componentes.RadioButon
{
    public class RadioButtonBase : ComponentBase
    {
        [Parameter]
        public string RadioValue { get; set; } = "";
        private string RadioActual { get; set; } = "";

        [Parameter]
        public List<string> Opciones { get; set; } = new();

        [Parameter]
        public string ID { get; set; } = "";

        [Parameter]
        public bool RadioReadonly { get; set; } = false;

        [Parameter]
        public EventCallback<string> RadioFinal { get; set; }

        protected override void OnAfterRender(bool renderizar)
        {
            if (RadioValue != RadioActual)
            {
                RadioFinal.InvokeAsync(RadioValue);
                //StateHasChanged();
                RadioActual = RadioValue;

            }
        }


    }
}
