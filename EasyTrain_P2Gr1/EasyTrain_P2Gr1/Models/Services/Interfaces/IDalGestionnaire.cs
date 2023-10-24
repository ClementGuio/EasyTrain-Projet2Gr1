using System.Collections.Generic;
using System;

namespace EasyTrain_P2Gr1.Models.DAL.Interfaces
{
    public interface IDalGestionnaire : IDisposable
    {
        List<Gestionnaire> GetGestionnaires();
        Gestionnaire GetGestionnaire(int id);
        int CreerGestionnaire(string nom, string prenom, DateTime dateNaissance, string adresseMail, string motDePasse,
                              DateTime dateEmbauche);
        void UpdateGestionnaire(int id, string nom, string prenom, DateTime dateNaissance, string adresseMail, string motDePasse,
                                DateTime dateEmbauche);
        void DeleteGestionnaire(int id);
    }
}
