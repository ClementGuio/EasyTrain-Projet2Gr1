using System.Collections.Generic;
using System;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using System.Linq;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class CoachService : DisposableService, IDalCoach
    {
        public List<Coach> GetCoachs()
        {
            return this._bddContext.Coachs.ToList();
        }
        public Coach GetCoach(int id)
        {
            return this._bddContext.Coachs.Find(id);
        }

        public int CreerCoach(string nom, string prenom, DateTime dateNaissance, string adressemail,
            string motDePasse, DateTime dateEmbauche)
        {
            Coach coach = new Coach()
            {
                Nom = nom,
                Prenom = prenom,
                DateNaissance = dateNaissance,
                AdresseMail = adressemail,
                MotDePasse = motDePasse,
                DateEmbauche = dateEmbauche
            };
            this._bddContext.Coachs.Add(coach);
            this._bddContext.SaveChanges();
            return coach.Id;
        }


        public void UpdateCoach(int id, string nom, string prenom, DateTime dateNaissance,
            string adressemail, string motDePasse, DateTime dateEmbauche)
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
                this._bddContext.SaveChanges();
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
