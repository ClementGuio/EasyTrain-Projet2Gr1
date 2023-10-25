using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class SalleService : DisposableService, IDalSalle
    {
        public List<Salle> GetSalles()
        {
            return this._bddContext.Salles.ToList();
        }

        public Salle GetSalle(int id)
        {
            return this._bddContext.Salles.Find(id);
        }

        public int CreateSalle(Salle salle)
        {
            this._bddContext.Salles.Add(salle);
            this._bddContext.SaveChanges();
            return salle.Id;
        }

        public void UpdateSalle(Salle salle)
        {
                _bddContext.Salles.Update(salle);
                _bddContext.SaveChanges();
            
        }

        public void DeleteSalle(int id)
        {
            Salle oldSalle = this._bddContext.Salles.Find(id);
            if (oldSalle != null)
            {
                _bddContext.Entry(oldSalle).State=EntityState.Deleted;
                _bddContext.SaveChanges();
            }
        }


    }
}
