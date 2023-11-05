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
    //TODO : Créer viewmodel pour modifier (problème de validation)
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
                return View("AfficherProfilClient", client);
            }
            return View("Error");
        }

        [Authorize(Roles = "Gestionnaire")]
        public IActionResult ListeClient() // Le nom de la méthode doit avoir le même nom que la vue
        {
            if (HttpContext.User.IsInRole("Client"))
            {
                ViewData["role"] = "Client";
            }
            else if (HttpContext.User.IsInRole("Coach"))
            {
                ViewData["role"] = "Coach";
            }
            else if (HttpContext.User.IsInRole("Gestionnaire"))
            {
                ViewData["role"] = "Gestionnaire";
            }
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
            Client client = new Client { Abonnement = new Abonnement() , DateNaissance = new DateTime()};
            return View(client);
        }


        [HttpPost]
        public IActionResult CreerClient(Client client) //TODO : Abonnement pour un ancien client qui se réinscrit
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }

            client.DateCreationCompte = DateTime.Now;

            client.Abonnement.DateAbonnement = client.DateCreationCompte;

            using (IDalClient service = new ClientService())
            {

                //bool isReservEquipement = Request.Form["ReservEquipement"] == "true";
                //bool isAccesPiscine = Request.Form["AccesPiscine"] == "true";
                service.CreateClient(client);
                
                


            }
            return View();
        }


        [Authorize(Roles = "Client")]
        [HttpGet]
        public IActionResult ModifierClient()
        {
            string id = HttpContext.User.Identity.Name;

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

        [Authorize(Roles = "Client")]
        [HttpPost]
        public IActionResult ModifierClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }
            using (IDalClient service = new ClientService())
            {
                service.UpdateClient(client);
            }
            return View();
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult GestionnaireModifierClient(int id)
        {
            if (HttpContext.User.IsInRole("Client"))
            {
                ViewData["role"] = "Client";
            }
            else if (HttpContext.User.IsInRole("Coach"))
            {
                ViewData["role"] = "Coach";
            }
            else if (HttpContext.User.IsInRole("Gestionnaire"))
            {
                ViewData["role"] = "Gestionnaire";
            }
            Client client;
            using (IDalClient service = new ClientService())
            {
                client = service.GetClient(id);

            }
            if (client != null)
            {
                return View("ModifierClient",client);
            }


            return View("Error");
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult GestionnaireModifierClient(Client client)
        {
            if (HttpContext.User.IsInRole("Client"))
            {
                ViewData["role"] = "Client";
            }
            else if (HttpContext.User.IsInRole("Coach"))
            {
                ViewData["role"] = "Coach";
            }
            else if (HttpContext.User.IsInRole("Gestionnaire"))
            {
                ViewData["role"] = "Gestionnaire";
            }

            using (IDalClient service = new ClientService())
            {
                service.UpdateClient(client);
            }
            return RedirectToAction("ListeClient");
        }

        [Authorize(Roles = "Client")]
        [HttpGet]
        public IActionResult SupprimerClient()
        {
            string id = HttpContext.User.Identity.Name;

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

        [Authorize(Roles = "Client")]
        [HttpPost]
        public IActionResult SupprimerClient(Client client) //TODO Remplacer par la version soft
        {

            using (IDalClient service = new ClientService())
            {
                service.DeleteClient(client.Id);
            }
            HttpContext.SignOutAsync();//suppression du cookie de l'utilisateur
            return Redirect("/");
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult GestionnaireSupprimerClient(int id)
        {
            if (HttpContext.User.IsInRole("Client"))
            {
                ViewData["role"] = "Client";
            }
            else if (HttpContext.User.IsInRole("Coach"))
            {
                ViewData["role"] = "Coach";
            }
            else if (HttpContext.User.IsInRole("Gestionnaire"))
            {
                ViewData["role"] = "Gestionnaire";
            }
            Client client;
            using (IDalClient service = new ClientService())
            {
                client = service.GetClient(id);
            }
            if (client != null)
            {
                return View("SupprimerClient",client);
            }


            return View("Error");
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult GestionnaireSupprimerClient(Client client) //TODO Remplacer par la version soft
        {
            if (HttpContext.User.IsInRole("Client"))
            {
                ViewData["role"] = "Client";
            }
            else if (HttpContext.User.IsInRole("Coach"))
            {
                ViewData["role"] = "Coach";
            }
            else if (HttpContext.User.IsInRole("Gestionnaire"))
            {
                ViewData["role"] = "Gestionnaire";
            }
            using (IDalClient service = new ClientService())
            {
                service.DeleteClient(client.Id);
            }

            return RedirectToAction("ListeClient");
        }
        public IActionResult SoftSupprimerClient(int clientId)
        {
            using (IDalClient service = new ClientService())
            {
                // Au lieu de supprimer le client, marquez-le comme supprimé en définissant la date de suppression
                Client client = service.GetClient(clientId);
                if (client != null)
                {
                    client.DeletedAt = DateTime.Now;
                    service.UpdateClient(client); // Mettre à jour le client pour enregistrer la date de suppression
                }
            }

            HttpContext.SignOutAsync();
            return Redirect("/");
        }

    }
}
