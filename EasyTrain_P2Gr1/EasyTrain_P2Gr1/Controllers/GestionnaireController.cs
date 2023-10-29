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
                return View("AfficherProfilGestionnaire",gestionnaire);
            }

            return View("Error");
        }

        [Authorize(Roles = "Gestionnaire")]
        public IActionResult ListeGestionnaire() // Le nom de la méthode doit avoir le même nom que la vue
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
        public IActionResult CreerGestionnaire() // Vue de création de profil GET
        {
            return View();
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult CreerGestionnaire(Gestionnaire gestionnaire) // Vue de création de profil Post
        {
            gestionnaire.DateCreationCompte = DateTime.Now;
            using (IDalGestionnaire dal = new GestionnaireService())
            {
                dal.CreateGestionnaire(gestionnaire);
            }

            return View(gestionnaire);

        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult ModifierGestionnaire(int id) // Vue de modification de profil GET
        {
            if (id != 0)
            {
                Gestionnaire gestionnaire;
                using (IDalGestionnaire service = new GestionnaireService())
                {
                    gestionnaire = service.GetGestionnaire(id);

                }
                if (gestionnaire != null)
                {
                    return View(gestionnaire);
                }
            }
            return View("Error");

        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult ModifierGestionnaire(Gestionnaire gestionnaire) // Vue de modification de profil Post
        {
            using (IDalGestionnaire dal = new GestionnaireService())
            {
                dal.UpdateGestionnaire(gestionnaire);
            }

            return View(gestionnaire);

        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult SupprimerGestionnaire(int id) // Vue de suppression de profil GET
        {
            if (id != 0)
            {
                Gestionnaire gestionnaire;
                using (IDalGestionnaire service = new GestionnaireService())
                {
                    gestionnaire = service.GetGestionnaire(id);

                }
                if (gestionnaire != null)
                {
                    return View(gestionnaire);
                }
            }
            return View("Error");

        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult SupprimerGestionnaire(Gestionnaire gestionnaire) // Vue de suppression de profil Post
        {
            using (IDalGestionnaire dal = new GestionnaireService())
            {
                dal.DeleteGestionnaire(gestionnaire.Id);
            }
            HttpContext.SignOutAsync();
            return Redirect("/");

        }

    }
}
