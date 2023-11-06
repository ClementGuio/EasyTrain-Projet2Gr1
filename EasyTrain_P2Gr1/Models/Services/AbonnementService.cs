using EasyTrain_P2Gr1.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class AbonnementService : DisposableService, IDalAbonnement
    {
        public List<Abonnement> GetAbonnements()
        {
            return this._bddContext.Abonnements.ToList();
        }


        public Abonnement GetAbonnement(int id)
        {
            return this._bddContext.Abonnements
                .FirstOrDefault(a => a.Id == id);
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

        public int CreateAbonnement(Abonnement abonnement)
        {
            this._bddContext.Abonnements.Add(abonnement);
            this._bddContext.SaveChanges();
            return abonnement.Id;
        }

        public void UpdateAbonnement(Abonnement abonnement)
        {
            _bddContext.Abonnements.Update(abonnement);
            _bddContext.SaveChanges();
        }

        public void DeleteAbonnement(int id)
        {
            Abonnement abonnement = this._bddContext.Abonnements.Find(id);
            if (abonnement != null)
            {
                _bddContext.Abonnements.Remove(abonnement);
                _bddContext.SaveChanges();
            }
        }

    }
}
