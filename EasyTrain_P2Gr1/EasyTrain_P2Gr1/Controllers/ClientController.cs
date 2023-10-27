using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authentication;

namespace EasyTrain_P2Gr1.Controllers
{
    public class ClientController : Controller
    {
        [Authorize(Roles = "Client")]
        [HttpGet]
        public IActionResult Index()
        {
            Client client;
            using (IDalClient service = new ClientService())
            {
                client = service.GetClient(HttpContext.User.Identity.Name);

            }
            if (client != null)
            {
                return View("AfficherProfilClient",client);
            }
            return View("Error");
        }

        [Authorize(Roles = "Gestionnaire")]
        public IActionResult ListeClient() // Le nom de la méthode doit avoir le même nom que la vue
        {
            List<Client> listeClient;
            using (IDalClient service = new ClientService())
            {
                listeClient = service.GetClients();
            }
            return View(listeClient);
        }

        [HttpGet]
        public IActionResult CreerClient()
        {
            return View();
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

        

        [Authorize(Roles = "Client")]
        [HttpGet]
        public IActionResult ModifierClient(int id)
        {
            if (id != 0)
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

            }
            return View("Error");
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        public IActionResult ModifierClient(Client client)
        {
            using (IDalClient service = new ClientService())
            {
                service.UpdateClient(client);
            }
            return View();
        }

        [Authorize(Roles = "Client")]
        [HttpGet]
        public IActionResult SupprimerClient(int id)
        {
            if (id != 0)
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

            }
            return View("Error");
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        public IActionResult SupprimerClient(Client client)
        {
            
            using (IDalClient service = new ClientService())
            {
                service.DeleteClient(client.Id);
            }
            HttpContext.SignOutAsync();
            return Redirect("/");
        }

       
    }
}
