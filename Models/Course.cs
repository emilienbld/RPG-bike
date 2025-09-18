using System;

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

            Console.WriteLine($"Vitesse moyenne en fonction du terrain: {vitesseEffective} km/h");

            int eventChance = random.Next(100);
            bool crevaison = false;
            bool collation = false;

            if (eventChance < 10)
            {
                crevaison = true;
                Console.WriteLine("Vous avez crevé !");
                Console.WriteLine("Dépensez 5 crédits pour changer rapidement le pneu, sinon le temps sera augmenté.");
                if (credit >= 5)
                {
                    credit -= 5;
                    Console.WriteLine("Crédits dépensés, vous repartez rapidement !");
                }
                else
                {
                    Console.WriteLine("Pas assez de crédits, le temps va augmenter de 15 minutes...");
                    vitesseEffective -= 3;
                }
            }
            else if (eventChance < 20)
            {
                collation = true;
                Console.WriteLine("Vos supporters vous ont donné une collation, vous avez fait le plein d'énergie !");
                vitesseEffective += 2;
            }
            else
            {
                Console.WriteLine("La course est très calme, vous n'avez pas beaucoup de supporters.");
            }

            double tempsHeures = (double)Distance / vitesseEffective;
            int tempsMinutes = (int)(tempsHeures * 60);

            Console.WriteLine($"Temps estimé : {tempsMinutes} minutes.");

            int creditsGagnes = Distance + (collation ? 5 : 0) - (crevaison && credit < 5 ? 5 : 0);
            credit += creditsGagnes;

            Console.WriteLine($"Vous avez donc mis {tempsMinutes} minutes pour finir la course {Nom}.");
            Console.WriteLine($"Cela vous fait un total de {credit} crédits.");

            return tempsMinutes;
        }
    }
}
