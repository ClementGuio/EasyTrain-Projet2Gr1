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

        public void DeleteCoach(int id);

        public Coach GetCoach(int Id);
        List<Coach> GetCoachs();
        public int CreerCoach(string nom, string prenom, DateTime dateNaissance, string adressemail,
            string motDePasse, DateTime dateEmbauche);
        public void UpdateCoach(int id, string nom, string prenom, DateTime dateNaissance,
            string adressemail, string motDePasse, DateTime dateEmbauche);




        public Client GetClient(int Id);
        public void UpdateClient(int id, string nom, string prenom, DateTime dateDeNaissance, string adresseMail,
                                  string motDePasse, DateTime dateCreationDeCompte, DateTime dateAbonnement);
        public void DeleteClient(int id);

    }

}
