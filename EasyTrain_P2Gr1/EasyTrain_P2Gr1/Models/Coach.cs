using System;

namespace EasyTrain_P2Gr1.Models
{
    public class Coach : Utilisateur
    {
        public DateTime DateEmbauche { get; set; } //TODO : Supprimer DateEmbauche : La date d'embauche est sur le contrat de travail du coach. Pas besoin de l'avoir en Bdd
       
    }
}
