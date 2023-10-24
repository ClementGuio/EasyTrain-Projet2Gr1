using System.Collections.Generic;
using System;
using EasyTrain_P2Gr1.Models.DAL;
using System.Linq;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class ClientService : DisposableService, IDalClient
    {   
        public List<Client> GetClients()
        {
            return this._bddContext.Clients.ToList();
        }

        public Client GetClient(int id)
        {
            return this._bddContext.Clients.Find(id);
        }

        public int CreateClient(string nom, string prenom, DateTime dateDeNaissance, string adresseMail,
                                 string motDePasse, DateTime dateAbonnement)
        {
            Client client = new Client()
            {
                Nom = nom,
                Prenom = prenom,
                DateNaissance = dateDeNaissance,
                AdresseMail = adresseMail,
                MotDePasse = motDePasse,
                DateCreationCompte = DateTime.Now,
                DateAbonnement = dateAbonnement
            };
            this._bddContext.Clients.Add(client);
            this._bddContext.SaveChanges();
            return client.Id;
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
                _bddContext.SaveChanges();
            }
        }
    }
}
