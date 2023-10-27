using System;

namespace EasyTrain_P2Gr1.Models
{
    public class Client : Utilisateur
    {
        public DateTime DateCreationCompte { get; set; } //TODO : Passer la DateCreationCompte dans Utilisateur
        public DateTime DateAbonnement { get; set; }

        public void ReserverCoursProgramme(CoursProgramme coursProgramme)
        {
            coursProgramme.PlacesLibres--;
        }
        // TODO : Créer et Ajouter Abonnement
        // TODO : AJouter Points
        // TODO : Ajouter Client parrain
        // TODO : Ajouter bool peutParrainer
        // TODO : Ajouter Client parrainé
    }
}
