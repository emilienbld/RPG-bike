
using RPGBike.Models;

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
