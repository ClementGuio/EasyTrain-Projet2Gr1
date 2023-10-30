using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.Services.Interfaces
{
    public interface IDalPresence : IDisposable
    {
        List<Presence> GetPresences(int id);
        Presence GetPresence(int id);
        Presence GetPresences(string StrId);
        int CreatPresence(Presence presences);
        void UpdatePresence(Presence presences);
        void DeletePresence(int id);
        void CreatePresences(Presence presences);
        List<Presence> GetPresences();
    }
}
