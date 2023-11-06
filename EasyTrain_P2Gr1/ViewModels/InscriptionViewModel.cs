using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.CustomValidations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace EasyTrain_P2Gr1.ViewModels
{
    public class InscriptionViewModel
    {
        [Required(ErrorMessage = "Le nom doit être renseigné.")]
        [MaxLength(30, ErrorMessage = "Le nom ne doit pas excéder 30 caractères")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Le nom ne doit contenir que des lettres")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom doit être renseigné.")]
        [MaxLength(30, ErrorMessage = "Le prénom ne doit pas excéder 30 caractères")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Le prénom ne doit contenir que des lettres")]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "La date de naissance doit être renseignée.")]
        [DateNaissance(ErrorMessage = "Vous devez être majeur pour pouvoir vous inscrire")]
        [Display(Name = "Date de naissance")]
        public DateTime DateNaissance { get; set; }

        [Required(ErrorMessage = "L'adresse mail doit être renseignée.")]
        [EmailAddress(ErrorMessage = "Le format de votre adresse mail n'est pas valide.")]
        [NouvelleAdresseMail(ErrorMessage = "Cette adresse mail est déjà utilisé")]
        [Display(Name = "Email")]
        public string AdresseMail { get; set; }

        [Required(ErrorMessage = "Le mot de passe doit être renseigné.")]
        [RegularExpression("^(?=.{8,}$)(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*\\W).*$", ErrorMessage = "Le mot de passe doit avoir au moins 8 caractères et contenir 1 minuscule, 1 majuscule et 1 chiffre.")]
        [Display(Name = " Mot de passe")]
        public string MotDePasse { get; set; }

        //[Required(ErrorMessage = "La vérification du mot de passe doit être renseignée.")]
        [Compare("MotDePasse", ErrorMessage = "Les mots de passe ne correspondent pas.")]// Permet de comparer les deux champs et retourne un message d'erreur
        [Display(Name = " Confirmer le nouveau mot de passe")]
        [NotMapped]
        public string VerifMotDePasse { get; set; }

        [Display(Name = "Date de création de compte ")]
        public DateTime DateCreationCompte { get; set; }

        public int NbCours { get; set; }
        public bool AccesPiscine { get; set; }
        public bool AccesEscalade { get; set; }
        public bool AccompagnementCoach { get; set; }
        //TODO: rajouter les tarifs des features
        public double Mensualite { get; set; }
        public DateTime DateAbonnement { get; set; }

    }
}
