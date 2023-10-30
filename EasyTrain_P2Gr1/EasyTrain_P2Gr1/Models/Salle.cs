using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTrain_P2Gr1.Models
{
    public class Salle
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de la salle doit être renseigné.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le type de la salle doit être renseigné")]
        public string Type { get; set; } //TODO :  créer un enum pour le type de salle ??
        
        public virtual List<Equipement> Equipements { get; set; }
    }
}
