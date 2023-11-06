using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authentication;
using EasyTrain_P2Gr1.ViewModels;

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
            List<Client> listeClient;
            using (IDalClient service = new ClientService())
            {
                listeClient = service.GetClients();
            }
            return View(listeClient);
        }

        [HttpGet]
        public IActionResult CreerClient(Abonnement abonnement)
        {
            InscriptionViewModel ivm = new InscriptionViewModel
            {
                NbCours = abonnement.NbCours,
                AccesPiscine = abonnement.AccesPiscine,
                AccesEscalade = abonnement.AccesEscalade,
                AccompagnementCoach = abonnement.AccompagnementCoach
            };
            return View(ivm);
        }


        [HttpPost]
        public IActionResult CreerClient(InscriptionViewModel ivm) //TODO : Abonnement pour un ancien client qui se réinscrit
        {
            if (!ModelState.IsValid)
            {
                return View(ivm);
            }
            DateTime date = DateTime.Now;
            Client client = new Client
            {
                Nom = ivm.Nom,
                Prenom = ivm.Prenom,
                DateNaissance = ivm.DateNaissance,
                AdresseMail = ivm.AdresseMail,
                MotDePasse = ivm.MotDePasse,
                DateCreationCompte = date,
                Abonnement = new Abonnement
                {
                    NbCours = ivm.NbCours,
                    AccesPiscine = ivm.AccesPiscine,
                    AccesEscalade = ivm.AccesEscalade,
                    AccompagnementCoach = ivm.AccompagnementCoach,
                    //TODO: calcul Mensualité
                    DateAbonnement = date,
                }

            };

            using (IDalClient service = new ClientService())
            {
                service.CreateClient(client);
            }
            return RedirectToAction("Index");
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
    }
}
