using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.DAL
{
    public interface IDalUtilisateur : IDisposable
    {
        List<Client> GetClients();
        List<Gestionnaire> GetGestionnaires();
        public void DeleteGestionnaire(int id, string prenom, string nom, DateTime dateEmbauche);
        List<Gestionnaire> ObtientTousLesGestionnaires();
        public void DeleteGestionnaire(int id);

    }
}
