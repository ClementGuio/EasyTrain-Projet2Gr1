using System.Collections.Generic;
using System;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using System.Linq;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class GestionnaireService : DisposableService, IDalGestionnaire
    {
        public List<Gestionnaire> GetGestionnaires()
        {
            return this._bddContext.Gestionnaires.ToList();
        }

        public Gestionnaire GetGestionnaire(int id)
        {
            return _bddContext.Gestionnaires.Find(id);
        }

        public int CreerGestionnaire(string nom, string prenom, DateTime dateNaissance, string adresseMail, string motDePasse,
                                     DateTime dateEmbauche)
        {
            Gestionnaire gestionnaire = new Gestionnaire() { Nom = nom, Prenom = prenom, DateNaissance=dateNaissance,
                                                             AdresseMail=adresseMail, MotDePasse=motDePasse, DateEmbauche = dateEmbauche };
            this._bddContext.Gestionnaires.Add(gestionnaire);
            this._bddContext.SaveChanges();
            return gestionnaire.Id;
        }

        public void UpdateGestionnaire(int id, string nom, string prenom, DateTime dateNaissance, string adresseMail, string motDePasse,
                                       DateTime dateEmbauche)
        {
            Gestionnaire oldGestionnaire = this._bddContext.Gestionnaires.Find(id);
            if (oldGestionnaire != null)
            {
                oldGestionnaire.Nom = nom;
                oldGestionnaire.Prenom = prenom;
                oldGestionnaire.DateNaissance = dateNaissance;
                oldGestionnaire.AdresseMail = adresseMail;
                oldGestionnaire.MotDePasse = motDePasse;
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
