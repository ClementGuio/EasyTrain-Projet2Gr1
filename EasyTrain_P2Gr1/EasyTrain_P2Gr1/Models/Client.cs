using Dynamitey;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace EasyTrain_P2Gr1.Models
{
    public class Client : Utilisateur
    {
        public virtual Abonnement Abonnement { get; set; }
        public virtual List<Presence> Presences { get; set; }
        
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
