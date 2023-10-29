﻿using System;

namespace EasyTrain_P2Gr1.Models
{
    public class Client : Utilisateur
    {
        public DateTime DateAbonnement { get; set; }
        // TODO : Créer et Ajouter Abonnement
        // TODO : AJouter Points
        // TODO : Ajouter Client parrain
        // TODO : Ajouter bool peutParrainer
        // TODO : Ajouter Client parrainé

        public void ReserverCoursProgramme(CoursProgramme coursProgramme)
        {
            coursProgramme.PlacesLibres--;
        }
    }
}
