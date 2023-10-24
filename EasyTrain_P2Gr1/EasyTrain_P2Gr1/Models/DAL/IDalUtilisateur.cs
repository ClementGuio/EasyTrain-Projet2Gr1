using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.DAL
{


    public interface IDalUtilisateur : IDisposable
    {

        // ---------------------------------------------- Gestion client

        public int CreateClient(string nom, string prenom, DateTime dateDeNaissance, string adresseMail,
                                string motDePasse, DateTime dateAbonnement);
        List<Client> GetClients();
        public Client GetClient(int Id);
        public void UpdateClient (int id, string nom, string prenom, DateTime dateDeNaissance, string adresseMail, 
                                  string motDePasse, DateTime dateCreationDeCompte , DateTime dateAbonnement);
        public void DeleteClient(int id);

    }



}
