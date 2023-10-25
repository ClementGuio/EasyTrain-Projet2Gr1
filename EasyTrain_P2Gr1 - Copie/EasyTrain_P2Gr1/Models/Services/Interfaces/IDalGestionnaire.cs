using System.Collections.Generic;
using System;

namespace EasyTrain_P2Gr1.Models.DAL.Interfaces
{
    public interface IDalGestionnaire : IDisposable
    {
        List<Gestionnaire> GetGestionnaires();
        Gestionnaire GetGestionnaire(int id);
        //TODO: passer un Gestionnaire
        int CreerGestionnaire(string nom, string prenom, DateTime dateNaissance, string adresseMail, string motDePasse,
                              DateTime dateEmbauche);
        //TODO: passer un Gestionnaire
        void UpdateGestionnaire(int id, string nom, string prenom, DateTime dateNaissance, string adresseMail, string motDePasse,
                                DateTime dateEmbauche);
        void DeleteGestionnaire(int id);
    }
}
