using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace EasyTrain_P2Gr1.Controllers
{
    public class UtilisateurController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListeClient() // Le nom de la méthode doit avoir le même nom que la vue
        {
            List<Client> listeClient;
            using (IDalClient service = new ClientService())
            {
                listeClient = service.GetClients();
            }
            return View(listeClient);
        }

        public IActionResult AfficherProfilClient(int id)
        {
            Client client;
            using (IDalClient service = new ClientService())
            {
                client = service.GetClient(id);

            }
            if (client != null)
            {
                return View(client);
            }
            return View("Error");
        }
        [HttpGet]
        public IActionResult CreerClient() 
        {
            return  View();
        }
        
        [HttpPost]
        public IActionResult CreerClient(Client client)
        {
            client.DateCreationCompte = DateTime.Now;
            client.DateAbonnement = DateTime.Now;
            using (IDalClient service = new ClientService())
            {
                service.CreateClient(client);
            }
            return View();
        }
        [HttpGet]
        public IActionResult ModifierClient(int id) 
        { 

            if(id != 0)
            {
                Client client;
                using(IDalClient service = new ClientService())
                {
                    client = service.GetClient(id);

                }
              if (client != null)
                {
                    return View(client);
                }
              
            }
            return View("Error") ;
        }
        [HttpPost]
        public IActionResult ModifierClient(Client client)
        {
            using(IDalClient service = new ClientService())
            {
                service.UpdateClient(client);    
            }
            return View();
        }

        [HttpGet]
        public IActionResult SupprimerClient(int id)
        {
            if(id != 0)
            {
                Client client;
                using(IDalClient service = new ClientService())
                {
                    client = service.GetClient(id);
                }
               if(client != null)
                {
                    return View(client);
                }
                
            }
            return View("Error");
        }
        [HttpPost]
        public IActionResult SupprimerClient(Client client)
        {
            using( IDalClient service = new ClientService())
            {
                service.DeleteClient(client.Id);
            }
            return View();     
        }
    
    }
}
