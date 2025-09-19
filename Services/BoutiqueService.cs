using System;
using System.Collections.Generic;
using RPGBike.Models;

namespace RPGBike.Services
{
    public class BoutiqueService
    {
        public List<Accessoire> Accessoires { get; private set; }

        public BoutiqueService()
        {
            // Accessoires = new List<Accessoire>
            // {
            //     new Accessoire("Pneu tubeless", 10, "Réduit le risque de crevaison de 80%", ActionEffet.ReduitCrevaison),
            //     new Accessoire("Selle gel", 5, "Augmente le confort de 2", ActionEffet.AugmenteConfort),
            //     new Accessoire("Collation", 2, "Restauration et boost de vitesse pendant 10min", ActionEffet.BoostCollation),
            //     new Accessoire("Frein à disque", 5, "Meilleure endurance sous la pluie", ActionEffet.FreinDisque),
            //     new Accessoire("Casque aérodynamique", 6, "Réduit le risque d'accident et augmente la vitesse", ActionEffet.CasqueAero),
            //     new Accessoire("Formation peloton", 8, "Gain de vitesse avec risque d'accident en lançant un dé", ActionEffet.FormationPeloton)
            // };
            Accessoires = new List<Accessoire>
            {
                new Accessoire("Pneu tubeless", 10, "Réduit le risque de crevaison de 80%", ActionEffet.ReduitCrevaison, AccessoireType.Amelioration),
                new Accessoire("Selle gel", 5, "Augmente le confort de 2", ActionEffet.AugmenteConfort, AccessoireType.Amelioration),
                new Accessoire("Collation", 2, "Restauration et boost de vitesse pendant 10min", ActionEffet.BoostCollation, AccessoireType.Consommable),
                new Accessoire("Frein à disque", 5, "Meilleure endurance sous la pluie", ActionEffet.FreinDisque, AccessoireType.Amelioration),
                new Accessoire("Casque aérodynamique", 6, "Réduit le risque d'accident et augmente la vitesse", ActionEffet.CasqueAero, AccessoireType.Amelioration),
                new Accessoire("Formation peloton", 8, "Gain de vitesse avec risque d'accident", ActionEffet.FormationPeloton, AccessoireType.Amelioration)
            };

        }

        public void AfficherBoutique()
        {
            Console.WriteLine("Bienvenue dans la boutique officielle !");
            Console.WriteLine("Voici ce que nous vendons aujourd'hui :");
            Console.WriteLine("| Produit             | Prix (crédits) | Capacité / Effet                                   |");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            foreach (var acc in Accessoires)
            {
                Console.WriteLine($"| {acc.Nom.PadRight(19)} | {acc.Cout.ToString().PadRight(13)} | {acc.Description.PadRight(48)} |");
            }
            Console.WriteLine();
        }
    }
}
