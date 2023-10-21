namespace ProjectQT.Data.DataDating
{
    public class InfoDating
    {
        public string Version { get; set; } = "";
        public int DuracionEvento { get; set; }
        public List<InfoMaquina> InfoMaquina { get; set; }
        public List<DataExp> DataExp { get; set; }
        public List<DataPregunta> DataPregunta { get; set; }
        public List<DataCristales> DataCristales { get; set; }
        public List<int> ExperienciaNecesaria { get; set; }
        public List<InfoPaqueteGemas> PaquetePociones { get; set; }
        public List<InfoPaqueteGemas> PaqueteCristales { get; set; }
        public List<InfoPaqueteNutakuGold> PaqueteNutakuGold { get; set; }
        public int MaximoCristalesRevival { get; set; }
    }
}
