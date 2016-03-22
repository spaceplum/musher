namespace Musher.EchoNest.Models
{
    public class Term
    {
        public string Name { get; set; }
        public TermType Type { get; set; }
        public double Frequency { get; set; }
        public double Weight { get; set; }
    }
}
