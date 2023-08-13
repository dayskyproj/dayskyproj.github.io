using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectQT.Componentes.Tooltip
{
    public class TooltipBase : ComponentBase
    {
        [Parameter] 
        public RenderFragment ChildContent { get; set; }

        [Parameter] 
        public string Text { get; set; }

        [Parameter]
        public string ClassStyle { get; set; }
    }
}
