using System;

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

public enum TypeTerrain
{
    Asphalte,
    Gravier,
    Sentier
}

public class Course
{
    public string Nom { get; set; }
    public TypeTerrain Terrain { get; set; }
    public int Distance { get; set; }
    private Random random = new Random();

    public Course(string nom, TypeTerrain terrain, int distance)
    {
        Nom = nom;
        Terrain = terrain;
        Distance = distance;
    }

    public int SimulerCourse(Velo velo, ref int credit)
    {
        Console.WriteLine($"Début de la course {Nom} sur terrain {Terrain}, distance {Distance}km.");
        int vitesseEffective = velo.Vitesse;

        switch (Terrain)
        {
            case TypeTerrain.Asphalte:
                if (velo is VeloGravel || velo is VTT)
                    vitesseEffective -= 2;
                break;
            case TypeTerrain.Gravier:
                if (velo is VeloRoute)
                    vitesseEffective -= 3;
                break;
            case TypeTerrain.Sentier:
                if (velo is VeloRoute || velo is VeloGravel)
                    vitesseEffective -= 4;
                break;
        }

        int eventChance = random.Next(100);
        if (eventChance < 10)
        {
            Console.WriteLine("Vous avez crevé !");
            Console.WriteLine("Dépensez 5 crédits pour changer rapidement le pneu, sinon le temps sera augmenté.");
            if (credit >= 5)
            {
                credit -= 5;
                Console.WriteLine("Crédits dépensés, tu repars rapidement !");
            }
            else
            {
                Console.WriteLine("Pas assez de crédits, le temps va augmenter de 15 minutes...");
                vitesseEffective -= 3;
            }
        }
        else if (eventChance < 20)
        {
            Console.WriteLine("Vos supporters vous ont donné une collation, vous avez fait le plein d'énergie !");
            vitesseEffective += 2;
        }
        else
        {
            Console.WriteLine("La course est très calme, vous n'avez pas beaucoup de supporters.");
        }

        double tempsHeures = (double)Distance / vitesseEffective;
        int tempsMinutes = (int)(tempsHeures * 60);

        Console.WriteLine($"Temps de course estimé : {tempsMinutes} minutes.");
        return tempsMinutes;
    }
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

        int credit = 10;

        Course course1 = new Course("La Classique", TypeTerrain.Gravier, 20);

        Console.WriteLine("Course avec Vélo Route");
        course1.SimulerCourse(veloRoute, ref credit);
        Console.WriteLine($"Crédit restant : {credit}");
        Console.WriteLine();

        Console.WriteLine("Course avec Vélo Gravel");
        course1.SimulerCourse(veloGravel, ref credit);
        Console.WriteLine($"Crédit restant : {credit}");
        Console.WriteLine();

        Console.WriteLine("Course avec VTT");
        course1.SimulerCourse(vtt, ref credit);
        Console.WriteLine($"Crédit restant : {credit}");
        Console.WriteLine();
    }
}