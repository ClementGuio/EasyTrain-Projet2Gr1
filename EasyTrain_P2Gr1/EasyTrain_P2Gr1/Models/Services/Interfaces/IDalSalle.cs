using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.Services.Interfaces
{
    public interface IDalSalle : IDisposable
    {
        List<Salle> GetSalles();
        Salle GetSalle(int id);
        int CreateSalle(Salle salle);
        void UpdateSalle(Salle salle);
        void DeleteSalle(int id);
    }
}
