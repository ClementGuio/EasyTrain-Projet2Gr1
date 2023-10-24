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


        //---------------------------------------------------- Gestion client -------------------------------------------------------------------

        public int CreateClient(string nom, string prenom, DateTime dateDeNaissance, string adresseMail,
                                  string motDePasse, DateTime dateAbonnement)
        {
            Client client = new Client() { Nom = nom, Prenom = prenom, DateNaissance = dateDeNaissance, AdresseMail = adresseMail,
                MotDePasse = motDePasse, DateCreationCompte = DateTime.Now, DateAbonnement = dateAbonnement };

            this._bddContext.Clients.Add(client);
            this._bddContext.SaveChanges();
            return client.Id;
        }
        public List<Client> GetClients()
        {
            return this._bddContext.Clients.ToList();
        }
        public Client GetClient(int id)
        {
            return this._bddContext.Clients.Find(id);
        }
        public void UpdateClient(int id, string nom, string prenom, DateTime dateDeNaissance, string adresseMail,
                                  string motDePasse, DateTime dateDeCreationDeCompte, DateTime dateAbonnement)
        {
            Client oldClient = this._bddContext.Clients.Find(id);
            if (oldClient != null)
            {
                oldClient.Nom = nom;
                oldClient.Prenom = prenom;
                oldClient.DateNaissance = dateDeNaissance;
                oldClient.AdresseMail = adresseMail;
                oldClient.MotDePasse = motDePasse;
                oldClient.DateCreationCompte = dateDeCreationDeCompte;
                oldClient.DateAbonnement = dateAbonnement;
                _bddContext.SaveChanges();
            }
        }
        public void DeleteClient(int id)
        {
            Client oldClient = this._bddContext.Clients.Find(id);
            if (oldClient != null)
            {
                _bddContext.Clients.Remove(oldClient);
            }
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
