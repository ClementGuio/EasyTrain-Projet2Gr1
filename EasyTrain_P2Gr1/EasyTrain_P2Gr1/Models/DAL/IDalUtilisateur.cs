using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.DAL
{
    public interface IDalUtilisateur : IDisposable
    {
        List<Client> GetClients();
        List<Coach> GetCoachs();
    }

    
}
