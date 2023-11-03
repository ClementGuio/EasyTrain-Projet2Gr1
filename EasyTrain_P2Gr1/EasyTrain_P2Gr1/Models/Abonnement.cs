using System;


namespace EasyTrain_P2Gr1.Models
{
    public class Abonnement
    {
        public int Id { get; set; }
        public int NbCours { get; set; }
        public bool AccesPiscine { get; set; }
        public bool AccesEscalade { get; set; }
        public bool AccompagenementCoach { get; set; }
        //TODO: rajouter les tarifs des features
        public double Mensualite { get; set; }
        public DateTime DateAbonnement { get; set; }

    }
}
