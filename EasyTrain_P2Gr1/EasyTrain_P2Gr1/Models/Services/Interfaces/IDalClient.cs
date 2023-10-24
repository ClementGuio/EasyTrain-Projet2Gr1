using System.Collections.Generic;
using System;

namespace EasyTrain_P2Gr1.Models.DAL.Interfaces
{
    public interface IDalClient : IDisposable
    {
        List<Client> GetClients();
        Client GetClient(int Id);
        int CreateClient(string nom, string prenom, DateTime dateDeNaissance, string adresseMail,
                               string motDePasse, DateTime dateAbonnement);
        void UpdateClient(int id, string nom, string prenom, DateTime dateDeNaissance, string adresseMail,
                                  string motDePasse, DateTime dateCreationDeCompte, DateTime dateAbonnement);
        void DeleteClient(int id);
    }
}
