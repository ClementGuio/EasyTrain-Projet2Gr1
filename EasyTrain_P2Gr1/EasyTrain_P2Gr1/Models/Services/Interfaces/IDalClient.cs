using System.Collections.Generic;
using System;

namespace EasyTrain_P2Gr1.Models.DAL.Interfaces
{
    public interface IDalClient : IDisposable
    {
        List<Client> GetClients();
        Client GetClient(int Id);
        Client GetClient(string strId);
        int CreateClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);
        void SoftSupprimerClient(int v);
    }
}
