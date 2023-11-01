using System;
using System.ComponentModel.DataAnnotations;

namespace EasyTrain_P2Gr1.Models
{
    public class Presence
    {
        public int Id { get; set; }

        public DateTime HeureArrivee { get; set; }

        public DateTime HeureDepart { get; set; }

        public Client Client { get; set; }

    }
}
