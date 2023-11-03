

using static System.Net.Mime.MediaTypeNames;

namespace EasyTrain_P2Gr1.Models
{
    public class Equipement
    {

        public int Id { get; set; }
        public string Nom { get; set; }
        public string imageEquipement { get; set; }
        public virtual Salle Salle { get; set; } 
    }
}
