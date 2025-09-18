// using System;
// using RPGBike.Models;

// namespace RPGBike
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             int credit = 20;
//             Velo[] velos = { new VeloRoute(), new VeloGravel(), new VTT() };

//             Course[] courses = {
//                 new Course("La Classique", TypeTerrain.Asphalte, 15),
//                 new Course("La Gravière", TypeTerrain.Gravier, 20),
//                 new Course("Sentier Sauvage", TypeTerrain.Sentier, 10)
//             };

//             Velo choixVelo = null;
//             bool quitteJeu = false;

//             Console.Clear();
//             Console.WriteLine($"Bienvenue dans RPG-bike ! Vous commencez avec {credit} crédits.");
//             Console.WriteLine();

//             while (!quitteJeu)
//             {
//                 Console.WriteLine("=== RPG-bike ===");
//                 Console.WriteLine("1 - Choisir un vélo");
//                 Console.WriteLine("2 - Choisir une course");
//                 Console.WriteLine("3 - Quitter");
//                 Console.Write("Que voulez-vous faire ? : ");
//                 string choix = Console.ReadLine();

//                 switch (choix)
//                 {
//                     case "1":
//                         Console.WriteLine("Choix du vélo :");
//                         for (int i = 0; i < velos.Length; i++)
//                         {
//                             velos[i].AfficherInfo();
//                             Console.WriteLine();
//                         }
//                         Console.Write("Numéro du vélo : ");
//                         if (int.TryParse(Console.ReadLine(), out int numVelo) && numVelo >= 1 && numVelo <= velos.Length)
//                         {
//                             Velo veloChoisi = velos[numVelo - 1];
//                             if (credit >= veloChoisi.Cout)
//                             {
//                                 choixVelo = veloChoisi;
//                                 credit -= veloChoisi.Cout;
//                                 Console.WriteLine($"Vous avez choisi le vélo {choixVelo.Nom}. Il vous coûte {choixVelo.Cout} crédits.");
//                                 Console.WriteLine($"Il vous reste {credit} crédits.");
//                                 Console.WriteLine("Choisissez maintenant une course (ou faites R pour une course aléatoire).");
//                             }
//                             else
//                             {
//                                 Console.WriteLine("Vous n'avez pas assez de crédits pour ce vélo.");
//                             }
//                         }
//                         else
//                         {
//                             Console.WriteLine("Choix invalide.");
//                         }
//                         break;

//                     case "2":
//                         if (choixVelo == null)
//                         {
//                             Console.WriteLine("Vous devez d'abord choisir un vélo !");
//                             break;
//                         }
//                         Console.WriteLine("Choix de la course :");
//                         for (int i = 0; i < courses.Length; i++)
//                         {
//                             Console.WriteLine($"{i + 1} - {courses[i].Nom} ({courses[i].Terrain}, {courses[i].Distance} km)");
//                         }
//                         Console.Write("Numéro de la course (ou R pour un choix aléatoire): ");
//                         string inputCourse = Console.ReadLine();
//                         Course courseChoisie = null;
//                         if (inputCourse.ToUpper() == "R")
//                         {
//                             Random rnd = new();
//                             courseChoisie = courses[rnd.Next(courses.Length)];
//                             Console.WriteLine($"Course aléatoire choisie : {courseChoisie.Nom}");
//                         }
//                         else if (int.TryParse(inputCourse, out int numCourse) && numCourse >= 1 && numCourse <= courses.Length)
//                         {
//                             courseChoisie = courses[numCourse - 1];
//                             Console.WriteLine($"Course choisie : {courseChoisie.Nom}");
//                         }
//                         else
//                         {
//                             Console.WriteLine("Choix invalide.");
//                             break;
//                         }
//                         courseChoisie.SimulerCourse(choixVelo, ref credit);
//                         break;

//                     case "3":
//                         quitteJeu = true;
//                         Console.WriteLine("Merci d'avoir joué. À bientôt !");
//                         break;

//                     default:
//                         Console.WriteLine("Choix invalide.");
//                         break;
//                 }

//                 Console.WriteLine();
//             }
//         }
//     }
// }


using System;
using System.Collections.Generic;
using RPGBike.Models;
using RPGBike.Services;

namespace RPGBike
{
    class Program
    {
        static void Main(string[] args)
        {
            int credit = 20;
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
            Console.WriteLine($"Bienvenue dans RPG-bike ! Vous commencez avec {credit} crédits.\n");

            while (!quitteJeu)
            {
                Console.WriteLine("=== RPG-bike ===");
                Console.WriteLine("1 - Choisir un vélo");
                Console.WriteLine("2 - Boutique");
                Console.WriteLine("3 - Choisir une course");
                Console.WriteLine("4 - Quitter");
                Console.Write("Que voulez-vous faire ? : ");
                string choix = Console.ReadLine();

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
                            Velo veloChoisi = velos[numVelo - 1];
                            if (credit >= veloChoisi.Cout)
                            {
                                choixVelo = veloChoisi;
                                credit -= veloChoisi.Cout;
                                Console.WriteLine($"Vous avez choisi le vélo {choixVelo.Nom}. Il vous coûte {choixVelo.Cout} crédits.");
                                Console.WriteLine($"Il vous reste {credit} crédits.");
                                Console.WriteLine("Choisissez maintenant une course (ou faites R pour une course aléatoire).");
                            }
                            else
                            {
                                Console.WriteLine("Vous n'avez pas assez de crédits pour ce vélo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Choix invalide.");
                        }
                        break;

                    case "2":
                        boutique.AfficherBoutique();
                        Console.WriteLine($"Vous avez {credit} crédits.");
                        Console.Write("Entrez le nom du produit à acheter ou Q pour quitter la boutique : ");
                        string achat = Console.ReadLine();
                        if (achat.ToUpper() == "Q") break;

                        var accessoire = boutique.Accessoires.Find(a => a.Nom.Equals(achat, StringComparison.OrdinalIgnoreCase));
                        if (accessoire == null)
                        {
                            Console.WriteLine("Produit inconnu.");
                        }
                        else if (credit < accessoire.Cout)
                        {
                            Console.WriteLine("Crédits insuffisants.");
                        }
                        else if (choixVelo == null)
                        {
                            Console.WriteLine("Vous devez choisir un vélo avant d'acheter des accessoires.");
                        }
                        else
                        {
                            credit -= accessoire.Cout;
                            choixVelo.AjouterAccessoire(accessoire);
                            Console.WriteLine($"Merci pour votre achat. Crédits restants : {credit}");
                        }
                        break;

                    case "3":
                        if (choixVelo == null)
                        {
                            Console.WriteLine("Vous devez d'abord choisir un vélo !");
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
                            Random rnd = new();
                            courseChoisie = courses[rnd.Next(courses.Length)];
                            Console.WriteLine($"Course aléatoire choisie : {courseChoisie.Nom}");
                        }
                        else if (int.TryParse(inputCourse, out int numCourse) && numCourse >= 1 && numCourse <= courses.Length)
                        {
                            courseChoisie = courses[numCourse - 1];
                            Console.WriteLine($"Course choisie : {courseChoisie.Nom}");
                        }
                        else
                        {
                            Console.WriteLine("Choix invalide.");
                            break;
                        }
                        courseChoisie.SimulerCourse(choixVelo, ref credit);
                        break;

                    case "4":
                        quitteJeu = true;
                        Console.WriteLine("Merci d'avoir joué. À bientôt !");
                        break;

                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }

                Console.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey();
                Console.WriteLine();
            }
        }
    }
}

