// using System;

// public class Velo
// {
//     public string Nom { get; set; }
//     public int Vitesse { get; set; }
//     public int Confort { get; set; }
//     public int Resistance { get; set; }
//     public int Cout { get; set; }

//     public Velo(string nom, int vitesse, int confort, int resistance, int cout)
//     {
//         Nom = nom;
//         Vitesse = vitesse;
//         Confort = confort;
//         Resistance = resistance;
//         Cout = cout;
//     }

//     public virtual void AfficherInfo()
//     {
//         Console.WriteLine($"Type : {Nom}");
//         Console.WriteLine($"Vitesse : {Vitesse}");
//         Console.WriteLine($"Confort : {Confort}");
//         Console.WriteLine($"Résistance : {Resistance}");
//         Console.WriteLine($"Coût : {Cout} crédits");
//     }
// }

// public class VeloRoute : Velo
// {
//     public VeloRoute() : base("Route", 10, 5, 6, 15) { }
// }

// public class VeloGravel : Velo
// {
//     public VeloGravel() : base("Gravel", 8, 8, 7, 12) { }
// }

// public class VTT : Velo
// {
//     public VTT() : base("VTT", 7, 9, 10, 10) { }
// }

// public enum TypeTerrain
// {
//     Asphalte,
//     Gravier,
//     Sentier
// }

// public class Course
// {
//     public string Nom { get; set; }
//     public TypeTerrain Terrain { get; set; }
//     public int Distance { get; set; }
//     private Random random = new Random();

//     public Course(string nom, TypeTerrain terrain, int distance)
//     {
//         Nom = nom;
//         Terrain = terrain;
//         Distance = distance;
//     }

//     public int SimulerCourse(Velo velo, ref int credit)
//     {
//         Console.WriteLine($"Début de la course {Nom} sur terrain {Terrain}, distance {Distance}km.");
//         int vitesseEffective = velo.Vitesse;

//         switch (Terrain)
//         {
//             case TypeTerrain.Asphalte:
//                 if (velo is VeloGravel || velo is VTT)
//                     vitesseEffective -= 2;
//                 break;
//             case TypeTerrain.Gravier:
//                 if (velo is VeloRoute)
//                     vitesseEffective -= 3;
//                 break;
//             case TypeTerrain.Sentier:
//                 if (velo is VeloRoute || velo is VeloGravel)
//                     vitesseEffective -= 4;
//                 break;
//         }

//         Console.WriteLine($"Vitesse moyenne en fonction du terrain: {vitesseEffective} km/h");

//         int eventChance = random.Next(100);
//         bool crevaison = false;
//         bool collation = false;

//         if (eventChance < 10)
//         {
//             crevaison = true;
//             Console.WriteLine("Vous avez crevé !");
//             Console.WriteLine("Dépensez 5 crédits pour changer rapidement le pneu, sinon le temps sera augmenté.");
//             if (credit >= 5)
//             {
//                 credit -= 5;
//                 Console.WriteLine("Crédits dépensés, vous repartez rapidement !");
//             }
//             else
//             {
//                 Console.WriteLine("Pas assez de crédits, le temps va augmenter de 15 minutes...");
//                 vitesseEffective -= 3;
//             }
//         }
//         else if (eventChance < 20)
//         {
//             collation = true;
//             Console.WriteLine("Vos supporters vous ont donné une collation, vous avez fait le plein d'énergie !");
//             vitesseEffective += 2;
//         }
//         else
//         {
//             Console.WriteLine("La course est très calme, vous n'avez pas beaucoup de supporters.");
//         }

//         double tempsHeures = (double)Distance / vitesseEffective;
//         int tempsMinutes = (int)(tempsHeures * 60);

//         Console.WriteLine($"Temps estimé : {tempsMinutes} minutes.");

//         int creditsGagnes = Distance + (collation ? 5 : 0) - (crevaison && credit < 5 ? 5 : 0);
//         credit += creditsGagnes;

//         Console.WriteLine($"Vous avez donc mis {tempsMinutes} minutes pour finir la course {Nom}.");
//         Console.WriteLine($"Cela vous fait un total de {credit} crédits.");

//         return tempsMinutes;
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         int credit = 20; // Crédit initial
//         Velo[] velos = { new VeloRoute(), new VeloGravel(), new VTT() };

//         Course[] courses = {
//             new Course("La Classique", TypeTerrain.Asphalte, 15),
//             new Course("La Gravière", TypeTerrain.Gravier, 20),
//             new Course("Sentier Sauvage", TypeTerrain.Sentier, 10)
//         };

//         Velo choixVelo = null;
//         bool quitteJeu = false;
            
//         Console.Clear();
//         Console.WriteLine($"Bienvenue dans RPG-bike ! Vous commencez avec {credit} crédits.");
//         Console.WriteLine();

//         while (!quitteJeu)
//         {
//             Console.WriteLine("=== RPG-bike ===");
//             Console.WriteLine("1 - Choisir un vélo");
//             Console.WriteLine("2 - Choisir une course");
//             Console.WriteLine("3 - Quitter");
//             Console.Write("Que voulez-vous faire ? : ");
//             string choix = Console.ReadLine();

//             switch (choix)
//             {
//                 case "1":
//                     Console.WriteLine("Choix du vélo :");
//                     for (int i = 0; i < velos.Length; i++)
//                     {
//                         velos[i].AfficherInfo();
//                         Console.WriteLine();
//                     }
//                     Console.Write("Numéro du vélo : ");
//                     if (int.TryParse(Console.ReadLine(), out int numVelo) && numVelo >= 1 && numVelo <= velos.Length)
//                     {
//                         Velo veloChoisi = velos[numVelo - 1];
//                         if (credit >= veloChoisi.Cout)
//                         {
//                             choixVelo = veloChoisi;
//                             credit -= veloChoisi.Cout;
//                             Console.WriteLine($"Vous avez choisi le vélo {choixVelo.Nom}. Il vous coûte {choixVelo.Cout} crédits.");
//                             Console.WriteLine($"Il vous reste {credit} crédits.");
//                             Console.WriteLine("Choisissez maintenant une course (ou faites R pour une course aléatoire).");
//                         }
//                         else
//                         {
//                             Console.WriteLine("Vous n'avez pas assez de crédits pour ce vélo.");
//                         }
//                     }
//                     else
//                     {
//                         Console.WriteLine("Choix invalide.");
//                     }
//                     break;

//                 case "2":
//                     if (choixVelo == null)
//                     {
//                         Console.WriteLine("Vous devez d'abord choisir un vélo !");
//                         break;
//                     }
//                     Console.WriteLine("Choix de la course :");
//                     for (int i = 0; i < courses.Length; i++)
//                     {
//                         Console.WriteLine($"{i + 1} - {courses[i].Nom} ({courses[i].Terrain}, {courses[i].Distance} km)");
//                     }
//                     Console.Write("Numéro de la course (ou R pour un choix aléatoire): ");
//                     string inputCourse = Console.ReadLine();
//                     Course courseChoisie = null;
//                     if (inputCourse.ToUpper() == "R")
//                     {
//                         Random rnd = new Random();
//                         courseChoisie = courses[rnd.Next(courses.Length)];
//                         Console.WriteLine($"Course aléatoire choisie : {courseChoisie.Nom}");
//                     }
//                     else if (int.TryParse(inputCourse, out int numCourse) && numCourse >= 1 && numCourse <= courses.Length)
//                     {
//                         courseChoisie = courses[numCourse - 1];
//                         Console.WriteLine($"Course choisi : {courseChoisie.Nom}");
//                     }
//                     else
//                     {
//                         Console.WriteLine("Choix invalide.");
//                         break;
//                     }
//                     courseChoisie.SimulerCourse(choixVelo, ref credit);
//                     break;

//                 case "3":
//                     quitteJeu = true;
//                     Console.WriteLine("Merci d'avoir joué. À bientôt !");
//                     break;

//                 default:
//                     Console.WriteLine("Choix invalide.");
//                     break;
//             }

//             Console.WriteLine("Appuyez sur une touche pour continuer...");
//             Console.ReadKey();
//             Console.WriteLine();
//         }
//     }
// }


using System;
using RPGBike.Models;

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

            Velo choixVelo = null;
            bool quitteJeu = false;

            Console.Clear();
            Console.WriteLine($"Bienvenue dans RPG-bike ! Vous commencez avec {credit} crédits.");
            Console.WriteLine();

            while (!quitteJeu)
            {
                Console.WriteLine("=== RPG-bike ===");
                Console.WriteLine("1 - Choisir un vélo");
                Console.WriteLine("2 - Choisir une course");
                Console.WriteLine("3 - Quitter");
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

                    case "3":
                        quitteJeu = true;
                        Console.WriteLine("Merci d'avoir joué. À bientôt !");
                        break;

                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
