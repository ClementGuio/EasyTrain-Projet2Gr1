using System.Collections.Generic;
using System;

namespace EasyTrain_P2Gr1.Models.DAL.Interfaces
{
    public interface IDalGestionnaire : IDisposable
    {
        List<Gestionnaire> GetGestionnaires();
        Gestionnaire GetGestionnaire(int id);
        int CreateGestionnaire(Gestionnaire gestionnaire);
        void UpdateGestionnaire(Gestionnaire gestionnaire);
        void DeleteGestionnaire(int id);
    }
}
