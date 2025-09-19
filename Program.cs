using System;
using RPGBike.Models;
using RPGBike.Services;

namespace RPGBike
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerService player = new PlayerService(20);
            Velo[] velos = { new VeloRoute(), new VeloGravel(), new VTT() };
            Course[] courses = {
                new Course("La Classique", TypeTerrain.Asphalte, 15),
                new Course("La Gravière", TypeTerrain.Gravier, 20),
                new Course("Sentier Sauvage", TypeTerrain.Sentier, 10)
            };
            BoutiqueService boutique = new BoutiqueService();

            Velo choixVelo = null;
            bool quitteJeu = false;
            
            Console.Clear();
            Console.WriteLine("Bienvenue dans RPG-bike !");
            Console.WriteLine($"Vous commencez avec {player.Credit} crédits.\n");

            while (!quitteJeu)
            {
                Console.WriteLine("=== RPG-bike ===");
                Console.WriteLine("1 - Choisir un vélo");
                Console.WriteLine("2 - Boutique");
                Console.WriteLine("3 - Choisir une course");
                Console.WriteLine("4 - Inventaire consommables");
                Console.WriteLine("5 - Quitter");
                Console.Write("Que voulez-vous faire ? : ");
                string choix = Console.ReadLine();
                Console.WriteLine();

                switch (choix)
                {
                    case "1":
                        Console.WriteLine("Choix du vélo :");
                        for (int i = 0; i < velos.Length; i++)
                        {
                            velos[i].AfficherInfo();
                            Console.WriteLine();
                        }
                        Console.Write("Numéro du vélo : ");
                        if (int.TryParse(Console.ReadLine(), out int numVelo) && numVelo >= 1 && numVelo <= velos.Length)
                        {
                            var veloChoisi = velos[numVelo - 1];
                            if (player.DepenserCredits(veloChoisi.Cout))
                            {
                                choixVelo = veloChoisi;
                                Console.WriteLine($"Vous avez choisi le vélo {choixVelo.Nom}. Il vous coûte {choixVelo.Cout} crédits.");
                                Console.WriteLine($"Banque : {player.Credit} crédits.");
                                Console.WriteLine("Choisissez maintenant une course.");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Vous n'avez pas assez de crédits pour ce vélo.");
                                Console.WriteLine($"Banque : {player.Credit} crédits.");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Choix invalide.");
                            Console.WriteLine();
                        }
                        break;

                    case "2":
                        boutique.AfficherBoutique();
                        Console.WriteLine($"Banque : {player.Credit} crédits.");
                        Console.Write("Entrez le nom du produit à acheter ou Q pour quitter la boutique : ");
                        string achat = Console.ReadLine();
                        if (achat.ToUpper() == "Q") break;

                        var accessoire = boutique.Accessoires.Find(a => a.Nom.Equals(achat, StringComparison.OrdinalIgnoreCase));
                        if (accessoire == null)
                        {
                            Console.WriteLine("Produit inconnu.");
                            Console.WriteLine();
                        }
                        else if (player.Credit < accessoire.Cout)
                        {
                            Console.WriteLine("Crédits insuffisants.");
                            Console.WriteLine($"Banque : {player.Credit} crédits.");
                            Console.WriteLine();
                        }
                        else if (choixVelo == null && accessoire.Type == AccessoireType.Amelioration)
                        {
                            Console.WriteLine("Vous devez choisir un vélo avant d'acheter des améliorations.");
                            Console.WriteLine();
                        }
                        else
                        {
                            player.DepenserCredits(accessoire.Cout);
                            if (accessoire.Type == AccessoireType.Amelioration)
                            {
                                choixVelo.AjouterAmelioration(accessoire);
                            }
                            else
                            {
                                player.AjouterConsommable(accessoire);
                            }
                            Console.WriteLine($"Merci pour votre achat. Banque : {player.Credit}");
                            Console.WriteLine();
                        }
                        break;

                    case "3":
                        if (choixVelo == null)
                        {
                            Console.WriteLine("Vous devez d'abord choisir un vélo !");
                            Console.WriteLine();
                            break;
                        }
                        Console.WriteLine("Choix de la course :");
                        for (int i = 0; i < courses.Length; i++)
                        {
                            Console.WriteLine($"{i + 1} - {courses[i].Nom} ({courses[i].Terrain}, {courses[i].Distance} km)");
                        }
                        Console.Write("Numéro de la course (ou R pour un choix aléatoire): ");
                        string inputCourse = Console.ReadLine();
                        Course courseChoisie = null;
                        if (inputCourse.ToUpper() == "R")
                        {
                            var rnd = new Random();
                            courseChoisie = courses[rnd.Next(courses.Length)];
                            Console.WriteLine($"Course aléatoire choisie : {courseChoisie.Nom}");
                            Console.WriteLine();
                        }
                        else if (int.TryParse(inputCourse, out int numCourse) && numCourse >= 1 && numCourse <= courses.Length)
                        {
                            courseChoisie = courses[numCourse - 1];
                            Console.WriteLine($"Course choisie : {courseChoisie.Nom}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Choix invalide.");
                            Console.WriteLine();
                            break;
                        }
                        courseChoisie.SimulerCourse(choixVelo, player);
                        break;

                    case "4":
                        player.AfficherInventaire();
                        break;

                    case "5":
                        quitteJeu = true;
                        Console.Clear();
                        Console.WriteLine("Merci d'avoir joué. À bientôt !");
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("Choix invalide.");
                        Console.WriteLine();
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
