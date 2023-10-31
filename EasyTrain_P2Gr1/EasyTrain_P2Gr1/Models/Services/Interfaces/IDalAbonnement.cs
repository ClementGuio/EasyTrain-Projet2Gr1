using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.Services.Interfaces
{
    public interface IDalAbonnement : IDisposable
    {
        List<Abonnement> GetAbonnements();
        Abonnement GetAbonnement(int id);
        Abonnement GetAbonnement(string StrId);
        int CreateAbonnement(Abonnement Abonnement);
        void UpdateAbonnement(Abonnement Abonnement);
        void DeleteAbonnement(int id);
    }
}
