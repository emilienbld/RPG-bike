using System;
using System.Collections.Generic;
using System.Linq;
using RPGBike.Models;

namespace RPGBike.Services
{
    public class ConsumableItem
    {
        public Accessoire Accessoire { get; private set; }
        public int Quantite { get; private set; }

        public ConsumableItem(Accessoire accessoire, int quantite)
        {
            Accessoire = accessoire;
            Quantite = quantite;
        }

        public void Ajouter(int qte)
        {
            Quantite += qte;
        }

        public bool Utiliser()
        {
            if (Quantite > 0)
            {
                Quantite--;
                return true;
            }
            return false;
        }
    }

    public class PlayerService
    {
        public int Credit { get; private set; }
        public List<ConsumableItem> InventaireConsommables { get; private set; }

        public PlayerService(int creditInitial)
        {
            Credit = creditInitial;
            InventaireConsommables = new List<ConsumableItem>();
        }

        public void AjouterCredits(int montant)
        {
            Credit += montant;
        }

        public bool DepenserCredits(int montant)
        {
            if (montant > Credit) return false;
            Credit -= montant;
            return true;
        }

        public void AjouterConsommable(Accessoire accessoire, int quantite = 1)
        {
            if (accessoire.Type != AccessoireType.Consommable) return;

            var item = InventaireConsommables.FirstOrDefault(c => c.Accessoire.Nom == accessoire.Nom);
            if (item != null)
                item.Ajouter(quantite);
            else
                InventaireConsommables.Add(new ConsumableItem(accessoire, quantite));

            Console.WriteLine($"{quantite} {accessoire.Nom}(s) ajouté(s) à votre inventaire.");
        }

        public bool UtiliserConsommable(string nom)
        {
            var item = InventaireConsommables.FirstOrDefault(c => c.Accessoire.Nom == nom);
            if (item != null && item.Utiliser())
            {
                Console.WriteLine($"Vous avez utilisé un(e) {nom}.");
                if (item.Quantite == 0)
                {
                    InventaireConsommables.Remove(item);
                    Console.WriteLine($"{nom} épuisé dans l'inventaire.");
                }
                return true;
            }
            Console.WriteLine($"{nom} indisponible dans l'inventaire.");
            return false;
        }

        public void AfficherInventaire()
        {
            Console.WriteLine("Inventaire consommables :");
            if (!InventaireConsommables.Any())
            {
                Console.WriteLine("Aucun consommable en stock.");
                return;
            }
            foreach (var item in InventaireConsommables)
            {
                Console.WriteLine($"- {item.Accessoire.Nom} x{item.Quantite}");
            }
        }
    }
}
