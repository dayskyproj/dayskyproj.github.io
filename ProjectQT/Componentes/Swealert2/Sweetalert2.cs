using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectQT.Componentes.Sweetalert2
{
    public static class Sweetalert2
    {

        public static async Task MostrarMensaje(this IJSRuntime js, string titulo, string mensaje, TipoSweetalert2 tipo)
        {
            await js.InvokeAsync<object>("Swal.fire", titulo, mensaje, tipo.ToString());
        }

        public static async Task<bool> Confirmar(this IJSRuntime js, string titulo, string mensaje, TipoSweetalert2 tipo)
        {
            return await js.InvokeAsync<bool>("CustomConfirm", titulo, mensaje, tipo.ToString());
        }

        public static async Task InvocarLoanding(this IJSRuntime js, string titulo)
        {
            await js.InvokeAsync<object>("AbrirLoading", titulo);
        } 

        public static async Task InvocarLoanding(this IJSRuntime js, string titulo, int tiempo)
        {
            await js.InvokeAsync<object>("AbrirLoading", titulo, tiempo);
        }

        public static async Task CerrarSweetalert2(this IJSRuntime js)
        {
            await js.InvokeAsync<object>("Cerrar");
        }

        public static async Task PersonalizarConHtml(this IJSRuntime js, string titulo, string infoHtml)
        {
            await js.InvokeAsync<object>("PersonalizarHTML", titulo, infoHtml);
        }

        public static async Task PersonalizarConHtml(this IJSRuntime js, string titulo, string infoHtml, TipoSweetalert2 tipo)
        {
            await js.InvokeAsync<object>("PersonalizarHTMLMensaje", titulo, infoHtml, tipo.ToString());
        }

        public enum TipoSweetalert2
        {
            warning, error, success, info, question
        }
    }
}
