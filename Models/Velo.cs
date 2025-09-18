namespace RPGBike.Models
{
    public class Velo
    {
        public string Nom { get; set; }
        public int Vitesse { get; set; }
        public int Confort { get; set; }
        public int Resistance { get; set; }
        public int Cout { get; set; }

        public Velo(string nom, int vitesse, int confort, int resistance, int cout)
        {
            Nom = nom;
            Vitesse = vitesse;
            Confort = confort;
            Resistance = resistance;
            Cout = cout;
        }

        public virtual void AfficherInfo()
        {
            Console.WriteLine($"Type : {Nom}");
            Console.WriteLine($"Vitesse : {Vitesse}");
            Console.WriteLine($"Confort : {Confort}");
            Console.WriteLine($"Résistance : {Resistance}");
            Console.WriteLine($"Coût : {Cout} crédits");
        }
    }

    public class VeloRoute : Velo
    {
        public VeloRoute() : base("Route", 10, 5, 6, 15) { }
    }

    public class VeloGravel : Velo
    {
        public VeloGravel() : base("Gravel", 8, 8, 7, 12) { }
    }

    public class VTT : Velo
    {
        public VTT() : base("VTT", 7, 9, 10, 10) { }
    }
}
