using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.Services.Interfaces
{
    public interface IDalPresence : IDisposable
    {
        List<Presence> GetPresences();
        List<Presence> GetPresencesClient(int clientId);
        List<Presence> GetPresencesClient(string strClientId);
        Presence GetPresence(int id);
        Presence GetPresence(string StrId);
        int CreatePresence(Presence presence);
        void UpdatePresence(Presence presence);
        void DeletePresence(int id);
    }
}
