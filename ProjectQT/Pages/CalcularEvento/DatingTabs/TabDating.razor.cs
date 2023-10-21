using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectQT.Componentes.Sweetalert2;
using ProjectQT.Data;
using ProjectQT.ReadJson;
using ProjectQT.Data.DataDating;
using ProjectQT.Componentes.Horarios.Dating;
using ProjectQT.Componentes.VentanaModal;

namespace ProjectQT.Pages.CalcularEvento.DatingTabs
{
    public class TabDatingBase : ComponentBase
    {
        #region version

        public List<OpcionesSelect> OpcionesVersiones { get; set; } = new() {
            new()
            {
                Valor = "V1", Descripcion = "Versión 1"
            },
            new()
            {
                Valor = "V2", Descripcion = "Versión 2"
            }
        };
        public string OpcionVersion { get; set; } = "V2";

        #endregion

        #region Tiempo

        public DateTime FechaInicial { get; set; } = new DateTime(2023, 9, 27, 4, 0, 0);
        public DateTime FinalizarEvento { get; set; }
        public DateTime FechaActual { get; set; } = new DateTime(2023, 9, 27, 4, 0, 0);
        public TimeSpan TiempoFinales { get; set; } = TimeSpan.Zero;

        #endregion

        #region Lista Previo y actual pociones y cristales

            #region cristales
 
            public List<string> OpcionCristalesPrevio { get; set; } = new() 
            {
                "", "", "", ""
            };

            public int GemasGastadasCristalesPrevio { get; set; } = 0;
            public List<int> MaximoCristalesPrevio = new();

            public List<string> OpcionCristalesNuevo { get; set; } = new() 
            {
                "", "", "", ""
            };

            public int GemasGastadasCristalesNuevo { get; set; } = 0;
            public List<int> MaximoCristalesNuevo = new();

            #endregion

            #region Pociones

            public List<int> MaximoPocionesPrevio = new();
            public List<int> MaximoPocionesNuevo = new();

            public List<int> CompraPocionesPrevio { get; set; } = new() {
                0,0,0
            };

            public List<int> CompraPocionesPrevioOriginal { get; set; } = new() {
                0,0,0
            };


            public List<int> CompraPocionesNuevo { get; set; } = new() {
                0,0,0
            };

            public List<int> CompraPocionesNuevoOriginal { get; set; } = new() {
                0,0,0
            };

            #endregion

        #endregion

        #region modal

        public List<string> TitulosModalPrevio { get; set; } = new() {
            "Registrar Cristales Previos", "Registrar Pociones Previos"
        };

        public List<string> TitulosModalActual { get; set; } = new() {
            "Comprar Cristales", "Comprar Pociones"
        };

        public List<string> TitulosModales { get; set; } = new();

        public ComprasDatingBase ModalComprasNuevo { get; set; } = new();
        public ComprasDatingBase ModalComprasPrevio { get; set; } = new();

        public VentanaModal ModalRecomendacion { get; set; } = new();

        #endregion

        #region otros

        public InfoDating InfoEvento { get; set; }
        [Inject]
        public IJsonApi JsonApi { get; set; }
        [Inject]
        IJSRuntime JSRuntime { get; set; }
        public int Capitulo { get; set; } = 1;
        public int CapituloCristalPrevio { get; set; } = 1;

        public int PocionesActual { get; set; } = 0;
        public int PocionesFinal { get; set; } = 0;
        public int PocionesPaquete { get; set; } = 0;  
        #endregion


        #region selects

        public List<OpcionesSelect> OpcionesCapitulos { get; set; } = new() {
            new()
            {
                Valor = "1", Descripcion = "1"
            },
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
        public string OpcionCapitulo { get; set; } = "";

        public List<OpcionesSelect> OpcionesPregunta { get; set; } = new();
        public string OpcionPregunta { get; set; } = "";
        public bool ActivarSelectPregunta { get; set; } = false;

        public List<OpcionesSelect> OpcionesRevival { get; set; } = new();
        public string OpcionRevival { get; set; } = "";
        public int CristalRevivalActual { get; set; } = 0;
        public int CristalRevivalPrevio { get; set; } = 0;

        public List<OpcionesSelect> OpcionesPaqueteNutakuPrevio { get; set; } = new() {

            new()
            {
                Descripcion = "1", Valor = "1"
            },
             new()
            {
                Descripcion = "2", Valor = "2"
            },
             new()
            {
                Descripcion = "3", Valor = "3"
            },

        };
        public string OpcionPaqueteNutakuPrevio { get; set; } = "";

        public List<OpcionesSelect> OpcionesPaqueteNutakuActual { get; set; } = new() {

            new()
            {
                Descripcion = "1", Valor = "1"
            },
             new()
            {
                Descripcion = "2", Valor = "2"
            },
             new()
            {
                Descripcion = "3", Valor = "3"
            },

        };

        public string OpcionPaqueteNutakuActual { get; set; } = "";

        #endregion


        #region input Exp
        public int ExpActual { get; set; } = 0;
        public string MaximoExp { get; set; } = "8000";
        public bool ReadonlyExp { get; set; } = true;
        public string MensajeExp { get; set; } = "Exp mínima 0 y máximo 8000";
        public string PatronMensajeExp { get; set; } = "Exp mínima 0 y máximo {max}";
        #endregion

        #region ganancias y gastos

        public int GastosGemasPrevio { get; set; } = 0;
        public int GemasObtenidasPaqueteP2WPrevio { get; set; } = 0;

        public int GastosGemasNuevo { get; set; } = 0;
        public int GemasObtenidasPaqueteP2WNuevo { get; set; } = 0;


        public int TotalGemasGastadas { get; set; } = 0;
        public int TotalGemasObtenidas { get; set; } = 0;

        #endregion

        #region tarjeta
        public List<GuiaCapituloDating> GuiaCapitulo { get; set; } = new();
        public List<string> TitulosCapitulo { get; set; } = new();

        public List<string> TitulosCapituloDefecto { get; set; } = new() {

            "Capitulo 1", "Capitulo 2", "Capitulo 3", "Capitulo 4"

        };
        public List<string> Collapsable { get; set; } = new() { "", "", "" };
        public List<string> CollapsableIcono { get; set; } = new()
        { "fas fa-caret-left", "fas fa-caret-left", "fas fa-caret-left" };

        public HorarioCapituloDatingBase Horario { get; set; } = new();

        #endregion


        protected override async Task OnInitializedAsync()
        {
            InfoEvento = await JsonApi.JsonDating("V2");
            FinalizarEvento = FechaInicial.AddDays(InfoEvento.DuracionEvento);
            TitulosModales = InfoEvento.PaquetePociones.Select(x => $"Gemas: {x.CostoGemas}").ToList();

            MaximoPocionesPrevio = InfoEvento.PaquetePociones.Select(x => x.Maximo).ToList();
            MaximoPocionesNuevo = InfoEvento.PaquetePociones.Select(x => x.Maximo).ToList();

            MaximoCristalesPrevio = InfoEvento.PaqueteCristales.Select(x => x.Maximo).ToList();
            MaximoCristalesNuevo = InfoEvento.PaqueteCristales.Select(x => x.Maximo).ToList();

            for(var i = 50; i <= 400; i += 50) 
            {
                OpcionesRevival.Add(new() { 
                    Descripcion = i.ToString(),
                    Valor = i.ToString()
                });
            }
            PocionesFinal = 48;
            await Calcular();

        }

        public void ActualizarFechaFinal(ChangeEventArgs e)
        {
            DateTime Fecha = Convert.ToDateTime(e.Value);

            FinalizarEvento = Fecha.AddDays(InfoEvento.DuracionEvento);

            FechaActual = Fecha;
        }


        public async Task ActualizarExp(ChangeEventArgs e)
        {
            try
            {
                int valor = Convert.ToInt32(e.Value);
                await ModalComprasNuevo.ActualizarSelectsCristales(valor, Capitulo);
            }
            catch 
            {
                Console.WriteLine("ingreso una letra");
            }

        }


        public void ActualizarPociones(ChangeEventArgs e)
        {
            try
            {
                int valor = Convert.ToInt32(e.Value);

                CalculoPociones(valor);
            }

            catch (Exception ex)
            {
                Console.WriteLine("ingreso una letra");
            }

            StateHasChanged();
        }

        public void CalculoPociones(int pociones)
        {
            for (int i = 0; i < 3; i++)
            {

                if (i == 0)
                {
                    PocionesFinal = pociones + CompraPocionesNuevo[i] * InfoEvento.PaquetePociones[i].CantidadMaterial;
                }
                else
                {
                    PocionesFinal += CompraPocionesNuevo[i] * InfoEvento.PaquetePociones[i].CantidadMaterial;

                }
            }

            if (OpcionPaqueteNutakuActual != "")
            {

                int opcion = Convert.ToInt32(OpcionPaqueteNutakuActual);


                if (OpcionPaqueteNutakuPrevio == "")
                {
                    PocionesFinal += InfoEvento.PaqueteNutakuGold
                        .Where(x => x.NivelProduccion - 1 <= opcion)
                        .Sum(x => x.CantidadMaterial);
                }
                else
                {

                    int opcionPrevio = Convert.ToInt32(OpcionPaqueteNutakuPrevio);

                    int mentasPrevias = InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcionPrevio)
                                    .Sum(x => x.CantidadMaterial);


                    PocionesFinal += InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcion)
                                    .Sum(x => x.CantidadMaterial) - mentasPrevias;
                }

            }
        }

        public void ActualizarCollapsable(int index)
        {
            int indexActual = Collapsable.IndexOf("show");

            if (indexActual != -1)
            {
                if (indexActual == index)
                {
                    Collapsable[index] = "";
                    CollapsableIcono[index] = "fas fa-caret-left";
                }
                else
                {
                    Collapsable[index] = "show";
                    CollapsableIcono[index] = "fas fa-caret-down";
                    Collapsable[indexActual] = "";
                    CollapsableIcono[indexActual] = "fas fa-caret-left";
                }


            }
            else
            {
                Collapsable[index] = "show";
                CollapsableIcono[index] = "fas fa-caret-down";
            }


        }

        #region metodos selects

        public void ActualizarCristalesRevival(string valorS) 
        {
            CristalRevivalActual = valorS == "" ? 0 : Convert.ToInt32(valorS);
            CristalRevivalPrevio = valorS == "" ? 0 : Convert.ToInt32(valorS);
            OpcionCristalesNuevo = new()
            {
                "", "", "", ""
            };

            OpcionCristalesPrevio = new()
            {
                "", "", "", ""
            };

            GemasGastadasCristalesPrevio = 0;
            GemasGastadasCristalesNuevo = 0;

            MaximoCristalesPrevio = InfoEvento.PaqueteCristales.Select(x => x.Maximo).ToList();
            MaximoCristalesNuevo = InfoEvento.PaqueteCristales.Select(x => x.Maximo).ToList();

            ModalComprasNuevo.VaciarGemas();
            ModalComprasPrevio.VaciarGemas();

        }

        public async Task ActualizarVersion(string valorS)
        {
            OpcionVersion = valorS;

            if (OpcionVersion == "V1")
            {

                InfoEvento = await JsonApi.JsonDating("V1");

            }
            else
            {
                InfoEvento = await JsonApi.JsonDating("V2");


            }
            FinalizarEvento = FechaActual.AddDays(InfoEvento.DuracionEvento);
            await Calcular();

        }


        public async Task ActualizarNumeroPreguntas(string ValorS)
        {
            OpcionCapitulo = ValorS;
            Capitulo = ValorS == "" ? CapituloCristalPrevio : Convert.ToInt32(ValorS);
            OpcionPregunta = "";
            ReadonlyExp = true;
            ExpActual = 0;

            PocionesFinal = ValorS == "" && CapituloCristalPrevio == 1 ? 48 : 0;

            if (ValorS == "")
            {
                OpcionesPregunta = new();
                ActivarSelectPregunta = false;
                MaximoExp = InfoEvento.ExperienciaNecesaria[CapituloCristalPrevio - 1].ToString();
            }
            else
            {

                OpcionesPregunta = (from x in InfoEvento.DataPregunta
                                    where x.Capitulo == Capitulo
                                    select new OpcionesSelect
                                    {
                                        Descripcion = x.Pregunta.ToString(),
                                        Valor = x.Pregunta.ToString()

                                    }).ToList();

                ActivarSelectPregunta = true;


                MaximoExp = InfoEvento.ExperienciaNecesaria[Capitulo - 1].ToString();


            }

            MensajeExp = PatronMensajeExp.Replace("{max}", MaximoExp);

            await ModalComprasNuevo.ActualizarSelectsCristales(ExpActual, Capitulo);

            CalculoPociones(PocionesFinal);
            StateHasChanged();
        }

        public void ActivarEXP(string ValorS)
        {
            OpcionPregunta = ValorS;

            if (ValorS == "")
            {
                ReadonlyExp = true;
            }
            else 
            {
                int size = OpcionesPregunta.Count();
                ReadonlyExp = !(ValorS == OpcionesPregunta[size - 1].Valor);
            }

        }

        public void ActualizarsSelectPaqueteP2W(string ValorS)
        {

            OpcionPaqueteNutakuPrevio = ValorS;
            OpcionPaqueteNutakuActual = "";
            GemasObtenidasPaqueteP2WPrevio = 0;
            GemasObtenidasPaqueteP2WNuevo = 0;
            TotalGemasObtenidas = 0;
            PocionesFinal -= PocionesPaquete;
            PocionesPaquete = 0;

            if (ValorS == "")
            {
                OpcionesPaqueteNutakuActual = OpcionesPaqueteNutakuPrevio;

            }
            else
            {
                OpcionesPaqueteNutakuActual = (from x in OpcionesPaqueteNutakuPrevio
                                               where Convert.ToInt32(x.Valor) > Convert.ToInt32(ValorS)
                                               select x
                                               ).ToList();

                int index = Convert.ToInt32(ValorS);

                for (var i = 0; i < index; i++)
                {
                    GemasObtenidasPaqueteP2WPrevio += InfoEvento.PaqueteNutakuGold[i].Gemas;
                }
            }

            TotalGemasObtenidas = GemasObtenidasPaqueteP2WPrevio;


        }

        public void ActualizarGemasSelectActual(string valorS)
        {
            OpcionPaqueteNutakuActual = valorS;
            GemasObtenidasPaqueteP2WNuevo = 0;
            TotalGemasObtenidas = 0;

            if (valorS != "")
            {

                int index = Convert.ToInt32(valorS);
                int indexPrevio = OpcionPaqueteNutakuPrevio == "" ? 0 : Convert.ToInt32(OpcionPaqueteNutakuPrevio);

                for (var i = indexPrevio; i < index; i++)
                {
                    GemasObtenidasPaqueteP2WNuevo += InfoEvento.PaqueteNutakuGold[i].Gemas;
                }

                int opcion = Convert.ToInt32(valorS);

                if (OpcionPaqueteNutakuPrevio == "")
                {


                    PocionesFinal += InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcion)
                                    .Sum(x => x.CantidadMaterial) - PocionesPaquete;


                    PocionesPaquete = InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcion)
                                    .Sum(x => x.CantidadMaterial);

                }
                else
                {
                    int opcionPrevio = Convert.ToInt32(OpcionPaqueteNutakuPrevio);

                    int mentasPrevias = InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcionPrevio)
                                    .Sum(x => x.CantidadMaterial);


                    PocionesFinal += InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcion)
                                    .Sum(x => x.CantidadMaterial) - mentasPrevias - PocionesPaquete;

                    PocionesPaquete = InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcion)
                                    .Sum(x => x.CantidadMaterial) - mentasPrevias;

                }

            }

            else
            {
                PocionesFinal -= PocionesPaquete;
                PocionesPaquete = 0;
            }

            TotalGemasObtenidas = GemasObtenidasPaqueteP2WNuevo + GemasObtenidasPaqueteP2WPrevio;

        }

        #endregion


        #region modal previo cristal
        public async Task ActualizarCritalesPrevio(List<int> gemasGastadas) 
        {
            GemasGastadasCristalesPrevio = gemasGastadas.Sum();

            GemasGastadasCristalesNuevo = 0;

            var gemasRestantes = gemasGastadas.Sum();

            OpcionCristalesNuevo = new() {
                "", "", "", ""
            };

            for (var i = 0; i < MaximoCristalesNuevo.Count; i++) 
            {
                MaximoCristalesNuevo[i] = InfoEvento.PaqueteCristales[i].Maximo *
                                           InfoEvento.PaqueteCristales[i].CostoGemas <= gemasRestantes
                                           ? 0 
                                           : InfoEvento.PaqueteCristales[i].Maximo - 
                                           (gemasRestantes / InfoEvento.PaqueteCristales[i].CostoGemas);

                var diferencia = gemasRestantes -
                                InfoEvento.PaqueteCristales[i].Maximo *
                                InfoEvento.PaqueteCristales[i].CostoGemas;

                gemasRestantes = diferencia < 0 ? 0 : diferencia;
            }

            ModalComprasNuevo.ValidarOpciones(OpcionCristalesPrevio);

            if (OpcionCristalesPrevio.Where(x => x != "").Count() == 0)
            {
                CapituloCristalPrevio = 1;
            }
            else 
            {
                CapituloCristalPrevio = OpcionCristalesPrevio.Select((v, i) => new { Index = i, Value = v })
                                               .Where(x => x.Value != "").ToList().Max(x => x.Index) + 1;

               
            }

            List<OpcionesSelect> select = new();

            for (var i = CapituloCristalPrevio; i <= 4; i++) 
            {
                select.Add(new() { 
                    Descripcion = i.ToString(),
                    Valor = i.ToString()
                });
            }

            OpcionesCapitulos = select;

            OpcionCapitulo = "";
            Capitulo =  CapituloCristalPrevio;

            OpcionPregunta = "";
            ReadonlyExp = true;
            ExpActual = 0;

            PocionesFinal = CapituloCristalPrevio == 1 ? 48 : 0;
            MaximoExp = InfoEvento.ExperienciaNecesaria[CapituloCristalPrevio - 1].ToString();
            MensajeExp = PatronMensajeExp.Replace("{max}", MaximoExp);

            OpcionesPregunta = new();
            ActivarSelectPregunta = false;

            CalculoPociones(PocionesFinal);
            await ActualizarInfoPrevio();

        }
        #endregion


        #region modal nuevo cristal
        public async Task ActualizarCritalesNuevo(List<int> gemasGastadas)
        {
            GemasGastadasCristalesNuevo = gemasGastadas.Sum();
            await ActualizarPocionesNuevo();

        }
        #endregion

        #region modal previo Pociones

        public async Task ActualizarInfoPrevio()
        {
            await Task.Delay(1000);

            CompraPocionesNuevo = new() {
                0,0,0
            };

            CompraPocionesNuevoOriginal = new() {
                0,0,0
            };

            MaximoPocionesNuevo = InfoEvento.PaquetePociones.Select(x => x.Maximo).ToList();

            GastosGemasPrevio = GemasGastadasCristalesPrevio;
            GastosGemasNuevo = GemasGastadasCristalesNuevo;
            TotalGemasGastadas = GastosGemasPrevio + GastosGemasNuevo;

            for (int i = 0; i < 3; i++)
            {

                MaximoPocionesNuevo[i] = MaximoPocionesNuevo[i] - CompraPocionesPrevio[i];
                GastosGemasPrevio += InfoEvento.PaquetePociones[i].CostoGemas * CompraPocionesPrevio[i];

            }

            CompraPocionesPrevioOriginal = CompraPocionesPrevio.GetRange(0, CompraPocionesPrevio.Count);

            TotalGemasGastadas = GastosGemasPrevio;

            CalculoPociones(OpcionCapitulo == "" && CapituloCristalPrevio == 1 ? 48 : PocionesActual);

        }

        public async Task NoActualizarInfoPrevio()
        {
            await Task.Delay(1000);

            CompraPocionesPrevio = CompraPocionesPrevioOriginal.GetRange(0, CompraPocionesPrevioOriginal.Count);

        }

        #endregion

        #region modal nuevo Pociones

        public async Task ActualizarPocionesNuevo()
        {
            await Task.Delay(1000);

            TotalGemasGastadas = 0;
            GastosGemasNuevo = GemasGastadasCristalesNuevo;


            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    if (OpcionCapitulo == "" && CapituloCristalPrevio == 1)
                    {
                        PocionesFinal = 48 + CompraPocionesNuevo[i] * InfoEvento.PaquetePociones[i].CantidadMaterial;

                    }
                    else
                    {
                        PocionesFinal = PocionesActual + CompraPocionesNuevo[i] * InfoEvento.PaquetePociones[i].CantidadMaterial;

                    }

                }

                else
                {
                    PocionesFinal += CompraPocionesNuevo[i] * InfoEvento.PaquetePociones[i].CantidadMaterial;

                }

                GastosGemasNuevo += InfoEvento.PaquetePociones[i].CostoGemas * CompraPocionesNuevo[i];
            }

            CompraPocionesNuevoOriginal = CompraPocionesNuevo.GetRange(0, CompraPocionesNuevo.Count);

            TotalGemasGastadas = GastosGemasNuevo + GastosGemasPrevio;

            if (OpcionPaqueteNutakuActual != "")
            {

                int opcion = Convert.ToInt32(OpcionPaqueteNutakuActual);


                if (OpcionPaqueteNutakuPrevio == "")
                {
                    PocionesFinal += InfoEvento.PaqueteNutakuGold
                        .Where(x => x.NivelProduccion - 1 <= opcion)
                        .Sum(x => x.CantidadMaterial);
                }
                else
                {

                    int opcionPrevio = Convert.ToInt32(OpcionPaqueteNutakuPrevio);

                    int mentasPrevias = InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcionPrevio)
                                    .Sum(x => x.CantidadMaterial);


                    PocionesFinal += InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcion)
                                    .Sum(x => x.CantidadMaterial) - mentasPrevias;


                }

            }


        }

        public async Task NoActualizarPociones()
        {
            await Task.Delay(1000);

            CompraPocionesNuevo = CompraPocionesNuevoOriginal.GetRange(0, CompraPocionesNuevoOriginal.Count);

        }

        #endregion

        public async Task Calcular() 
        {
            GuiaCapitulo = new();
            TitulosCapitulo = new();
            int capitulo = OpcionCapitulo == "" ? CapituloCristalPrevio : Capitulo;
            DateTime fecha = FechaActual;

            if (FechaActual < FechaInicial)
            {

                await JSRuntime.MostrarMensaje("¡Ojo",
                                               "la fecha actual no puede ser menor a la fecha del inicio del evento",
                                               Sweetalert2.TipoSweetalert2.info);

            }

            else if (FechaActual > FinalizarEvento)
            {
                await JSRuntime.MostrarMensaje("¡Ojo",
                                                 "la fecha actual no puede ser mayor a la fecha en que finaliza el evento",
                                                 Sweetalert2.TipoSweetalert2.info);
            }

            else if (ExpActual >= Convert.ToInt32(MaximoExp))
            {

                await JSRuntime.MostrarMensaje("¡Ojo",
                                               $"La exp del capitulo {capitulo} no puede ser mayor a {MaximoExp}",
                                               Sweetalert2.TipoSweetalert2.info);

            }
            else 
            {
                int exp = ExpActual;
                int nivelMaquina = 1;
                int pociones = PocionesFinal;

                if (OpcionPaqueteNutakuActual != "")
                {

                    int opcion = Convert.ToInt32(OpcionPaqueteNutakuActual);

                    nivelMaquina = InfoEvento.PaqueteNutakuGold
                                .Where(x => x.NivelProduccion - 1 == opcion)
                                .Select(x => x.NivelProduccion).FirstOrDefault();

                }

                else if (OpcionPaqueteNutakuPrevio != "")
                {
                    int opcion = Convert.ToInt32(OpcionPaqueteNutakuPrevio);

                    nivelMaquina = InfoEvento.PaqueteNutakuGold
                                .Where(x => x.NivelProduccion - 1 == opcion)
                                .Select(x => x.NivelProduccion).FirstOrDefault();
                }

                var capituloMaximo = InfoEvento.DataExp.Max(x => x.Capitulo);
                int opcionPregunta = OpcionPregunta == "" ? 0 : Convert.ToInt32(OpcionPregunta);

               
                for (var i = capitulo; i <= capituloMaximo; i++) 
                {
                    nivelMaquina = nivelMaquina >= i ? nivelMaquina : i ;
                    int materialMaquina = InfoEvento.InfoMaquina.FirstOrDefault(x => x.Nivel == nivelMaquina).Material;
                    List<DataExp> dataEXP = InfoEvento.DataExp.Where(x => x.Capitulo == i).ToList();
                    int expNecesaria = InfoEvento.ExperienciaNecesaria[i-1];
                    List<DataPregunta> dataPregunta = InfoEvento.DataPregunta.Where(x => x.Capitulo == i).ToList();

                    #region preguntas
                    if (opcionPregunta < dataPregunta.Max(x => x.Pregunta)) 
                    {
                        for (var j = opcionPregunta; j < dataPregunta.Max(x => x.Pregunta); j++) 
                        {
                            int diferencia = pociones - dataPregunta[j].Pocion;
                            int pocionesActuales = pociones;
                            if (diferencia < 0)
                            {
                                int requerido = dataPregunta[j].Pocion - pociones;

                                int recolectar = Convert.ToInt32(Math.Ceiling((decimal)requerido / (decimal)materialMaquina));

                                pociones += materialMaquina * recolectar - dataPregunta[j].Pocion;

                                fecha = fecha.AddMinutes(recolectar * 10);
                                GuiaCapitulo.Add(new()
                                {
                                    Day = fecha.Day,
                                    Month = fecha.Month,
                                    Hour = fecha.Hour,
                                    Minute = fecha.Minute,
                                    Capitulo = $"Capitulo {i}",
                                    Accion = "",
                                    Pregunta = dataPregunta[j].Pregunta.ToString(),
                                    Pociones = pociones
                                });
                            }
                            else 
                            {
                                pociones = diferencia;

                                GuiaCapitulo.Add(new()
                                {
                                    Day = fecha.Day,
                                    Month = fecha.Month,
                                    Hour = fecha.Hour,
                                    Minute = fecha.Minute,
                                    Capitulo = $"Capitulo {i}",
                                    Accion = "",
                                    Pregunta = dataPregunta[j].Pregunta.ToString(),
                                    Pociones = pociones

                                });

                            }
                        }
                    }
                    opcionPregunta = 0;
                    #endregion

                    #region comprobar Accion

                    int numeroAccionPrevio = OpcionCristalesPrevio[i - 1] != ""
                                     ? Convert.ToInt32(OpcionCristalesPrevio[i - 1]) : 1;

                    int numeroAccionActual = OpcionCristalesNuevo[i - 1] != ""
                                            ? Convert.ToInt32(OpcionCristalesNuevo[i - 1]) : 1;

                    int accion = numeroAccionPrevio >= numeroAccionActual 
                                 ? numeroAccionPrevio : numeroAccionActual;

                    for (var j = 0; j < dataEXP.Max(x => x.Accion); j++) 
                    {
                       
                        var expAccion = expNecesaria * dataEXP[j].Porcentaje;

                        if (exp >= expAccion && dataEXP[j].Accion > accion) 
                        {
                            accion = dataEXP[j].Accion;
                        }
                        
                    }

                    #endregion

                    #region exp

                    for (var j = accion; j <= dataEXP.Count; j++) 
                    {
                        int expAccion = Convert.ToInt32(dataEXP[j-1].Porcentaje * expNecesaria);
                        int diferenciaExp = expAccion - exp;

                        int pocionesNecesarias = Convert.ToInt32(Math.Ceiling((decimal) diferenciaExp /
                                                                              (decimal) dataEXP[j-1].Exp)) 
                                                * dataEXP[j - 1].Pocion;

                        int diferencia = pociones - pocionesNecesarias;
                        int PocionesActuales = pociones;

                        if (diferencia < 0)
                        {

                            int requerido = pocionesNecesarias - pociones;
                            int recolectar = Convert.ToInt32(Math.Ceiling((decimal)requerido / (decimal)materialMaquina));
                            pociones += materialMaquina * recolectar - pocionesNecesarias;
                            fecha = fecha.AddMinutes(recolectar * 10);
                            exp += pocionesNecesarias / dataEXP[j - 1].Pocion *  dataEXP[j - 1].Exp;

                            GuiaCapitulo.Add(new()
                            {
                                Day = fecha.Day,
                                Month = fecha.Month,
                                Hour = fecha.Hour,
                                Minute = fecha.Minute,
                                Capitulo = $"Capitulo {i}",
                                Accion = $"Acción {j}",
                                Pregunta = "",
                                Pociones = pociones

                            });

                        }
                        else 
                        {
                            pociones = diferencia;
                            exp += pocionesNecesarias * dataEXP[j-1].Exp;
                            GuiaCapitulo.Add(new()
                            {
                                Day = fecha.Day,
                                Month = fecha.Month,
                                Hour = fecha.Hour,
                                Minute = fecha.Minute,
                                Capitulo = $"Capitulo {i}",
                                Accion = $"Acción {j}",
                                Pregunta = "",
                                Pociones = pociones

                            });
                        }
                    }

                    #endregion

                    opcionPregunta = 0;
                    exp = 0;
                    GuiaCapitulo.Add(new()
                    {
                        Day = fecha.Day,
                        Month = fecha.Month,
                        Hour = fecha.Hour,
                        Minute = fecha.Minute,
                        Capitulo = $"Capitulo {i+1}",
                        Accion = "",
                        Pregunta = "",
                        Pociones = pociones

                    });

                    TitulosCapitulo.Add($"Capitulo {i}");

                }     
            }

            TiempoFinales = (FinalizarEvento - fecha);
            Horario.ActualizarFinal();
        }

    }
}
