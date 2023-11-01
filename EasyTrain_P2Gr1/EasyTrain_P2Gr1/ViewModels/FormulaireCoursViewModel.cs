using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyTrain_P2Gr1.ViewModels
{
    public class FormulaireCoursViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre doit être renseigné.")]
        public string Titre { get; set; }

        [Required(ErrorMessage = "Le nombre de participants doit être renseigné.")]
        public int NbParticipants { get; set; }

        [Required(ErrorMessage = "Le prix doit être renseigné.")]
        public double Prix { get; set; }

        [Required(ErrorMessage = "Une salle doit être sélectionnée.")]
        public int SalleId { get; set; }
        
        [Required(ErrorMessage = "Un coach doit être sélectionné.")]
        public int CoachId { get; set; }

        [Required(ErrorMessage = "Une durée doit être sélectionné.")]
        public int DureeMinutes { get; set; }

        [Display(Name = "Coach")]
        public IEnumerable<Coach> Coachs{ get; set; }

        [Display(Name = "Salle")]
        public IEnumerable<Salle> Salles { get; set; }
    }
}
