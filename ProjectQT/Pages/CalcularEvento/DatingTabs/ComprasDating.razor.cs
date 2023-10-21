using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ProjectQT.Componentes.Sweetalert2;
using ProjectQT.Componentes.VentanaModal;
using ProjectQT.Data;
using ProjectQT.Data.DataDating;
using System;
using System.Reflection;

namespace ProjectQT.Pages.CalcularEvento.DatingTabs
{
    public class ComprasDatingBase : ComponentBase
    {
        public VentanaModal ModalPociones { get; set; } = new VentanaModal();
        public VentanaModal ModalCristales { get; set; } = new VentanaModal();

        public List<string> TitulosPociones { get; set; } = new();
        public List<string> TitulosCristales { get; set; } = new();

        #region parametros
        [Parameter]
        public InfoDating InfoEvento { get; set; } = new();

        [Parameter]
        public List<int> MaximoCristales { get; set; } = new();
        [Parameter]
        public List<int> MaximoPociones { get; set; } = new();

        [Parameter]
        public List<int> CompraPociones { get; set; } = new();


        [Parameter]
        public List<string> TituloVentanas { get; set; } = new();

        [Parameter]
        public EventCallback<List<int>> ActualizarActualesCristales { get; set; }
        [Parameter]
        public EventCallback<List<string>> ActualizarRespuestasCristales{ get; set; }
   
        [Parameter]
        public int CristalesRevival { get; set; } = 0;

        [Parameter]
        public int Capitulo { get; set; } = 0;

        [Parameter]
        public string Tipo { get; set; } = "";

        [Parameter]
        public int Exp { get; set; } = 0;

        [Parameter]
        public EventCallback ActualizarActualesPociones { get; set; }

        [Parameter]
        public EventCallback NoActualizarActualesPociones { get; set; }


        #endregion


        #region selects
        public List<OpcionesSelect> Seleccion { get; set; } = new()
        {
            new()
            {
                Valor = "SI", Descripcion = "SI"
            },
            new()
            {
                Valor = "NO", Descripcion = "NO"
            }
        };

        [Parameter]
        public List<string> OpcionCristales { get; set; } = new() {
            "", "", "", ""
        };

        public List<string> OpcionActual { get; set; } = new() {
            "", "", "", ""
        };

        public List<OpcionesSelect> SeleccionComando1 { get; set; } = new()
        {
            new()
            {
                Valor = "2", Descripcion = "2"
            },
            new()
            {
                Valor = "3", Descripcion = "3"
            }
        };

        public List<OpcionesSelect> SeleccionComando2 { get; set; } = new()
        {
            new()
            {
                Valor = "2", Descripcion = "2"
            },
            new()
            {
                Valor = "3", Descripcion = "3"
            },
             new()
            {
                Valor = "4", Descripcion = "4"
            }
        };
 

        public List<bool> ActivarOpcionesCristales { get; set; } = new()
        {
            true, true, true, true
        };

        #endregion

        public List<int> AccionSelectModificados = new() 
        {
            0, 0
        };


        [Inject]
        IJSRuntime JSRuntime { get; set; }

        public List<int> GemasGastadas { get; set; } = new()
        {
            0, 0, 0, 0
        };

        public List<int> GemasGastadasActual { get; set; } = new()
        {
            0, 0, 0, 0
        };

        protected override void  OnInitialized()  
        {
    
            TitulosPociones = InfoEvento.PaquetePociones.Select(x => $"Gemas: {x.CostoGemas}").ToList();

            TitulosCristales = new()
            {
                "Capitulo 1", "Capitulo 2", "Capitulo 3", "Capitulo 4"
            };

            CalculoGemasCristales();
        }


        #region procedimiento Cristales

            #region metodos a usar en componente hijo

            public async Task ActualizarSelectsCristales(int exp, int capitulo)
            {
                if (Tipo == "Nuevo")
                {

                    for (var i = 0; i < 4; i++)
                    {
                        if (i + 1 == capitulo)
                        {
                            var DataExp = InfoEvento.DataExp.Where(x => x.Capitulo == i + 1).ToList();
                            var size = DataExp.Count();


                            ActivarOpcionesCristales[i] = exp < InfoEvento.ExperienciaNecesaria[i]
                                                             * DataExp[size - 2].Porcentaje;

                            if (size >= 3)
                            {
                                //capitulo 3: index 0, capitulo 4: index 1
                                int indexAccionMod = i + 1 == 3 ? 0 : 1;

                                List<OpcionesSelect> select = new();

                                for (var j = 0; j < size - 1; j++)
                                {

                                    if (DataExp[j].Accion + 1 > AccionSelectModificados[indexAccionMod])
                                    {
                                        bool agregar = exp < InfoEvento.ExperienciaNecesaria[i]
                                                        * DataExp[j].Porcentaje;

                                        if (agregar)
                                        {
                                            select.Add(new()
                                            {
                                                Valor = $"{DataExp[j].Accion + 1}",
                                                Descripcion = $"{DataExp[j].Accion + 1}"
                                            });
                                        }
                                    }


                                }

                                var existeCampo = select.Where(x => x.Valor == OpcionCristales[i]).ToList();

                                if (existeCampo.Count() == 0)
                                {
                                    OpcionCristales[i] = "";
                                    OpcionActual[i] = "";

                                    GemasGastadas[i] = 0;
                                    GemasGastadasActual[i] = 0;
                                }

                                if (i + 1 == 3)
                                {
                                    SeleccionComando1 = select;
                                }
                                else
                                {
                                    SeleccionComando2 = select;
                                }


                            }
                            else
                            {
                                OpcionCristales[i] = ActivarOpcionesCristales[i] == false ? "" : OpcionCristales[i];
                                OpcionActual[i] = ActivarOpcionesCristales[i] == false ? "" : OpcionActual[i];

                                GemasGastadas[i] = ActivarOpcionesCristales[i] == false ? 0 : GemasGastadas[i];
                                GemasGastadasActual[i] = ActivarOpcionesCristales[i] == false ? 0 : GemasGastadasActual[i];
                            }

                        }
                        else
                        {
                            if (capitulo > i + 1)
                            {
                                ActivarOpcionesCristales[i] = false;
                                OpcionCristales[i] = "";
                                OpcionActual[i] = "";

                                GemasGastadas[i] = 0;
                                GemasGastadasActual[i] = 0;
                            }

                        }
                    }

                    CalculoGemasCristales();
                    await ActualizarRespuestasCristales.InvokeAsync(OpcionCristales);
                    await ActualizarActualesCristales.InvokeAsync(GemasGastadas);
                }


            }

            public void VaciarGemas()
            {
                GemasGastadas = new() {
                     0, 0, 0, 0
                };
                GemasGastadasActual = new() {
                     0, 0, 0, 0
                };
            }

            public void ValidarOpciones(List<string> opcionesPrevio)
            {
                VaciarGemas();

                OpcionCristales = new()
                {
                    "", "", "", ""
                };

                OpcionActual = new()
                {
                    "", "", "", ""
                };

                AccionSelectModificados = new() {
                    0,0
                };

                SeleccionComando1 = new()
                {
                    new()
                    {
                        Valor = "2", Descripcion = "2"
                    },
                    new()
                    {
                        Valor = "3", Descripcion = "3"
                    }
                };

                SeleccionComando2 = new()
                {
                    new()
                    {
                        Valor = "2", Descripcion = "2"
                    },
                    new()
                    {
                        Valor = "3", Descripcion = "3"
                    },
                    new()
                    {
                        Valor = "4", Descripcion = "4"
                    }
                };

                var contieneInfo = opcionesPrevio.Select((v, i) => new { Index = i, Value = v })
                                                 .Where(x => x.Value != "").ToList();

                if (contieneInfo.Count == 0)
                {
                    for (var i = 0; i < ActivarOpcionesCristales.Count; i++)
                    {
                        ActivarOpcionesCristales[i] = true;
                    }

                }
                else
                {

                    #region desactivar

                    var indexContieneInfo = 0;
                    var indexMaximo = contieneInfo.Max(x => x.Index);
                    for (var i = 0; i <= indexMaximo; i++)
                    {
                        if (i < 2)
                        {
                            ActivarOpcionesCristales[i] = false;
                        }

                        if (i == 2 && i == indexMaximo)
                        {
                            int index = SeleccionComando1.Count - 1;
                            ActivarOpcionesCristales[i] = !(contieneInfo[indexContieneInfo].Value == SeleccionComando1[index].Valor);

                            SeleccionComando1 = PatronFormarSelect(contieneInfo[indexContieneInfo].Value, 0, 3);

                        }
                        if (i == 3)
                        {
                            ActivarOpcionesCristales[i - 1] = false;
                            int index = SeleccionComando2.Count - 1;
                            ActivarOpcionesCristales[i] = !(contieneInfo[indexContieneInfo].Value == SeleccionComando2[index].Valor);

                            SeleccionComando2 = PatronFormarSelect(contieneInfo[indexContieneInfo].Value, 1, 4);
                        }

                        indexContieneInfo = i == contieneInfo[indexContieneInfo].Index ? indexContieneInfo + 1
                                           : indexContieneInfo;

                    }

                    #endregion

                    #region activar

                    var noContieneInfo = opcionesPrevio.Select((v, i) => new { Index = i, Value = v })
                                                .Where(x => x.Value == "" &&
                                                            x.Index > indexMaximo).ToList();

                    if (noContieneInfo.Count > 0)
                    {
                        int indexMinimo = noContieneInfo.Min(x => x.Index);

                        for (var i = indexMinimo; i < ActivarOpcionesCristales.Count; i++)
                        {
                            ActivarOpcionesCristales[i] = true;
                        }
                    }

                    #endregion

                }
            }

            #endregion

            #region selects

            public void AnalisisCristal1(string opcion)
            {
                OpcionCristales[0] = opcion;
                CalculoGemasCristales();
            }

            public void AnalisisCristal2(string opcion)
            {
                OpcionCristales[1] = opcion;
                CalculoGemasCristales();
            }

            public void AnalisisCristal3(string opcion)
            {
                OpcionCristales[2] = opcion;

                CalculoGemasCristales();

            }

            public void AnalisisCristal4(string opcion)
            {
                OpcionCristales[3] = opcion;

                CalculoGemasCristales();

            }

            #endregion

            #region patrones 

            public List<OpcionesSelect> PatronFormarSelect(string opcion, int index, int capitulo)
            {
                int accion = Convert.ToInt32(opcion);

                var select = (from x in InfoEvento.DataExp
                              where x.Accion > accion &&
                              x.Capitulo == capitulo
                              select new OpcionesSelect
                              {
                                  Descripcion = $"{x.Accion}",
                                  Valor = $"{x.Accion}"
                              }).ToList();

                AccionSelectModificados[index] = accion;

                return select;
            }

            public List<int> PatronCalculoGemasCristales(int indexPaquete, int diferencia, int i, int sobrantes)
            {


                for (var j = indexPaquete; j < InfoEvento.PaqueteCristales.Count; j++)
                {

                    var cantidadComprar = diferencia / (InfoEvento.PaqueteCristales[j].CantidadMaterial);

                    if (MaximoCristales[j] - sobrantes - cantidadComprar >= 0)
                    {
                        sobrantes = cantidadComprar;

                        GemasGastadas[i] += InfoEvento.PaqueteCristales[j].CostoGemas * sobrantes;

                        if (MaximoCristales[j] == sobrantes)
                        {
                            sobrantes = 0;
                            indexPaquete++;
                        }

                        break;
                    }
                    else
                    {
                        indexPaquete++;
                        GemasGastadas[i] += InfoEvento.PaqueteCristales[j].CostoGemas * (MaximoCristales[j] - sobrantes);
                        diferencia -= InfoEvento.PaqueteCristales[j].CantidadMaterial * (MaximoCristales[j] - sobrantes);
                        sobrantes = 0;
                    }
                }

                return new() { sobrantes, indexPaquete };
            }

        #endregion

            public void CalculoGemasCristales()
            {
                int indexPaquete = 0;
                int cristales = CristalesRevival;
                int sobrantes = 0;

                GemasGastadas = new()
                {
                    0, 0, 0, 0
                };

                for (var i = 0; i < OpcionCristales.Count; i++)
                {
                    if (OpcionCristales[i] == "SI")
                    {
                        var cristalesNecesarios = InfoEvento.DataCristales.Where(x => x.Capitulo == i + 1)
                                                            .Select(x => x.Cristales).Sum();

                        var diferencia = cristalesNecesarios - cristales;


                        var analisis = PatronCalculoGemasCristales(indexPaquete, diferencia, i, sobrantes);
                        sobrantes = analisis[0];
                        indexPaquete = analisis[1];

                        cristales = 0;
                    }
                    else
                    {
                        if (OpcionCristales[i] != "" && OpcionCristales[i] != "NO")
                        {
                            var accion = Convert.ToInt32(OpcionCristales[i]);

                            List<int> acciones = new();

                            if (i + 1 == 3)
                            {
                                acciones = SeleccionComando1.Where(x => x.Valor != "")
                                           .Select(x => Convert.ToInt32(x.Valor)).ToList();
                            }
                            else
                            {
                                acciones = SeleccionComando2.Where(x => x.Valor != "")
                                          .Select(x => Convert.ToInt32(x.Valor)).ToList();
                            }

                            var cristalesNecesarios = InfoEvento.DataCristales.Where(x => x.Capitulo == i + 1 &&
                                                                            x.Accion <= accion &&
                                                                             acciones.Contains(x.Accion))
                                                                            .Select(x => x.Cristales).Sum();

                            var diferencia = cristalesNecesarios - cristales;


                            var analisis = PatronCalculoGemasCristales(indexPaquete, diferencia, i, sobrantes);
                            sobrantes = analisis[0];
                            indexPaquete = analisis[1];

                            cristales = 0;

                        }
                        else
                        {
                            GemasGastadas[i] = 0;
                        }

                    }

                }


            }

            public async Task CerrarCristales()
            {
                OpcionCristales = OpcionActual.Select(x => x).ToList();
                GemasGastadas = GemasGastadasActual.Select(x => x).ToList();

                await ActualizarRespuestasCristales.InvokeAsync(OpcionCristales);

                ModalCristales.Close();
            }

            public async Task ActualizarCristales()
            {
                OpcionActual = OpcionCristales.Select(x => x).ToList();
                GemasGastadasActual = GemasGastadas.Select(x => x).ToList();
                await ActualizarRespuestasCristales.InvokeAsync(OpcionCristales);
                await ActualizarActualesCristales.InvokeAsync(GemasGastadas);
                ModalCristales.Close();

            }

        #endregion

        #region procedimiento Pociones

        public async Task ActualizarMentas()
        {

            for (var i = 0; i < CompraPociones.Count; i++)
            {
                CompraPociones[i] = MaximoPociones[i] >= CompraPociones[i] ? CompraPociones[i] : 0;
            }

            await ActualizarActualesPociones.InvokeAsync();
            ModalPociones.Close();

        }

        public async Task CerrarPociones()
        {
            await NoActualizarActualesPociones.InvokeAsync();
            ModalPociones.Close();
        }


        #endregion
    }
}
