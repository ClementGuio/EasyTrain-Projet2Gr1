using Dynamitey;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace EasyTrain_P2Gr1.Models
{
    public class Client : Utilisateur
    {
        public DateTime DateAbonnement { get; set; }
        public virtual Abonnement Abonnement { get; set; }
        public virtual List<Presence> Presences { get; set; }
        // TODO : AJouter Points

        // TODO : Ajouter Client parrain
        // TODO : Ajouter bool peutParrainer
        // TODO : Ajouter Client parrainé

        public bool ReserverCoursProgramme(CoursProgramme coursProgramme)
        {
            if (coursProgramme.PlacesLibres > 0)
            {
                coursProgramme.PlacesLibres--;
                return true;
            }
            return false;
        }
        
    }
}
