using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.Services.Interfaces
{
    public interface IDalSalle : IDisposable
    {
        List<Salle> GetSalles();
        Salle GetSalle(int id);
        Salle GetSalle(string strId);
        int CreateSalle(Salle salle);
        void UpdateSalle(Salle salle);
        void DeleteSalle(int id);
    }
}
