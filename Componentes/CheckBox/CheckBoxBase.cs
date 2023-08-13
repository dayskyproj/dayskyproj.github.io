using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectQT.Componentes.CheckBox
{
    public class CheckBoxBase : ComponentBase
    {
        [Parameter]
        public string ValorOpcionActiva { get; set; }

        [Parameter]
        public string ValorOpcionDesactivada { get; set; }

        [Parameter]
        public string ID { get; set; }

        [Parameter]
        public string Valor { get; set; }

        [Parameter]
        public bool CheckBoxReadonly { get; set; } = false;

        
        [Parameter]
        public EventCallback<string> ValorOpcionFinal { get; set; }

       

        public void RadioSelection(ChangeEventArgs valueFinal)
        {
            if (!CheckBoxReadonly) {
                ValorOpcionFinal.InvokeAsync(Convert.ToBoolean(valueFinal.Value) ? ValorOpcionActiva : ValorOpcionDesactivada);
            }
        }
    }
}
