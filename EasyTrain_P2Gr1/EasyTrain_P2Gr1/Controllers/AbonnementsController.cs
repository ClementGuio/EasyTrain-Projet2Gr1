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
                using (IDalAbonnement service= new AbonnementService())
                {
                if (!service.AbonnementExiste(abonnement.Titre))

                {
                    service.CreateAbonnement(abonnement);
                    TempData["Message"] = "nouvel abonnement crée";
                    return RedirectToAction("ListeAbonnements");
                }
                else
                {
                    TempData["Message"] = "Un abonnement similaire existe !";
                    return View();
                }

            }
        
        }

        [HttpGet]
        public IActionResult ModifierAbonnement(int id)
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
            TempData["Message"] = "Abonnement introuvable";
            return RedirectToAction("ListeAbonnements");



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
                    existingAbonnement.Titre = abonnement.Titre;
                    existingAbonnement.Mensualite = abonnement.Mensualite;
                    // Mettez à jour d'autres propriétés si nécessaire

                    service.UpdateAbonnement(existingAbonnement);
                    TempData["Message"] = "Abonnement modifié avec succès";
                    return RedirectToAction("ListeAbonnements");
                }
            }
        }

        [HttpPost]
        public IActionResult SupprimerAbonnement(int id)
        {
            using (IDalAbonnement service = new AbonnementService())
            {
                Abonnement abonnement = service.GetAbonnement(id);

                if (abonnement != null)
                {
                    service.DeleteAbonnement(id);
                    TempData["Message"] = "Abonnement supprimé avec succès";
                }
                else
                {
                    TempData["Message"] = "Abonnement introuvable";
                }

                return RedirectToAction("ListeAbonnements");
            }
        }
    }

}
