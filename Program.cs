public class Velo
{
    public string Nom { get; set; }
    public int Vitesse { get; set; }
    public int Confort { get; set; }
    public int Resistance { get; set; }

    public Velo(string nom, int vitesse, int confort, int resistance)
    {
        Nom = nom;
        Vitesse = vitesse;
        Confort = confort;
        Resistance = resistance;
    }

    public virtual void AfficherInfo()
    {
        Console.WriteLine($"Type : {Nom}");
        Console.WriteLine($"Vitesse : {Vitesse}");
        Console.WriteLine($"Confort : {Confort}");
        Console.WriteLine($"Résistance : {Resistance}");
    }
}

public class VeloRoute : Velo
{
    public VeloRoute() : base("Route", 10, 5, 6) { }
}

public class VeloGravel : Velo
{
    public VeloGravel() : base("Gravel", 8, 8, 7) { }
}

public class VTT : Velo
{
    public VTT() : base("VTT", 7, 9, 10) { }
}

class Program
{
    static void Main(string[] args)
    {
        Velo veloRoute = new VeloRoute();
        Velo veloGravel = new VeloGravel();
        Velo vtt = new VTT();

        Console.WriteLine("Infos vélo Route :");
        veloRoute.AfficherInfo();
        Console.WriteLine();

        Console.WriteLine("Infos vélo Gravel :");
        veloGravel.AfficherInfo();
        Console.WriteLine();

        Console.WriteLine("Infos VTT :");
        vtt.AfficherInfo();
        Console.WriteLine();
    }
}
