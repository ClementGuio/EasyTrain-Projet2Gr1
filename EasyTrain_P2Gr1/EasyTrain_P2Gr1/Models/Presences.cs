using System;
using System.ComponentModel.DataAnnotations;

namespace EasyTrain_P2Gr1.Models
{
    public class Presences
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "L'heure d'arrivée doit être renseignée.")]
        public DateTime HeureArrivee { get; set; }

        [Required(ErrorMessage = "L'heure de départ doit être renseignée.")]
        public DateTime HeureDepart { get; set; }

        [Required(ErrorMessage = "La date doit être renseignée.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "L'ID du client doit être renseigné.")]
        public int IdClient { get; set; }

    }
}
