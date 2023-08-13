using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectQT.Componentes.Tabs
{
    public class TabsSetBase : ComponentBase
    {
        #region variable tamaño select 
        [Parameter]
        public int SizeSM { get; set; } = 12;

        [Parameter]
        public int SizeXL { get; set; } = 12;

        [Parameter]
        public int SizeLG { get; set; } = 12;

        [Parameter]
        public int SizeMD { get; set; } = 12;

        public string SizeContenedor = "";
        #endregion

        [Parameter]
        public RenderFragment Tabs { get; set; }

        [Parameter]
        public RenderFragment LabelTabs { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public ITab ActivaTab { get; private set; }

        protected override void OnInitialized()
        {
            SizeContenedor = $"col-sm-{SizeSM} col-md-{SizeMD} col-lg-{SizeLG} col-xl-{SizeXL}";
        }

        public void AgregarTab(ITab tab)
        {
            if (ActivaTab == null)
            {
                CambiarTab(tab);
            }
        }

        public void CambiarTab(ITab tab)
        {
            if (ActivaTab != tab)
            {
                ActivaTab = tab;
                StateHasChanged();
            }
        }

    }
}
