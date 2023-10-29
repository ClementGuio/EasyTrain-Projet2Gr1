using System.ComponentModel.DataAnnotations;

namespace EasyTrain_P2Gr1.Models
{
    public class Cours
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Le titre doit être renseigné.")]
        public string Titre { get; set; }

        [Required(ErrorMessage = "Le nombre de participants doit être renseigné.")]
        public int NbParticipants { get; set; }

        [Required(ErrorMessage = "Le prix doit être renseigné.")]
        public double Prix { get; set; }

        [Required(ErrorMessage = "Un coach doit être sélectionné.")]
        public virtual Coach Coach { get; set; }

        [Required(ErrorMessage = "Une salle doit être sélectionnée.")]
        public virtual Salle Salle { get; set; }

    }
}
