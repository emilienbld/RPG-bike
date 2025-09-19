using System;

namespace RPGBike.Models
{
    public enum ActionEffet
    {
        ReduitCrevaison,
        AugmenteConfort,
        BoostCollation,
        FreinDisque,
        CasqueAero,
        FormationPeloton
    }

    public enum AccessoireType
    {
        Amelioration,
        Consommable
    }

    public class Accessoire
    {
        public string Nom { get; set; }
        public int Cout { get; set; }
        public string Description { get; set; }
        public ActionEffet Effet { get; set; }
        public AccessoireType Type { get; set; }

        public Accessoire(string nom, int cout, string description, ActionEffet effet, AccessoireType type)
        {
            Nom = nom;
            Cout = cout;
            Description = description;
            Effet = effet;
            Type = type;
        }
    }
}

