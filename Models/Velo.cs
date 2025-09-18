using System;
using System.Collections.Generic;
using RPGBike.Models;

namespace RPGBike.Models
{
    public class Velo
    {
        public string Nom { get; set; }
        public int Vitesse { get; set; }
        public int Confort { get; set; }
        public int Resistance { get; set; }
        public int Cout { get; set; }

        public List<Accessoire> Accessoires { get; private set; } = new();

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
            if (Accessoires.Count > 0)
            {
                Console.WriteLine("Accessoires :");
                foreach (var acc in Accessoires)
                {
                    Console.WriteLine($"- {acc.Nom}");
                }
            }
        }

        public void AjouterAccessoire(Accessoire accessoire)
        {
            Accessoires.Add(accessoire);
            Console.WriteLine($"Accessoire {accessoire.Nom} ajouté au vélo {Nom}.");
        }

        public int GetBonusConfort()
        {
            int bonus = 0;
            foreach (var acc in Accessoires)
            {
                if (acc.Effet == ActionEffet.AugmenteConfort)
                    bonus += 2;
            }
            return bonus;
        }

        public bool AUnAccessoire(ActionEffet effet)
        {
            foreach (var acc in Accessoires)
            {
                if (acc.Effet == effet)
                    return true;
            }
            return false;
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
