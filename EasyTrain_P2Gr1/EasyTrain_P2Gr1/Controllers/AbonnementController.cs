using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace EasyTrain_P2Gr1.Controllers
{
    public class AbonnementController : Controller
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
            client.Abonnement.CalculerMensualite();
            Console.WriteLine(client.Abonnement.Mensualite);
            AbonnementViewModel avm = new AbonnementViewModel { Abonnement = client.Abonnement };
            return View("AfficherAbonnement",avm);
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult ListeAbonnements()
        {
            List<Abonnement> listeAbonnements;
            using (IDalAbonnement service = new AbonnementService())
            {
                listeAbonnements = service.GetAbonnements();
            }
            return View(listeAbonnements);
        }

        [HttpGet]
        public IActionResult CreerAbonnement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreerAbonnement(Abonnement abonnement)
        {
            Abonnement.CalculerMensualite(abonnement);
            abonnement.DateAbonnement = DateTime.Now;
            return RedirectToAction("CreerClient", "Client", abonnement);
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        public IActionResult ModifierAbonnement(Abonnement abonnement)
        {
            Client client;
            using (IDalClient service = new ClientService()) 
            {
                client = service.GetClient(HttpContext.User.Identity.Name);
            }
            abonnement.Id = client.Abonnement.Id;
            Console.WriteLine("ModifierAbonnement : "+abonnement.Id);
            using (IDalAbonnement service = new AbonnementService())
            {
                service.UpdateAbonnement(abonnement);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Client")]
        [HttpGet]
        public IActionResult SupprimerAbonnement(int id)
        {
            if (id != 0)
            {
                Abonnement abonnement;
                using (IDalAbonnement service = new AbonnementService())
                {
                    abonnement = service.GetAbonnement(id);
                }
                if (abonnement != null)
                {
                    return View(abonnement);
                }
            }
            return View("Error");
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        public IActionResult SupprimerAbonnement(Abonnement abonnement)
        {
            using (IDalAbonnement service = new AbonnementService())
            {
                service.DeleteAbonnement(abonnement.Id);
            }
            return RedirectToAction("ListeAbonnements");
        }
    }

}
