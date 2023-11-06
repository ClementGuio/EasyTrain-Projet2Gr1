using System.Collections.Generic;
using System;
using EasyTrain_P2Gr1.Models.DAL;
using System.Linq;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class ClientService : DisposableService, IDalClient
    {   
        public List<Client> GetClients()
        {
            return this._bddContext.Clients.Include(c => c.Abonnement).ToList();
        }

        public Client GetClient(int id)
        {
            return this._bddContext.Clients.Include(c => c.Abonnement).FirstOrDefault(c => c.Id == id);
        }

        public Client GetClient(string strId)
        {
            int id;
            if (int.TryParse(strId, out id))
            {
                return GetClient(id);
            }
            return null;
        }

        public int CreateClient(Client client)
        {
            client.MotDePasse = UtilisateurService.EncodeMD5(client.MotDePasse);
            this._bddContext.Clients.Add(client);
            this._bddContext.SaveChanges();
            return client.Id;
        }
        
        public void UpdateClient(Client client)
        {
            //this._bddContext.Attach(client.Abonnement);
            this._bddContext.Clients.Update(client);
            this._bddContext.SaveChanges();
        }

        public void DeleteClient(int id)
        {
            Client client = this._bddContext.Clients.Find(id);
            if (client != null)
            {
                _bddContext.Clients.Remove(client);
                _bddContext.SaveChanges();
            }
        }

     
    }
}
