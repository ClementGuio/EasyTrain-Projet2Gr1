using EasyTrain_P2Gr1.Models.CustomValidations;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyTrain_P2Gr1.Models
{
    public abstract class Utilisateur
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom doit être renseigné.")]
        [MaxLength(30, ErrorMessage = "Le nom ne doit pas excéder 30 caractères")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Le nom ne doit contenir que des lettres")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom doit être renseigné.")]
        [MaxLength(30, ErrorMessage = "Le prénom ne doit pas excéder 30 caractères")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Le prénom ne doit contenir que des lettres")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "La date de naissance doit être renseignée.")]
        [DateNaissance(ErrorMessage = "Vous devez être majeur pour pouvoir vous inscrire")]
        public DateTime DateNaissance { get; set; }

        [Required(ErrorMessage = "L'adresse mail doit être renseignée.")]
        [EmailAddress(ErrorMessage = "Le format de votre adresse mail n'est pas valide.")]
        [NouvelleAdresseMail(ErrorMessage = "Cette adresse mail est déjà utilisé")]
        public string AdresseMail { get; set; }

        [Required(ErrorMessage = "Le mot de passe doit être renseigné.")]
        [RegularExpression("^(?=.{8,}$)(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*\\W).*$", ErrorMessage = "Le mot de passe doit avoir au moins 8 caractères et contenir 1 minuscule, 1 majuscule et 1 chiffre.")]
        public string MotDePasse { get; set; }

        //[Required(ErrorMessage = "La vérification du mot de passe doit être renseignée.")]
        [Compare("MotDePasse", ErrorMessage = "Les mots de passe ne correspondent pas.")] // Permet de comparrer les deux champs et retourne un d'erreur
        public string VerifMotDePasse { get; set; }

        public DateTime DateCreationCompte { get; set; }

        public DateTime? DeletedAt { get; set; } // Permet de désactiver le compte sans le supprimer -> Si DeletedAt est null le compte est actif, sinon le compte a été supprimé (désactivé)
    }
}
