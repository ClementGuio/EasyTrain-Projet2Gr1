using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.Services.Interfaces
{
    public interface IDalCours : IDisposable
    {
        List<Cours> GetCours();
        Cours GetCours(int id);
        //Cours GetCours(string StrId);
        int CreateCours(Cours cours);
        void UpdateCours(Cours cours);
        void DeleteCours(int id);
    }
}
