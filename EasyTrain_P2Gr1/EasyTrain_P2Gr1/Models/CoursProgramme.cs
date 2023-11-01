using System;

namespace EasyTrain_P2Gr1.Models
{
    public class CoursProgramme
    {
        public int Id { get; set; }

        public DateTime DateDebut { get; set; }
        
        public DateTime DateFin { get; set; } //TODO : caluler dateFin : DateDebut + cours.duree
        
        public int PlacesLibres { get; set; }
        
        public virtual Cours Cours { get; set; }
    }
}
