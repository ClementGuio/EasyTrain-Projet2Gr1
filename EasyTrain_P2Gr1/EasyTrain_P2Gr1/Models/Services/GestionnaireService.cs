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
        public Gestionnaire GetGestionnaire(string strId)
        {
            int id;
            if (int.TryParse(strId, out id))
            {
                return GetGestionnaire(id);
            }
            return null;
        }

        public int CreateGestionnaire(Gestionnaire gestionnaire)
        {
            gestionnaire.MotDePasse = UtilisateurService.EncodeMD5(gestionnaire.MotDePasse);
            this._bddContext.Gestionnaires.Add(gestionnaire);
            this._bddContext.SaveChanges();
            return gestionnaire.Id;
        }

        public void UpdateGestionnaire(Gestionnaire gestionnaire)
        {
            _bddContext.Gestionnaires.Update(gestionnaire);
            _bddContext.SaveChanges();

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
