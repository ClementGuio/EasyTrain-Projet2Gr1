using EasyTrain_P2Gr1.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class PresencesService : DisposableService, IDalPresences
    {
        

        public List<Presences> GetPresences()
        {
            return this._bddContext.Presences.ToList();
        }

        public Presences GetPresence(int id)
        {
            return _bddContext.Presences.FirstOrDefault(p => p.Id == id);
        }

        public void CreatPresence(Presences presence)
        {
            _bddContext.Presences.Add(presence);
            _bddContext.SaveChanges();
        }

        public void UpdatePresence(Presences presence)
        {
            _bddContext.Entry(presence).State = EntityState.Modified;
            _bddContext.SaveChanges();
        }

        public void DeletePresence(int id)
        {
            var presence = _bddContext.Presences.FirstOrDefault(p => p.Id == id);
            if (presence != null)
            {
                _bddContext.Presences.Remove(presence);
                _bddContext.SaveChanges();
            }
        }

        public Presences GetPresences(string StrId)
        {
            throw new System.NotImplementedException();
        }

        int IDalPresences.CreatPresence(Presences presences)
        {
            throw new System.NotImplementedException();
        }

        public List<Presences> GetPresences(int id)
        {
            throw new System.NotImplementedException();
        }

        public void CreatePresences(Presences presences)
        {
            throw new System.NotImplementedException();
        }
    }
}
