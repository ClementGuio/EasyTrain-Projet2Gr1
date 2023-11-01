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

        public List<Presence> GetPresencesClient(int clientId)
        {
            return this._bddContext.Presences.Include(p => p.Client).Where(p => p.Client.Id == clientId).ToList();
        }

        public Presence GetPresence(int id)
        {
            return _bddContext.Presences.Include(p => p.Client).FirstOrDefault(p => p.Id == id);
        }

        public Presence GetPresence(string strId)
        {
            if (int.TryParse(strId, out int id))
            {
                return GetPresence(id);
            }
            return null;
        }

        public int CreatePresence(Presence presence)
        {
            _bddContext.Presences.Add(presence);
            _bddContext.SaveChanges();
            return presence.Id;
        }

        public void UpdatePresence(Presence presence)
        {
            _bddContext.Presences.Update(presence);
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
    }
}
