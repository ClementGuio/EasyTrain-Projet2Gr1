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

        /***************************  GESTION COACH ****************************************/

        //Méthodes spécifiques
        public List<Coach> GetCoachs()
        {
            return this._bddContext.Coachs.ToList();
        }

        public int CreerCoach(DateTime DateEmbauche)
        {
            Coach coach = new Coach() { DateTime = DateEmbauche };
            this._bddContext.Coachs.Add(coach);
            this._bddContext.SaveChanges();
            return coach.Id;
        }

        public Coach GetCoach(int id)
        {
            return this._bddContext.Coachs.Find(id);
        }

        public void UpdateCoach(int id, string nom, string prenom, DateTime dateNaissance, string adressemail, string motDePasse, DateTime dateEmbauche)
        {
            Coach nouveauCoach = this._bddContext.Coachs.Find(id);
            if (nouveauCoach != null)
            {
                nouveauCoach.Nom = nom;
                nouveauCoach.Prenom = prenom;
                nouveauCoach.DateNaissance = dateNaissance;
                nouveauCoach.AdresseMail = adressemail;
                nouveauCoach.MotDePasse = motDePasse;
                nouveauCoach.DateEmbauche = dateEmbauche;
                _bddContext.SaveChanges();
            }
        }

        public void DeleteCoach(int id)
        {
            Coach nouveauCoach = this._bddContext.Coachs.Find(id);
            if (nouveauCoach != null)
            {
                _bddContext.Coachs.Remove(nouveauCoach);
                _bddContext.SaveChanges();
            }
        }
    }
}
