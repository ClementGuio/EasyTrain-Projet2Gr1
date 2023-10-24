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
        public List<Gestionnaire> GetGestionnaires()
        {
            return this._bddContext.Gestionnaires.ToList();
        }

        public List<Gestionnaire> ObtientTousLesGestionnaires()
        {
            return _bddContext.Gestionnaires.ToList();
        }

        public void DeleteGestionnaire(int id, string prenom, string nom, DateTime dateEmbauche)
        {
            Gestionnaire oldGestionnaire = this._bddContext.Gestionnaires.Find(id);
            if (oldGestionnaire != null)
            {
                oldGestionnaire.Prenom = prenom;
                oldGestionnaire.Nom = nom;
                oldGestionnaire.DateEmbauche = dateEmbauche;
                _bddContext.SaveChanges();
            }
        }

        public void DeleteGestionnaire(int id)
        {
            Gestionnaire oldGestionnaire = this._bddContext.Gestionnaires.Find(id);
            if (oldGestionnaire != null)
            {
                _bddContext.Gestionnaires.Remove(oldGestionnaire);
                _bddContext.SaveChanges();
            }
        }
       
        

    }
}
