using System;

namespace EasyTrain_P2Gr1.Models
{
    public abstract class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string AdresseMail { get; set; }
        public string MotDePasse { get; set; }
    }
}
