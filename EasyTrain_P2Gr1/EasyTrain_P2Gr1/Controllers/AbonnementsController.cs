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
    public class AbonnementsController : Controller
    {
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
        public IActionResult CreerAbonnements()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreerAbonnements(Abonnement abonnement)
        {
            abonnement.DateAbonnement = DateTime.Now;
            return View("~/Views/Client/CreerClient", abonnement);

        }
        [Authorize(Roles = "Client")]
        [HttpGet]
        public IActionResult ModifierAbonnement()
        {
            Client client;
            using (IDalClient service = new ClientService())
            {
                client = service.GetClient(HttpContext.User.Identity.Name);
            }
            if (client != null)
            {
                return View(client.Abonnement);
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult ModifierAbonnement(Abonnement abonnement)
        {
            using (IDalAbonnement service = new AbonnementService())
            {
                Abonnement existingAbonnement = service.GetAbonnement(abonnement.Id);

                if (existingAbonnement == null)
                {
                    TempData["Message"] = "Abonnement introuvable";
                    return RedirectToAction("ListeAbonnements");
                }
                else
                {
                    // Mettez à jour d'autres propriétés si nécessaire

                    service.UpdateAbonnement(existingAbonnement);
                    TempData["Message"] = "Abonnement modifié avec succès";
                    return RedirectToAction("ListeAbonnements");
                }
            }
        }


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
