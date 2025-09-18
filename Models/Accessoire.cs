namespace RPGBike.Models
{
    public class Accessoire
    {
        public string Nom { get; set; }
        public int Cout { get; set; }
        public string Description { get; set; }
        public ActionEffet Effet { get; set; }

        public Accessoire(string nom, int cout, string description, ActionEffet effet)
        {
            Nom = nom;
            Cout = cout;
            Description = description;
            Effet = effet;
        }
    }

    public enum ActionEffet
    {
        ReduitCrevaison,
        AugmenteConfort,
        BoostCollation,
        FreinDisque,
        CasqueAero,
        FormationPeloton
    }
}
