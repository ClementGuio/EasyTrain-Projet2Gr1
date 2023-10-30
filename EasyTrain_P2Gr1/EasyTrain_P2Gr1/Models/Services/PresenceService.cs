using EasyTrain_P2Gr1.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class PresenceService : DisposableService, IDalPresence
    {
        

        public List<Presence> GetPresences()
        {
            return this._bddContext.Presences.Include(p => p.Client).ToList();
        }

        public Presence GetPresence(int id)
        {
            return _bddContext.Presences.Include(p => p.Client).FirstOrDefault(p => p.Id == id);
        }

        public void CreatPresence(Presence presence)
        {
            _bddContext.Presences.Add(presence);
            _bddContext.SaveChanges();
        }

        public void UpdatePresence(Presence presence)
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

        public Presence GetPresences(string StrId)
        {
            throw new System.NotImplementedException();
        }

        int IDalPresence.CreatPresence(Presence presences)
        {
            throw new System.NotImplementedException();
        }

        public List<Presence> GetPresences(int id)
        {
            throw new System.NotImplementedException();
        }

        public void CreatePresences(Presence presences)
        {
            throw new System.NotImplementedException();
        }
    }
}
