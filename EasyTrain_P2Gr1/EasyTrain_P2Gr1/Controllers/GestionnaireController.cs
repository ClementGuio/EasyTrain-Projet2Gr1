using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using System;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.ViewModels;

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

            return View(gestionnaire);

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
        public IActionResult DashboardGestionnaire()
        {
            List<Coach> listeCoach;
            List<Cours> listCours;
            List<Equipement> listeEquipements;
            List<Client> listeClients;
            List<Salle> listeSalles;


            using (IDalCoach service = new CoachService())
            {
                listeCoach = service.GetCoachs();
            }

            using (IDalCours coursService = new CoursService())
            {
                listCours = coursService.GetCours();
            }
            using (IDalEquipement service = new EquipementService())
            {
                listeEquipements = service.GetEquipements();
            }

            using (IDalSalle service = new SalleService())
            {
                listeSalles = service.GetSalles();
            }

            using (IDalClient service = new ClientService())
            {
                listeClients = service.GetClients();
            }




            var model = new DashboardGestionnaireViewModel
            {
                Coachs = listeCoach,
                Courses = listCours,
                Equipements = listeEquipements,
                Clients = listeClients,
                Salles = listeSalles,
                
        };
           
            return View(model);
        }
    }
}
