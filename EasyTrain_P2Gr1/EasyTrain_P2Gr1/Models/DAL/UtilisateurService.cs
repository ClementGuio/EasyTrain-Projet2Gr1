using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTrain_P2Gr1.Models.DAL
{
    public class UtilisateurService : IDalUtilisateur
    {
        //Méthodes communes à toutes les DAL
        private BddContext _bddContext;

        public UtilisateurService()
        {
            this._bddContext = new BddContext();
        }

        public void Dispose()
        {
            this._bddContext.Dispose(); // Dispose permet de nettoyer la connection à la base de données quand vous utilisez using(IDal dal = new Dal());
        }

        //Méthodes spécifiques
        public List<Client> GetClients()
        {
            return this._bddContext.Clients.ToList();
        }

    }
}
