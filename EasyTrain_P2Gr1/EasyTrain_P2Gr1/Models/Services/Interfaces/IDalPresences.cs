using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.Services.Interfaces
{
    public interface IDalPresences : IDisposable
    {
        List<Presences> GetPresences(int id);
        Presences GetPresence(int id);
        Presences GetPresences(string StrId);
        int CreatPresence(Presences presences);
        void UpdatePresence(Presences presences);
        void DeletePresence(int id);
        void CreatePresences(Presences presences);
        List<Presences> GetPresences();
    }
}
