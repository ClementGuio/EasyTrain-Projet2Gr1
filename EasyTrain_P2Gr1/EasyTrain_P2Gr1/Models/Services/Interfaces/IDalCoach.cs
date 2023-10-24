using System.Collections.Generic;
using System;

namespace EasyTrain_P2Gr1.Models.DAL.Interfaces
{
    public interface IDalCoach : IDisposable
    {
        List<Coach> GetCoachs();
        public Coach GetCoach(int Id);
        public int CreerCoach(string nom, string prenom, DateTime dateNaissance, string adressemail,
            string motDePasse, DateTime dateEmbauche);
        public void UpdateCoach(int id, string nom, string prenom, DateTime dateNaissance,
            string adressemail, string motDePasse, DateTime dateEmbauche);
        public void DeleteCoach(int id);
    }
}
