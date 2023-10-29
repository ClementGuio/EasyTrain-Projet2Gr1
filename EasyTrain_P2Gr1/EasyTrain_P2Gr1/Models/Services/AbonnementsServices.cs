using EasyTrain_P2Gr1.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class AbonnementsService : DisposableService, IDalAbonnement
    {
        public List<Abonnement> GetAbonnements()
        {
            return this._bddContext.Abonnement.ToList();
        }


        public Abonnement GetAbonnement(int id)
        {
            return this._bddContext.Abonnement.Find(id);
        }

        public Abonnement GetAbonnement(string strId)
        {
            int id; 
            if (int.TryParse(strId,out id))
            {
                return GetAbonnement(id);
            }
            return null;
        }

        public int CreateAbonnement(Abonnement Abonnement)
        {

            this._bddContext.Abonnement.Add(Abonnement);
            this._bddContext.SaveChanges();
            return Abonnement.Id;
        }

        public void UpdateAbonnement(Abonnement Abonnement)
        {
            _bddContext.Abonnement.Update(Abonnement);
            _bddContext.SaveChanges();
        }

        public void DeleteAbonnement(int id)
        {
            Abonnement nouveauAbonnements = this._bddContext.Abonnement.Find(id);
            if (nouveauAbonnements != null)
            {
                _bddContext.Abonnement.Remove(nouveauAbonnements);
                _bddContext.SaveChanges();
            }
        }

        public bool AbonnementExiste(string nomAbonnement)
        {
            List<Abonnement> abonnements = GetAbonnements();
            return abonnements.Any(ab => ab.Titre == nomAbonnement);
        }
    }
}
