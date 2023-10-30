using System;
using System.ComponentModel.DataAnnotations;

namespace EasyTrain_P2Gr1.Models
{
    public class Presence
    {
        public int Id { get; set; }

        [Required]
        public DateTime HeureArrivee { get; set; }

        public DateTime HeureDepart { get; set; }

        [Required]
        public Client Client { get; set; }

    }
}
