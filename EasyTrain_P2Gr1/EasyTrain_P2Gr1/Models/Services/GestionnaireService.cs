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

        public int CreerGestionnaire(string prenom, string nom, DateTime dateEmbauche)
        {
            Gestionnaire gestionnaire = new Gestionnaire() { Nom = nom, Prenom = prenom, DateEmbauche = dateEmbauche };
            this._bddContext.Gestionnaires.Add(gestionnaire);
            this._bddContext.SaveChanges();
            return gestionnaire.Id;
        }

        public void UpdateGestionnaire(int id, string prenom, string nom, DateTime dateEmbauche)
        {
            Gestionnaire oldGestionnaire = this._bddContext.Gestionnaires.Find(id);
            if (oldGestionnaire != null)
            {
                oldGestionnaire.Prenom = prenom;
                oldGestionnaire.Nom = nom;
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
