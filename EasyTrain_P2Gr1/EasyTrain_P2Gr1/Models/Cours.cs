using System.ComponentModel.DataAnnotations;

namespace EasyTrain_P2Gr1.Models
{
    public class Cours  
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Le titre doit être renseigné.")]
        public string Titre { get; set; }

        [Required(ErrorMessage = "Le nombre de participants doit être renseigné.")]

        [Display(Name = "Nombre de participants")]
        public int NbParticipants { get; set; }

        [Required(ErrorMessage = "La durée du cours doit être renseignée")]
        public int DureeMinutes { get; set; } //TODO: Calculer l'heure de fin du cours en fonction de la durée

        [Required(ErrorMessage = "Le prix doit être renseigné.")]
        public double Prix { get; set; }

        [Required(ErrorMessage = "Un coach doit être sélectionné.")]
        public virtual Coach Coach { get; set; }

        [Required(ErrorMessage = "Une salle doit être sélectionnée.")]
        public virtual Salle Salle { get; set; }

        
        public bool Supprime { get; set; }
        public int CoachId { get; internal set; }
    }
}
