namespace ProjectQT.Data.DataQuizDimensional
{
    public class InfoQuizDimensional
    {
        public string Version { get; set; }

        public int DuracionEvento { get; set; }

        public List<InfoMaquina> InfoMaquina { get; set; } 

        public List<DataExp> DataExp { get; set; }

        public int ExpDiario { get; set; }

        public int ExpSubidaNivel { get; set; }

        public List<int> ExperienciaNecesaria { get; set; }

        public List<InfoPaqueteGemas> PaqueteMentas { get; set; }

        public List<InfoPaqueteGemas> PaqueteRegalos { get; set; }

        public List<InfoPaqueteNutakuGold> PaqueteNutakuGold { get; set; }


    }
}
