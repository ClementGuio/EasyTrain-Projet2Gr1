﻿using EasyTrain_P2Gr1.Models.DAL.Interfaces;
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
            if (!ModelState.IsValid)
            {
                return View(client);
            }
            client.Abonnement = new Abonnement();

            client.DateCreationCompte = DateTime.Now;
            client.DateAbonnement = DateTime.Now;
            bool isReservEquipement = Request.Form["ReservEquipement"] == "true";
            bool isAccesPiscine = Request.Form["AccesPiscine"] == "true";

            client.Abonnement.ReservEquipement = isReservEquipement;
            client.Abonnement.AccesPiscine = isAccesPiscine;

            client.DateCreationCompte = client.Abonnement.DateAbonnement;

            using (IDalClient service = new ClientService())
            {
                if (service.ClientExists(client.AdresseMail)) //TODO : Créer annotation pour tester l'existence des mails
                {
                    ModelState.AddModelError("AdresseMail", "Ce client existe déjà.");
                    return View(client);
                }
                else
                {
                    service.CreateClient(client);
                    return RedirectToAction("Index"); // Rediriger vers la page d'accueil ou une autre page
                }
            }
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
        public IActionResult SupprimerClient(Client client)
        {
            
            using (IDalClient service = new ClientService())
            {
                service.DeleteClient(client.Id);
            }
            HttpContext.SignOutAsync();//suppression du cookie de l'utilisateur
            return Redirect("/");
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
