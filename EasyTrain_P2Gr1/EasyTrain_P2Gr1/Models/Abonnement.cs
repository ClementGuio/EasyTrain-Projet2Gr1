using System;

namespace EasyTrain_P2Gr1.Models
{
    public class Abonnement
    {
        public int Id { get; set; }
        public int NbCours { get; set; }
        public bool ReservEquipement { get; set; }
        public bool AccesPiscine { get; set; }
        public double Mensualite { get; set; }

        public DateTime DateAbonnement { get; set; }

    }
}
