namespace kreator_pomieszczen.Models
{
    public class Pomieszczenie
    {
        public int Id { get; set; }

        public string? Nazwa { get; set; }

        public decimal Szerokosc { get; set; }

        public decimal Dlugosc { get; set; }

        public decimal Wysokosc { get; set; }
    }
}
