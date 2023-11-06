using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using System;

namespace EasyTrain_P2Gr1.Controllers
{
    //TODO : Créer viewmodel pour modifier (problème de validation)
    public class GestionnaireController : Controller
    {
        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult Index()
        {
            Gestionnaire gestionnaire;
            using (IDalGestionnaire service = new GestionnaireService())
            {
                gestionnaire = service.GetGestionnaire(HttpContext.User.Identity.Name);
            }
            if (gestionnaire != null)
            {
                return View("AfficherProfilGestionnaire", gestionnaire);
            }

            return View("Error");
        }

        [Authorize(Roles = "Gestionnaire")]
        public IActionResult ListeGestionnaire() 
        {
            List<Gestionnaire> listeGestionnaire;
            using (IDalGestionnaire service = new GestionnaireService())
            {
                listeGestionnaire = service.GetGestionnaires();
            }
            return View(listeGestionnaire);
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult CreerGestionnaire() 
        {
            return View();
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult CreerGestionnaire(Gestionnaire gestionnaire) 
        {
            gestionnaire.DateCreationCompte = DateTime.Now;
            using (IDalGestionnaire dal = new GestionnaireService())
            {
                dal.CreateGestionnaire(gestionnaire);
            }

            return View("ListeGestionnaire");

        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult GestionnaireModifierGestionnaire(int id)
        {
            Gestionnaire gestionnaire;
            using (IDalGestionnaire service = new GestionnaireService())
            {
                gestionnaire = service.GetGestionnaire(id);

            }

            if (gestionnaire != null)
            {
                return View("ModifierGestionnaire",gestionnaire);
            }

            return View("Error");

        }
        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult GestionnaireModifierGestionnaire(Gestionnaire gestionnaire)
        {
            using (IDalGestionnaire dal = new GestionnaireService())
            {
                dal.UpdateGestionnaire(gestionnaire);
            }

            return RedirectToAction("ListeGestionnaire");
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult ModifierGestionnaire() 
        {
            string id = HttpContext.User.Identity.Name;//AIDE : Recupération de l'id dans le cookie
            

            Gestionnaire gestionnaire;
            using (IDalGestionnaire service = new GestionnaireService())
            {
                gestionnaire = service.GetGestionnaire(id);

            }

            if (gestionnaire != null)
            {
                return View(gestionnaire);
            }

            return View("Error");

        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult ModifierGestionnaire(Gestionnaire gestionnaire) 
        {
            using (IDalGestionnaire dal = new GestionnaireService())
            {
                dal.UpdateGestionnaire(gestionnaire);
            }

            return RedirectToAction("Index",gestionnaire);

        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult SupprimerGestionnaire() 
        {
            string id = HttpContext.User.Identity.Name;

            Gestionnaire gestionnaire;
            using (IDalGestionnaire service = new GestionnaireService())
            {
                gestionnaire = service.GetGestionnaire(id);
            }
            if (gestionnaire != null)
            {
                return View(gestionnaire);
            }
            return View("Error");
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult SupprimerGestionnaire(Gestionnaire gestionnaire) 
        {
            using (IDalGestionnaire dal = new GestionnaireService())
            {
                dal.DeleteGestionnaire(gestionnaire.Id);
            }
            HttpContext.SignOutAsync(); 
            return Redirect("/");
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult GestionnaireSupprimerGestionnaire(int id)
        {

            Gestionnaire gestionnaire;
            using (IDalGestionnaire service = new GestionnaireService())
            {
                gestionnaire = service.GetGestionnaire(id);
            }
            if (gestionnaire != null)
            {
                return View("SupprimerGestionnaire", gestionnaire);
            }
            return View("Error");
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult GestionnaireSupprimerGestionnaire(Gestionnaire gestionnaire)
        {
            using (IDalGestionnaire dal = new GestionnaireService())
            {
                dal.DeleteGestionnaire(gestionnaire.Id);
            }
            return RedirectToAction("ListeGestionnaire");
        }
    }
}
