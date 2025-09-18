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
            Accessoires = new List<Accessoire>
            {
                new Accessoire("Pneu tubeless", 10, "Réduit le risque de crevaison de 80%", ActionEffet.ReduitCrevaison),
                new Accessoire("Selle gel", 5, "Augmente le confort de 2", ActionEffet.AugmenteConfort),
                new Accessoire("Collation", 2, "Restauration glycogénique et musculaire, +4 km/h pendant 10 min", ActionEffet.BoostCollation),
                new Accessoire("Frein à disque", 5, "Meilleure endurance sous la pluie", ActionEffet.FreinDisque)
            };
        }

        public void AfficherBoutique()
        {
            Console.WriteLine("Bienvenue dans la boutique officielle !");
            Console.WriteLine("Voici ce que nous vendons aujourd'hui :");
            Console.WriteLine("| Produit       | Prix (crédits) | Capacité / Effet                        |");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var acc in Accessoires)
            {
                Console.WriteLine($"| {acc.Nom.PadRight(13)} | {acc.Cout.ToString().PadRight(13)} | {acc.Description.PadRight(35)} |");
            }
            Console.WriteLine();
        }
    }
}
