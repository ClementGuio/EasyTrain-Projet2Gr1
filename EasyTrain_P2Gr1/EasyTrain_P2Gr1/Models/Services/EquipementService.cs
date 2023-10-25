using EasyTrain_P2Gr1.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class EquipementService: DisposableService, IDalEquipement

    {
        public List<Equipement> GetEquipements()
        {
            return this._bddContext.Equipements.ToList();
        }

        public Equipement GetEquipement(int id)
        {
            return _bddContext.Equipements.Find(id);
        }
        public int CreateEquipement(Equipement equipement)
        {
            
            this._bddContext.Equipements.Add(equipement);
            this._bddContext.SaveChanges();
            return equipement.Id;

        }

        public void UpdateEquipement(Equipement equipement)
                                      
        {

            _bddContext.Equipements.Update(equipement);
                _bddContext.SaveChanges();
            
        }
        public void DeleteEquipement(int id)
        {
            Equipement oldEquipement = this._bddContext.Equipements.Find(id);
            if (oldEquipement!= null)
            {
                _bddContext.Equipements.Remove(oldEquipement);
                _bddContext.SaveChanges();
            }
        }
    }
}
