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
            return this._bddContext.Salles.Include(s => s.Equipements).ToList();
        }

        public Salle GetSalle(int id)
        {
            return this._bddContext.Salles.Include(c => c.Equipements).FirstOrDefault(s => s.Id == id);
        }

        public Salle GetSalle(string strId)
        {
            if (int.TryParse(strId, out int id))
            {
                return GetSalle(id);
            }
            return null;
        }

        public int CreateSalle(Salle salle)
        {
            this._bddContext.AttachRange(salle.Equipements);
            this._bddContext.Salles.Add(salle);
            this._bddContext.SaveChanges();
            return salle.Id;
        }

        public void UpdateSalle(Salle salle)
        {
            _bddContext.AttachRange(salle.Equipements);
            Salle salleDb = _bddContext.Salles.Include(c => c.Equipements).FirstOrDefault(s => s.Id == salle.Id);
            salleDb.Nom = salle.Nom;
            salleDb.Type = salle.Type;
            salleDb.Equipements.Clear();
            foreach (Equipement equipement in salle.Equipements)
            {
                salleDb.Equipements.Add(equipement);
            }
            _bddContext.SaveChanges();
        }

        public void DeleteSalle(int id)
        {
            Salle salle = this._bddContext.Salles.Include(s => s.Equipements).FirstOrDefault(s => s.Id == id);
            if (salle != null)
            {
                _bddContext.Remove(salle);
                _bddContext.SaveChanges();
            }
        }
    }
}
