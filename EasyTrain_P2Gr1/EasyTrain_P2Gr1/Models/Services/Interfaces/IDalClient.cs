using System.Collections.Generic;
using System;

namespace EasyTrain_P2Gr1.Models.DAL.Interfaces
{
    public interface IDalClient : IDisposable
    {
        List<Client> GetClients();
        Client GetClient(int Id);
        //TODO: Passer un client
        int CreateClient(string nom, string prenom, DateTime dateDeNaissance, string adresseMail,
                               string motDePasse, DateTime dateAbonnement);
        //TODO: Passer un client
        void UpdateClient(int id, string nom, string prenom, DateTime dateDeNaissance, string adresseMail,
                                  string motDePasse, DateTime dateCreationDeCompte, DateTime dateAbonnement);
        void DeleteClient(int id);
    }
}
