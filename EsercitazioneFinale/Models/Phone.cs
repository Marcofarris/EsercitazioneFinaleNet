namespace EsercitazioneFinale.Models
{
    public class Phone
    {
        public string vendor { get; set; }
        public string model { get; set; }
        public int price { get; set; } = new Random().Next(400, 800);


    }
}
