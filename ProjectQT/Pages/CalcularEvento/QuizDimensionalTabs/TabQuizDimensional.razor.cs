using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ProjectQT.Componentes.Horarios.QuizDimensional;
using ProjectQT.Componentes.Sweetalert2;
using ProjectQT.Componentes.VentanaModal;
using ProjectQT.Data;
using ProjectQT.Data.DataQuizDimensional;
using ProjectQT.ReadJson;
using System;


namespace ProjectQT.Pages.CalcularEvento.QuizDimensionalTabs
{
    public class TabQuizDimensionalBase : ComponentBase
    {

        #region Tiempo

        public DateTime FechaInicial { get; set; } = new DateTime(2023, 10, 13, 4, 0, 0);
        public DateTime FinalizarEvento { get; set; }
        public DateTime FechaActual { get; set; } = new DateTime(2023, 10, 13, 4, 0, 0);

        public TimeSpan TiempoFinales { get; set; } = TimeSpan.Zero;

        #endregion

        #region selects

        public List<OpcionesSelect> OpcionesNiveles { get; set; } = new() {
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
            },
            new()
            {
                Valor = "5", Descripcion = "5"
            },
            new()
            {
                Valor = "6", Descripcion = "6"
            }
        };
        public string OpcionNivel { get; set; } = "";

        public List<OpcionesSelect> OpcionesPregunta { get; set; } = new();
        public string OpcionPregunta { get; set; } = "";
        public bool ActivarSelectPregunta { get; set; } = false;

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
        public int ExpFinal { get; set; } = 0;
        public string MinimoExp { get; set; } = "0";
        public string MaximoExp { get; set; } = "1000";
        public bool ActivarExp { get; set; } = true;
        public string MensajeExp { get; set; } = "Exp mínima 0 y máximo 1000";
        public string PatronMensajeExp { get; set; } = "Exp mínima {min} y máximo {max}";
        #endregion

        #region Lista Previo y actual mentas y regalos

        public List<int> MaximoMentasPrevio = new();
        public List<int> MaximoMentasActual = new();

        public List<int> MaximoRegalosPrevio = new();
        public List<int> MaximoRegalosActual = new();

        public List<int> CompraMentasPrevio { get; set; } = new() {
            0,0,0
        };

        public List<int> CompraMentasPrevioOriginal { get; set; } = new() {
            0,0,0
        };

        public List<int> CompraRegalosPrevio { get; set; } = new() {
            0,0,0,0
        };

        public List<int> CompraRegalosPrevioOriginal { get; set; } = new() {
            0,0,0,0
        };

        public List<int> CompraMentasActual { get; set; } = new() {
            0,0,0
        };

        public List<int> CompraMentasActualOriginal { get; set; } = new() {
            0,0,0
        };

        public List<int> CompraRegalosActual { get; set; } = new() {
            0,0,0,0
        };

        public List<int> CompraRegalosActualOriginal { get; set; } = new() {
            0,0,0,0
        };

        #endregion

        #region modal

        public List<string> TitulosModalPrevio { get; set; } = new() {
            "Registrar Regalos Previos", "Registrar Mentas Previos"
        };

        public List<string> TitulosModalActual { get; set; } = new() {
            "Comprar Regalos", "Comprar Mentas"
        };

        public List<string> TitulosModales { get; set; } = new();

        public List<string> TitulosNiveles { get; set; } = new();

        public List<string> TitulosNivelesDefecto { get; set; } = new() {

            "Nivel 1", "Nivel 2", "Nivel 3", "Nivel 4", "Nivel 5", "Nivel 6"

        };

        public List<string> NotaDelNivel { get; set; } = new();

        public VentanaModal ModalRecomendacion { get; set; } = new();

        #endregion

        #region ganancias y gastos

        public int GastosGemasPrevio { get; set; } = 0;
        public int GemasObtenidasPaqueteP2WPrevio { get; set; } = 0;

        public int GastosGemasActual { get; set; } = 0;
        public int GemasObtenidasPaqueteP2WActual { get; set; } = 0;


        public int TotalGemasGastadas { get; set; } = 0;
        public int TotalGemasObtenidas { get; set; } = 0;

        #endregion

        #region otros
        public InfoQuizDimensional InfoEvento { get; set; }
        public int MentasActual { get; set; } = 0;
        public int MentasFinal { get; set; } = 0;
        public int MentasPaquete { get; set; } = 0;

        [Inject]
        IJSRuntime JSRuntime { get; set; }


        public List<string> Collapsable { get; set; } = new() { "", "", "" };
        public List<string> CollapsableIcono { get; set; } = new() 
        { "fas fa-caret-left", "fas fa-caret-left", "fas fa-caret-left" };

        public HorarioNivelesQuizDimensionalBase Horario { get; set; } = new();

        public List<GuiaPreguntaTiempoDimensional> GuiaPregunta { get; set; } = new();

        [Inject]
        public IJsonApi JsonApi { get; set; }


        #endregion

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


        protected override async Task OnInitializedAsync()
        {

            InfoEvento = await JsonApi.JsonQuizDimensional("V2");

            FinalizarEvento = FechaInicial.AddDays(InfoEvento.DuracionEvento);

            TitulosModales = InfoEvento.PaqueteMentas.Select(x => $"Gemas: {x.CostoGemas}").ToList();

            MaximoMentasPrevio = InfoEvento.PaqueteMentas.Select(x => x.Maximo).ToList();
            MaximoMentasActual = InfoEvento.PaqueteMentas.Select(x => x.Maximo).ToList();

            MaximoRegalosPrevio = InfoEvento.PaqueteRegalos.Select(x => x.Maximo).ToList();
            MaximoRegalosActual = InfoEvento.PaqueteRegalos.Select(x => x.Maximo).ToList();

            ExpFinal = 1000;
            MentasFinal = 48;
            await Calcular();

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

        public void ActualizarFechaFinal(ChangeEventArgs  e) 
        {
            DateTime Fecha = Convert.ToDateTime(e.Value);

            FinalizarEvento = Fecha.AddDays(InfoEvento.DuracionEvento);

            FechaActual = Fecha;
        }


        public void ActualizarExp(ChangeEventArgs e)
        {
            try
            {
                int valor = Convert.ToInt32(e.Value);
                CalculoExp(valor);


            }
            catch (Exception ex) 
            {
                Console.WriteLine("ingreso una letra");
            }
            
        }

        public void ActualizarMentas(ChangeEventArgs e)
        {
            try
            {
                int valor = Convert.ToInt32(e.Value);

                CalculoMentas(valor);
            }

            catch (Exception ex)
            {
                Console.WriteLine("ingreso una letra");
            }

            StateHasChanged();
        }

        public void CalculoMentas(int mentas) 
        {
            for (int i = 0; i < 3; i++)
            {

                if (i == 0)
                {
                    MentasFinal = mentas + CompraMentasActual[i] * InfoEvento.PaqueteMentas[i].CantidadMaterial;
                }
                else
                {
                    MentasFinal += CompraMentasActual[i] * InfoEvento.PaqueteMentas[i].CantidadMaterial;

                }
            }

            if (OpcionPaqueteNutakuActual != "")
            {

                int opcion = Convert.ToInt32(OpcionPaqueteNutakuActual);


                if (OpcionPaqueteNutakuPrevio == "")
                {
                    MentasFinal += InfoEvento.PaqueteNutakuGold
                        .Where(x => x.NivelProduccion - 1 <= opcion)
                        .Sum(x => x.CantidadMaterial);
                }
                else
                {

                    int opcionPrevio = Convert.ToInt32(OpcionPaqueteNutakuPrevio);

                    int mentasPrevias = InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcionPrevio)
                                    .Sum(x => x.CantidadMaterial);


                    MentasFinal += InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcion)
                                    .Sum(x => x.CantidadMaterial) - mentasPrevias;
                }

            }      
        }

        public void CalculoExp(int exp)
        {
            for (int i = 0; i < 4; i++)
            {

                if (i == 0)
                {
                    ExpFinal = exp + CompraRegalosActual[i] * InfoEvento.PaqueteRegalos[i].CantidadMaterial;
                }
                else
                {
                    ExpFinal += CompraRegalosActual[i] * InfoEvento.PaqueteRegalos[i].CantidadMaterial;

                }
            }

            StateHasChanged();
        }

        #region metodos selects


        public async Task ActualizarVersion(string valorS)
        {
            OpcionVersion = valorS;

            if (OpcionVersion == "V1")
            {

                InfoEvento = await JsonApi.JsonQuizDimensional("V1");

            }
            else 
            {
                InfoEvento = await JsonApi.JsonQuizDimensional("V2");


            }
            FinalizarEvento = FechaActual.AddDays(InfoEvento.DuracionEvento);
            await Calcular();

        }

        public void ActualizarNumeroPreguntas(string ValorS)
        {
            OpcionNivel = ValorS;
            int pregunta = ValorS == "" ? 0 : Convert.ToInt32(ValorS);
            OpcionPregunta = "";

            if (pregunta == 0)
            {
                OpcionesPregunta = new();
                ActivarSelectPregunta = false;
                ActivarExp = true;
                ExpActual = 1000;
                ExpFinal = 1000;
                MinimoExp = "0";
                MaximoExp = "1000";
                MentasFinal = 48;
            }
            else
            {
                MentasFinal = 0;

                OpcionesPregunta = (from x in InfoEvento.DataExp
                                    where x.Nivel == pregunta
                                    select new OpcionesSelect
                                    {
                                        Descripcion = x.Pregunta.ToString(),
                                        Valor = x.Pregunta.ToString()

                                    }).ToList();

                ExpActual = InfoEvento.ExperienciaNecesaria[pregunta - 1] + InfoEvento.ExpSubidaNivel;
                ExpFinal = InfoEvento.ExperienciaNecesaria[pregunta - 1] + InfoEvento.ExpSubidaNivel;

                MinimoExp = InfoEvento.ExperienciaNecesaria[pregunta - 1].ToString();

                MaximoExp = InfoEvento.ExperienciaNecesaria[pregunta].ToString();

                ActivarExp = false;

                ActivarSelectPregunta = true;


            }

            MensajeExp = PatronMensajeExp.Replace("{min}", MinimoExp);
            MensajeExp = MensajeExp.Replace("{max}", MaximoExp);


            TotalGemasGastadas = 0;
            GastosGemasActual = 0;


            for (int i = 0; i < 4; i++)
            {

                ExpFinal = ExpActual + CompraRegalosActual[i] * InfoEvento.PaqueteRegalos[i].CantidadMaterial;
                GastosGemasActual += InfoEvento.PaqueteRegalos[i].CostoGemas * CompraRegalosActual[i];

            }

            CalculoMentas(MentasFinal);

            StateHasChanged();



        }

        public void ActualizarsSelectPaqueteP2W(string ValorS)
        {

            OpcionPaqueteNutakuPrevio = ValorS;
            OpcionPaqueteNutakuActual = "";
            GemasObtenidasPaqueteP2WPrevio = 0;
            GemasObtenidasPaqueteP2WActual = 0;
            TotalGemasObtenidas = 0;
            MentasFinal -= MentasPaquete;
            MentasPaquete = 0;

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
            GemasObtenidasPaqueteP2WActual = 0;
            TotalGemasObtenidas = 0;

            if (valorS != "")
            {

                int index = Convert.ToInt32(valorS);
                int indexPrevio = OpcionPaqueteNutakuPrevio == "" ? 0 : Convert.ToInt32(OpcionPaqueteNutakuPrevio);

                for (var i = indexPrevio; i < index; i++)
                {
                    GemasObtenidasPaqueteP2WActual += InfoEvento.PaqueteNutakuGold[i].Gemas;
                }

                int opcion = Convert.ToInt32(valorS);

                if (OpcionPaqueteNutakuPrevio == "")
                {


                    MentasFinal += InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcion)
                                    .Sum(x => x.CantidadMaterial) - MentasPaquete;


                    MentasPaquete = InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcion)
                                    .Sum(x => x.CantidadMaterial);

                }
                else
                {
                    int opcionPrevio = Convert.ToInt32(OpcionPaqueteNutakuPrevio);

                    int mentasPrevias = InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcionPrevio)
                                    .Sum(x => x.CantidadMaterial);


                    MentasFinal += InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcion)
                                    .Sum(x => x.CantidadMaterial) - mentasPrevias - MentasPaquete;

                    MentasPaquete = InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcion)
                                    .Sum(x => x.CantidadMaterial) - mentasPrevias;

                }

            }

            else 
            {
                MentasFinal -= MentasPaquete;
                MentasPaquete = 0;
            }

            TotalGemasObtenidas = GemasObtenidasPaqueteP2WActual + GemasObtenidasPaqueteP2WPrevio;
            

        }

        #endregion


        #region metodos modales

        public async Task ActualizarInfoActual()
        {
            await Task.Delay(1000);

            CompraMentasActual = new() {
                0,0,0
            };

            CompraRegalosActual = new() {
                0,0,0,0
            };

            CompraMentasActualOriginal = new() {
                0,0,0
            };

            CompraRegalosActualOriginal = new() {
                0,0,0,0
            };

            MaximoMentasActual = InfoEvento.PaqueteMentas.Select(x => x.Maximo).ToList();
            MaximoRegalosActual = InfoEvento.PaqueteRegalos.Select(x => x.Maximo).ToList();

            GastosGemasPrevio = 0;
            GastosGemasActual = 0;
            TotalGemasGastadas = 0;

            for (int i = 0; i < 4; i++)
            {

                if (i < 3)
                {
                    MaximoMentasActual[i] = MaximoMentasActual[i] - CompraMentasPrevio[i];
                    GastosGemasPrevio += InfoEvento.PaqueteMentas[i].CostoGemas * CompraMentasPrevio[i];

                }


                MaximoRegalosActual[i] = MaximoRegalosActual[i] - CompraRegalosPrevio[i];
                GastosGemasPrevio += InfoEvento.PaqueteRegalos[i].CostoGemas * CompraRegalosPrevio[i];


            }

            CompraMentasPrevioOriginal = CompraMentasPrevio.GetRange(0, CompraMentasPrevio.Count);
            CompraRegalosPrevioOriginal = CompraRegalosPrevio.GetRange(0, CompraRegalosPrevio.Count);

            TotalGemasGastadas = GastosGemasPrevio;

            CalculoMentas(OpcionNivel == "" ? 48 : MentasActual);
            CalculoExp(OpcionNivel == "" ? 1000 : ExpActual);

        }

        public async Task NoActualizarInfoActual()
        {
            await Task.Delay(1000);

            CompraMentasPrevio = CompraMentasPrevioOriginal.GetRange(0, CompraMentasPrevioOriginal.Count);
            CompraRegalosPrevio = CompraRegalosPrevioOriginal.GetRange(0, CompraRegalosPrevioOriginal.Count);

        }

        public async Task ActualizarExpMentas()
        {
            await Task.Delay(1000);

            TotalGemasGastadas = 0;
            GastosGemasActual = 0;


            for (int i = 0; i < 4; i++)
            {

                if (i < 3)
                {

                    if (i == 0)
                    {
                        if (OpcionNivel == "") 
                        {
                            MentasFinal = 48 + CompraMentasActual[i] * InfoEvento.PaqueteMentas[i].CantidadMaterial;

                        }
                        else
                        {
                            MentasFinal = MentasActual + CompraMentasActual[i] * InfoEvento.PaqueteMentas[i].CantidadMaterial;

                        }

                    }

                    else 
                    {
                        MentasFinal += CompraMentasActual[i] * InfoEvento.PaqueteMentas[i].CantidadMaterial;

                    }

                    GastosGemasActual += InfoEvento.PaqueteMentas[i].CostoGemas * CompraMentasActual[i];


                }

                if (i == 0 )
                {

                    ExpFinal = ExpActual + CompraRegalosActual[i]  * InfoEvento.PaqueteRegalos[i].CantidadMaterial;
                }
                else 
                {
                    ExpFinal +=  CompraRegalosActual[i] * InfoEvento.PaqueteRegalos[i].CantidadMaterial;
        

                }

                GastosGemasActual += InfoEvento.PaqueteRegalos[i].CostoGemas * CompraRegalosActual[i];


            }

            CompraMentasActualOriginal = CompraMentasActual.GetRange(0, CompraMentasActual.Count);
            CompraRegalosActualOriginal = CompraRegalosActual.GetRange(0, CompraRegalosActual.Count);



            TotalGemasGastadas = GastosGemasActual + GastosGemasPrevio;

            if (OpcionPaqueteNutakuActual != "")
            {

                int opcion = Convert.ToInt32(OpcionPaqueteNutakuActual);


                if (OpcionPaqueteNutakuPrevio == "")
                {
                    MentasFinal += InfoEvento.PaqueteNutakuGold
                        .Where(x => x.NivelProduccion - 1 <= opcion)
                        .Sum(x => x.CantidadMaterial);
                }
                else
                {

                    int opcionPrevio = Convert.ToInt32(OpcionPaqueteNutakuPrevio);

                    int mentasPrevias = InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcionPrevio)
                                    .Sum(x => x.CantidadMaterial);


                    MentasFinal += InfoEvento.PaqueteNutakuGold
                                    .Where(x => x.NivelProduccion - 1 <= opcion)
                                    .Sum(x => x.CantidadMaterial) - mentasPrevias;


                }

            }


        }

        public async Task NoActualizarExpMentas()
        {
            await Task.Delay(1000);

            CompraMentasActual = CompraMentasActualOriginal.GetRange(0, CompraMentasActualOriginal.Count);
            CompraRegalosActual = CompraRegalosActualOriginal.GetRange(0, CompraRegalosActualOriginal.Count);

        }
        #endregion


        public async Task Calcular()
        {

            GuiaPregunta = new();
            TitulosNiveles = new();
            NotaDelNivel = new();
            int nivel = OpcionNivel == "" ? 1 : Convert.ToInt32(OpcionNivel);
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

            else if (ExpActual < Convert.ToInt32(MinimoExp))
            {

                await JSRuntime.MostrarMensaje("¡Ojo",
                                               $"La exp del nivel {nivel} no puede ser inferior a {MinimoExp}",
                                               Sweetalert2.TipoSweetalert2.info);

            }

            else
            {
               
                int pregunta = OpcionPregunta == "" ? 1 : Convert.ToInt32(OpcionPregunta);
                int exp = OpcionNivel == "" ? InfoEvento.ExpSubidaNivel + ExpFinal : ExpFinal;

                int nivelMaquina = 1;

                int mentas = MentasFinal;
           
                int horaResets = FechaInicial.Hour;

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

                DateTime fechaReset = new DateTime(FechaActual.Year, FechaActual.Month, FechaActual.Day,
                                              horaResets, 0, 0);

                if (fecha.Hour >= horaResets)
                {
                    fechaReset = fecha.AddDays(1);
                    fechaReset = new DateTime(fechaReset.Year, fechaReset.Month, fechaReset.Day,
                                              horaResets, 0, 0);
                }




                var nivelMaximo = InfoEvento.DataExp.Max(x => x.Nivel);


                for (var i = nivel; i <= nivelMaximo; i++)
                {
                    nivelMaquina = i >= 3 && i < 5 && nivelMaquina == 1
                                   ? 2 : i == 5 && nivelMaquina == 2
                                   ? 3 : i == 6 ? 4 : nivelMaquina;

                    int materialMaquina = InfoEvento.InfoMaquina.FirstOrDefault(x => x.Nivel == nivelMaquina).Material;

                    List<DataExp> dataEXP = InfoEvento.DataExp.Where(x => x.Nivel == i).ToList();

                    int expNecesaria = InfoEvento.ExperienciaNecesaria[i];

                    if (exp >= expNecesaria)
                    {
                        pregunta = 1;
                        exp += InfoEvento.ExpSubidaNivel;
                        TitulosNiveles.Add($"Nivel {i}");
                    }
                    else 
                    {
                        for (int y = pregunta - 1; y < dataEXP.Count; y++)
                        {
                            int diferencia = mentas - dataEXP[y].Mentas;
                            int mentasActuales = mentas;

                            if (diferencia < 0)
                            {

                                int requerido = dataEXP[y].Mentas - mentas;

                                int recolectar = Convert.ToInt32(Math.Ceiling((decimal)requerido / (decimal)materialMaquina));

                                mentas += materialMaquina * recolectar - dataEXP[y].Mentas;

                                var fechaActual = fecha;
                                fecha = fecha.AddMinutes(recolectar * 10);

                                var diferenciaTiempos = (fechaReset - fechaActual);
                                var diferenciaTiemposRecorrido = (fechaReset - fecha);

                                if (expNecesaria - exp <= 1000 && fecha < FinalizarEvento &&
                                    (diferenciaTiempos.TotalMinutes <= 240 || 
                                    diferenciaTiemposRecorrido.TotalMinutes <= 240))
                                {

                                    GuiaPregunta.Add(new()
                                    {
                                        Day = fechaActual.Day,
                                        Month = fechaActual.Month,
                                        Hour = fechaActual.Hour,
                                        Minute = fechaActual.Minute,
                                        Nivel = $"Nivel {i}",
                                        Exp = exp + InfoEvento.ExpDiario,
                                        Pregunta = "Reset",
                                        Mentas = mentas

                                    });

                                    exp += InfoEvento.ExpSubidaNivel + InfoEvento.ExpDiario;

                                    mentas = mentasActuales;
                                    
                                    fecha = fechaReset;
                                    fechaReset = fecha.AddDays(1);
                                    fechaReset = new DateTime(fechaReset.Year, fechaReset.Month, fechaReset.Day,
                                                              horaResets, 0, 0);

                                    recolectar = Convert.ToInt32(Math.Floor(diferenciaTiempos.TotalMinutes/10));

                                    mentas += materialMaquina * recolectar;

                                    pregunta = 1;

                                    TitulosNiveles.Add($"Nivel {i}");
                             

                                    NotaDelNivel.Add($"<h1> Ojo: Esta nota solo se activa cuando el tiempo para el siguiente reset en inferior a 4 horas" +
                                                    $"</h1> " +
                                                     $"<label> No responder la pregunta {y+1} y esperar el reset, con el fin de conservar " +
                                                     $"mentas para el siguiente nivel </label>");

                                    break;

                                }
                                else 
                                {
                                   

                                    exp += dataEXP[y].Exp;

                                    

                                    if (fecha.Month == fechaReset.Month && fecha.Year == fechaReset.Year &&
                                        fecha.Day == fechaReset.Day && fecha.Hour >= horaResets &&
                                        fecha.Minute >= 0)
                                    {


                                        fechaReset = fecha.AddDays(1);
                                        fechaReset = new DateTime(fechaReset.Year, fechaReset.Month, fechaReset.Day,
                                                                  horaResets, 0, 0);


                                        if (fechaReset < FinalizarEvento)
                                        {
                                            exp += InfoEvento.ExpDiario;
                                        }


                                    }


                                    bool subidaNivel = exp >= expNecesaria;
 

                                    if (subidaNivel)
                                    {
                                        pregunta = 1;
                                        exp += InfoEvento.ExpSubidaNivel;
                                        TitulosNiveles.Add($"Nivel {i}");
                                        NotaDelNivel.Add("");

                                        GuiaPregunta.Add(new()
                                        {
                                            Day = fecha.Day,
                                            Month = fecha.Month,
                                            Hour = fecha.Hour,
                                            Minute = fecha.Minute,
                                            Nivel = $"Nivel {i}",
                                            Exp = exp,
                                            Pregunta = dataEXP[y].Pregunta.ToString(),
                                            Mentas = mentas

                                        });

                                        break;
                                    }

                                    GuiaPregunta.Add(new()
                                    {
                                        Day = fecha.Day,
                                        Month = fecha.Month,
                                        Hour = fecha.Hour,
                                        Minute = fecha.Minute,
                                        Nivel = $"Nivel {i}",
                                        Exp = exp,
                                        Pregunta = dataEXP[y].Pregunta.ToString()

                                    });
                                }
                                
                            }
                            else
                            {
                                mentas = diferencia;
                                exp += dataEXP[y].Exp;


                                bool subidaNivel = exp >= expNecesaria;

                                GuiaPregunta.Add(new()
                                {
                                    Day = fecha.Day,
                                    Month = fecha.Month,
                                    Hour = fecha.Hour,
                                    Minute = fecha.Minute,
                                    Nivel = $"Nivel {i}",
                                    Exp = exp,
                                    Pregunta = dataEXP[y].Pregunta.ToString()

                                });


                                if (subidaNivel)
                                {
                                    pregunta = 1;
                                    exp += InfoEvento.ExpSubidaNivel;
                                    TitulosNiveles.Add($"Nivel {i}");
                                    NotaDelNivel.Add("");

                                }
                   
                            }

                        }
                    }
                    
                    

                    pregunta = 1;
                    GuiaPregunta.Add(new()
                    {
                        Day = fecha.Day,
                        Month = fecha.Month,
                        Hour = fecha.Hour,
                        Minute = fecha.Minute,
                        Nivel = $"Nivel {i+1}",
                        Exp = exp,
                        Pregunta = "0",
                        Mentas = mentas

                    });

                }

            }

            TiempoFinales = (FinalizarEvento - fecha);

            Horario.ActualizarFinal();


        }

    }
}
