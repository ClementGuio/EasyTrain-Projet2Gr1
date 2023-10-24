using System.Collections.Generic;
using System;

namespace EasyTrain_P2Gr1.Models.DAL.Interfaces
{
    public interface IDalGestionnaire : IDisposable
    {
        List<Gestionnaire> GetGestionnaires();
        Gestionnaire GetGestionnaire(int id);
        int CreerGestionnaire(string prenom, string nom, DateTime dateEmbauche);
        void UpdateGestionnaire(int id, string prenom, string nom, DateTime dateEmbauche);
        void DeleteGestionnaire(int id);
    }
}
