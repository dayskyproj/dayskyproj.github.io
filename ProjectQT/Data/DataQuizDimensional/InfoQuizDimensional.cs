namespace ProjectQT.Data.DataQuizDimensional
{
    public class InfoQuizDimensional
    {

        public int DuracionEvento { get; } = 9;

        public List<InfoMaquina> InfoMaquina { get; } = new()
        {
            new()
            {
               Nivel = 1, Material = 4
            },
            new()
            {
               Nivel = 2, Material = 5
            },
            new()
            {
               Nivel = 3, Material = 7
            },
            new()
            {
               Nivel = 4, Material = 9
            },

        };

        public List<DataExp> DataExp { get; } = new()
        {
            new ()
            {
                Nivel = 1,  Pregunta = 1,Mentas = 25, Exp = 500

            },
            new ()
            {
                Nivel = 1, Pregunta = 2,  Mentas = 25, Exp = 500

            },
             new ()
            {
                Nivel = 1, Pregunta = 3,  Mentas = 50, Exp = 980

            },
             new ()
            {
                Nivel = 1, Pregunta = 4,  Mentas = 50, Exp = 980

            },
            new ()
            {
                Nivel = 1, Pregunta = 5,  Mentas = 150, Exp = 4000

            },
            new ()
            {
                Nivel = 1, Pregunta = 6,  Mentas = 200, Exp = 6000

            },
            new ()
            {
                Nivel = 1, Pregunta = 7,  Mentas = 20, Exp = 1750

            },
            new ()
            {
                Nivel = 2,  Pregunta = 1,Mentas = 25, Exp = 500

            },
            new ()
            {
                Nivel = 2, Pregunta = 2,  Mentas = 25, Exp = 500

            },
             new ()
            {
                Nivel = 2, Pregunta = 3,  Mentas = 50, Exp = 1040

            },
             new ()
            {
                Nivel = 2, Pregunta = 4,  Mentas = 150, Exp = 3000

            },
            new ()
            {
                Nivel = 2, Pregunta = 5,  Mentas = 200, Exp = 6000

            },
            new ()
            {
                Nivel = 3,  Pregunta = 1, Mentas = 25, Exp = 500

            },
            new ()
            {
                Nivel = 3, Pregunta = 2,  Mentas = 25, Exp = 500

            },
             new ()
            {
                Nivel = 3, Pregunta = 3,  Mentas = 100, Exp = 2000

            },
             new ()
            {
                Nivel = 3, Pregunta = 4,  Mentas = 200, Exp = 4000

            },
            new ()
            {
                Nivel = 3, Pregunta = 5,  Mentas = 400, Exp = 8000

            },
            new ()
            {
                Nivel = 3, Pregunta = 6,  Mentas = 85, Exp = 1750

            },
            new ()
            {
                Nivel = 4,  Pregunta = 1, Mentas = 30, Exp = 600

            },
            new ()
            {
                Nivel = 4, Pregunta = 2,  Mentas = 30, Exp = 600

            },
             new ()
            {
                Nivel = 4, Pregunta = 3,  Mentas = 50, Exp = 1000

            },
             new ()
            {
                Nivel = 4, Pregunta = 4,  Mentas = 100, Exp = 2000

            },
            new ()
            {
                Nivel = 4, Pregunta = 5,  Mentas = 100, Exp = 2000

            },
            new ()
            {
                Nivel = 4, Pregunta = 6,  Mentas = 150, Exp = 3000

            },
            new ()
            {
                Nivel = 4, Pregunta = 7,  Mentas = 150, Exp = 3000

            },
            new ()
            {
                Nivel = 4, Pregunta = 8,  Mentas = 200, Exp = 4000

            },
            new ()
            {
                Nivel = 4, Pregunta = 9,  Mentas = 200, Exp = 4000

            },
            new ()
            {
                Nivel = 4, Pregunta = 10,  Mentas = 400, Exp = 8000

            },
            new ()
            {
                Nivel = 4, Pregunta = 11,  Mentas = 135, Exp = 2750

            },
            new ()
            {
                Nivel = 5, Pregunta = 1,  Mentas = 100, Exp = 2020

            },
            new ()
            {
                Nivel = 5, Pregunta = 2,  Mentas = 115, Exp = 2300

            },
            new ()
            {
                Nivel = 5, Pregunta = 3,  Mentas = 200, Exp = 4000

            },
            new ()
            {
                Nivel = 5, Pregunta = 4,  Mentas = 200, Exp = 4000

            },
            new ()
            {
                Nivel = 5, Pregunta = 5,  Mentas = 420, Exp = 8400

            },
            new ()
            {
                Nivel = 5, Pregunta = 6,  Mentas = 420, Exp = 8400

            },
            new ()
            {
                Nivel = 5, Pregunta = 7,  Mentas = 560, Exp = 11200

            },
             new ()
            {
                Nivel = 5, Pregunta = 8,  Mentas = 50, Exp = 1000

            },
            new ()
            {
                Nivel = 6, Pregunta = 1,  Mentas = 190, Exp = 3800

            },
            new ()
            {
                Nivel = 6, Pregunta = 2,  Mentas = 200, Exp = 4000

            },
            new ()
            {
                Nivel = 6, Pregunta = 3,  Mentas = 540, Exp = 10790

            },
            new ()
            {
                Nivel = 6, Pregunta = 4,  Mentas = 540, Exp = 10790

            },
            new ()
            {
                Nivel = 6, Pregunta = 5,  Mentas = 630, Exp = 12600

            },
            new ()
            {
                Nivel = 6, Pregunta = 6,  Mentas = 630, Exp = 12600

            },
            new ()
            {
                Nivel = 6, Pregunta = 7,  Mentas = 720, Exp = 14400

            },
        };

        public int ExpDiario { get; } = 1000;

        public int ExpSubidaNivel { get; } = 750;

        public List<int> ExperienciaNecesaria { get; } = new()
        {
            1000, 15710, 27500, 44250, 75200, 118270, 190000
        };

        public List<InfoPaqueteGemas> PaqueteMentas { get; set; } = new()
        {
            new()
            {
                Maximo = 5, CostoGemas = 100, CantidadMaterial = 15
            },
            new()
            {
                Maximo = 10, CostoGemas = 200, CantidadMaterial = 15
            },
            new()
            {
                Maximo = 999, CostoGemas = 300, CantidadMaterial = 15
            },

        };

        public List<InfoPaqueteGemas> PaqueteRegalos { get; set; } = new()
        {
            new()
            {
                Maximo = 999, CostoGemas = 100, CantidadMaterial = 150
            },
            new()
            {
                Maximo = 80, CostoGemas = 300, CantidadMaterial = 600
            },
            new()
            {
                Maximo = 50, CostoGemas = 500, CantidadMaterial = 1250
            },
            new()
            {
                Maximo = 25, CostoGemas = 1000, CantidadMaterial = 3000
            },

        };

        public List<InfoPaqueteNutakuGold> PaqueteNutakuGold { get; } = new()
        {
            new()
            {
                PrecioNutaku = 1000, Gemas = 300, CantidadMaterial = 200, NivelProduccion = 2
            },
            new()
            {
                PrecioNutaku = 3000, Gemas = 900, CantidadMaterial = 600, NivelProduccion = 3
            },
            new()
            {
                PrecioNutaku = 6000, Gemas = 1800, CantidadMaterial = 1200, NivelProduccion = 4
            },

        };


    }
}
