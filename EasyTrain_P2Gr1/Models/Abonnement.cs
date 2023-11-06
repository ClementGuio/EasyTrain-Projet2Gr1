using Dynamitey.DynamicObjects;
using EasyTrain_P2Gr1.Models.Constantes;
using EasyTrain_P2Gr1.Models.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTrain_P2Gr1.Models
{
    public class Abonnement
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nombre de cours mensuels")]
        public int NbCours { get; set; }
        [Display(Name = "Accès illimité à la piscine")]
        public bool AccesPiscine { get; set; }
        [Display(Name = "Accès illimité au mur d'escalade")]
        public bool AccesEscalade { get; set; }
        [Display(Name = "Coaching 2x par mois")]
        public bool AccompagnementCoach { get; set; }
        [Display(Name = "Prix mensuel")]
        [NotMapped]
        public double Mensualite { get; set; }
        public DateTime DateAbonnement { get; set; }
        

        public void CalculerMensualite()
        {
            this.Mensualite = TarifsAbonnement.TarifBase;
            this.Mensualite += this.NbCours * TarifsAbonnement.TarifCours;
            this.Mensualite += this.AccesPiscine ? TarifsAbonnement.TarifPiscine : 0;
            this.Mensualite += this.AccesEscalade ? TarifsAbonnement.TarifEscalade : 0;
            this.Mensualite += this.AccompagnementCoach ? TarifsAbonnement.TarifCoaching : 0;
        }

        public static void CalculerMensualite(Abonnement abonnement)
        {
            abonnement.Mensualite = TarifsAbonnement.TarifBase;
            abonnement.Mensualite += abonnement.NbCours * TarifsAbonnement.TarifCours;
            abonnement.Mensualite += abonnement.AccesPiscine ? TarifsAbonnement.TarifPiscine : 0;
            abonnement.Mensualite += abonnement.AccesEscalade ? TarifsAbonnement.TarifEscalade : 0;
            abonnement.Mensualite += abonnement.AccompagnementCoach ? TarifsAbonnement.TarifCoaching : 0;
            
        }

    }
}
