using System;
using RPGBike.Models;
using RPGBike.Services;

namespace RPGBike.Models
{
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
        private Random random = new();

        public Course(string nom, TypeTerrain terrain, int distance)
        {
            Nom = nom;
            Terrain = terrain;
            Distance = distance;
        }

        public int SimulerCourse(Velo velo, PlayerService player, bool pluie = true)
        {
            Console.WriteLine($"Début de la course {Nom} sur terrain {Terrain}, distance {Distance}km.");
            int vitesseEffective = velo.Vitesse + velo.GetBonusConfort();

            if (pluie)
            {
                Console.WriteLine("Il pleut pendant la course !");
                if (!velo.AUneAmelioration(ActionEffet.FreinDisque))
                {
                    vitesseEffective -= 3;
                    Console.WriteLine("Votre vélo sans frein à disque roule moins vite sous la pluie.");
                }
                else
                {
                    Console.WriteLine("Vos freins à disque vous aident à maintenir votre vitesse sous la pluie.");
                }
            }
            else
            {
                Console.WriteLine($"Vous profitez d'un beau temps pour cette course.");
            }

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

            Console.WriteLine($"Vitesse moyenne en fonction du terrain et accessoires : {vitesseEffective} km/h");

            int risqueCrevaison = 10;
            if (velo.AUneAmelioration(ActionEffet.ReduitCrevaison))
            {
                risqueCrevaison = 2;
                Console.WriteLine("Votre pneu tubeless réduit fortement le risque de crevaison.");
            }

            int eventChance = random.Next(100);
            bool collation = false;

            bool formationPelotonActive = false;
            int pelotonBonusVitesse = 0;

            if (velo.AUneAmelioration(ActionEffet.FormationPeloton))
            {
                Console.WriteLine("Voulez-vous utiliser votre formation peloton pour booster votre vitesse ? (O/N)");
                string repPeloton = Console.ReadLine().ToUpper();
                if (repPeloton == "O")
                {
                    formationPelotonActive = true;
                    int nbCoEquipiers = random.Next(1, 6);
                    pelotonBonusVitesse = nbCoEquipiers;
                    vitesseEffective += pelotonBonusVitesse;
                    Console.WriteLine($"Peloton avec {nbCoEquipiers} coéquipier(s), gain de vitesse {pelotonBonusVitesse} km/h !");
                    int risqueAccident = 5 * nbCoEquipiers;
                    int rollAccident = random.Next(100);
                    if (rollAccident < risqueAccident)
                    {
                        Console.WriteLine("Accident dans le peloton !");
                        if (velo.AUneAmelioration(ActionEffet.CasqueAero))
                        {
                            Console.WriteLine("Casque aérodynamique réduit les conséquences, mais vous avez perdu 2km/h de moyenne.");
                            vitesseEffective -= 2;
                        }
                        else
                        {
                            vitesseEffective -= 5;
                            Console.WriteLine("L'accident vous fait perdre 5km/h de moyenne.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Vous avez un bon peloton et évitez l'accident de justesse.");
                    }
                }
            }

            if (eventChance < risqueCrevaison)
            {
                Console.WriteLine("Vous avez crevé !");
                Console.WriteLine("Voulez-vous dépenser 5 crédits pour réparation rapide ? (O/N)");
                string rep = Console.ReadLine().ToUpper();
                if (rep == "O" && player.Credit >= 5)
                {
                    player.DepenserCredits(5);
                    Console.WriteLine("Réparation express, vous reprenez la course et perdez que 1km/h de moyenne !");
                    vitesseEffective -= 1;
                }
                else
                {
                    Console.WriteLine("La réparation prend du temps, vous perdez 4km/h de moyenne");
                    vitesseEffective -= 4;
                }
            }

            if (eventChance < 20)
            {
                collation = true;
                Console.WriteLine($"Vos supporters vous ont donné une collation, vous avez fait le plein d'énergie (+4 km/h de moyenne) !");
                vitesseEffective += 4;
            }
            else
            {
                Console.WriteLine("La course est très calme, vous n'avez pas beaucoup de supporters.");
            }

            if (player.InventaireConsommables.Find(c => c.Accessoire.Effet == ActionEffet.BoostCollation) != null)
            {
                Console.WriteLine("Vous avez une collation. Voulez-vous la consommer maintenant ? (O/N)");
                string repColl = Console.ReadLine().ToUpper();
                if (repColl == "O")
                {
                    bool consomme = player.UtiliserConsommable("Collation");
                    if (consomme)
                    {
                        Console.WriteLine("Boost de 4 km/h pour 10 minutes activé !");
                        vitesseEffective += 4;
                    }
                    else
                    {
                        Console.WriteLine("Erreur: Vous n'avez plus de collation.");
                    }
                }
            }

            double tempsHeures = (double)Distance / vitesseEffective;
            int tempsMinutes = (int)(tempsHeures * 60);

            Console.WriteLine($"Temps estimé : {tempsMinutes} minutes.");

            int creditsGagnes = Distance + (formationPelotonActive ? pelotonBonusVitesse : 0);
            player.AjouterCredits(creditsGagnes);

            Console.WriteLine($"Vous avez donc mis {tempsMinutes} minutes pour finir la course {Nom}.");
            Console.WriteLine($"Cela vous fait un total de {player.Credit} crédits.");

            return tempsMinutes;
        }
    }
}
