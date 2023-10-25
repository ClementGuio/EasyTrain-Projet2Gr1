using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models
{
    public class Salle
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Type { get; set; } //TODO :  créer un enum pour le type de salle
        public virtual List<Equipement> Equipements { get; set; }
    }
}
