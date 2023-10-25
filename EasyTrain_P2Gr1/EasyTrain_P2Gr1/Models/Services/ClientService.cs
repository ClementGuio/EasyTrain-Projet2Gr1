using System.Collections.Generic;
using System;
using EasyTrain_P2Gr1.Models.DAL;
using System.Linq;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class ClientService : DisposableService, IDalClient
    {   
        public List<Client> GetClients()
        {
            return this._bddContext.Clients.ToList();
        }

        public Client GetClient(int id)
        {
            return this._bddContext.Clients.Find(id);
        }

        public int CreateClient(Client client)
        {
            this._bddContext.Clients.Add(client);
            this._bddContext.SaveChanges();
            return client.Id;
        }
        
        public void UpdateClient(Client client)
        {
            this._bddContext.Clients.Update(client);
            this._bddContext.SaveChanges();
        }

        public void DeleteClient(int id)
        {
            Client oldClient = this._bddContext.Clients.Find(id);
            if (oldClient != null)
            {
                _bddContext.Clients.Remove(oldClient);
                _bddContext.SaveChanges();
            }
        }
    }
}
