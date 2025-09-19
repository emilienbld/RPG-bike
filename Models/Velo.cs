using System;
using System.Collections.Generic;

namespace RPGBike.Models
{
    public class Velo
    {
        public string Nom { get; set; }
        public int Vitesse { get; set; }
        public int Confort { get; set; }
        public int Resistance { get; set; }
        public int Cout { get; set; }

        public List<Accessoire> Ameliorations { get; private set; } = new();

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
            if (Ameliorations.Count > 0)
            {
                Console.WriteLine("Améliorations :");
                foreach (var acc in Ameliorations)
                {
                    Console.WriteLine($"- {acc.Nom}");
                }
            }
            Console.WriteLine();
        }

        public void AjouterAmelioration(Accessoire accessoire)
        {
            if (accessoire.Type == AccessoireType.Amelioration)
            {
                Ameliorations.Add(accessoire);
                Console.WriteLine($"Amélioration {accessoire.Nom} ajoutée au vélo {Nom}.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Cet accessoire n'est pas une amélioration du vélo.");
                Console.WriteLine();
            }
        }

        public bool AUneAmelioration(ActionEffet effet)
        {
            foreach (var acc in Ameliorations)
            {
                if (acc.Effet == effet)
                    return true;
            }
            return false;
        }

        public int GetBonusConfort()
        {
            int bonus = 0;
            foreach (var acc in Ameliorations)
            {
                if (acc.Effet == ActionEffet.AugmenteConfort)
                    bonus += 2;
            }
            return bonus;
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
