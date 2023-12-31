﻿using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authentication;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.ViewModels;

namespace EasyTrain_P2Gr1.Controllers
{
    //TODO : Créer viewmodel pour modifier (problème de validation)
    public class CoachController : Controller
    {
        [Authorize(Roles = "Coach")]
        [HttpGet]
        public IActionResult Index()
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
            Coach coach;
            using (IDalCoach service = new CoachService())
            {
                coach = service.GetCoach(HttpContext.User.Identity.Name);

            }
            if (coach != null)
            {
                return View("AfficherProfilCoach", coach);
            }
            return View("Error");
        }

        [HttpGet]
        public IActionResult ListeCoach() // Le nom de la méthode doit avoir le même nom que la vue
        {
            if (HttpContext.User.Identity.Name != null)
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
            }
            List<Coach> listeCoach;
            using (IDalCoach service = new CoachService())
            {
                listeCoach = service.GetCoachs();
            }
            return View(listeCoach);
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult CreerCoach()
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
            Coach coach = new Coach { DateCreationCompte = DateTime.Now };
            return View(coach);
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult CreerCoach(Coach coach)
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
            coach.DateCreationCompte = DateTime.Now;
            using (IDalCoach service = new CoachService())
            {
                service.CreateCoach(coach);
            }
            return RedirectToAction("ListeCoach");
        }

        [Authorize(Roles = "Coach")]
        [HttpGet]
        public IActionResult ModifierCoach()
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

            string id = HttpContext.User.Identity.Name;

            Coach coach;
            using (IDalCoach service = new CoachService())
            {
                coach = service.GetCoach(id);

            }
            if (coach != null)
            {
                return View(coach);
            }


            return View("Error");
        }

        [Authorize(Roles = "Coach")]
        [HttpPost]
        public IActionResult ModifierCoach(Coach coach)
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
            using (IDalCoach service = new CoachService())
            {
                service.UpdateCoach(coach);
            }
            return RedirectToAction("Index", coach);
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult GestionnaireModifierCoach(int id)
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

            Coach coach;
            using (IDalCoach service = new CoachService())
            {
                coach = service.GetCoach(id);

            }
            if (coach != null)
            {
                return View("ModifierCoach", coach);
            }


            return View("Error");
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult GestionnaireModifierCoach(Coach coach)
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

            using (IDalCoach service = new CoachService())
            {
                service.UpdateCoach(coach);
            }
            return RedirectToAction("ListeCoach");
        }

        [Authorize(Roles = "Coach")]
        [HttpGet]
        public IActionResult SupprimerCoach()
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
            string id = HttpContext.User.Identity.Name;

            Coach coach;
            using (IDalCoach service = new CoachService())
            {
                coach = service.GetCoach(id);
            }
            if (coach != null)
            {
                return View(coach);
            }
            return View("Error");
        }

        [Authorize(Roles = "Coach")]
        [HttpPost]
        public IActionResult SupprimerCoach(Coach coach)
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
            using (IDalCoach service = new CoachService())
            {
                service.DeleteCoach(coach.Id);
            }
            HttpContext.SignOutAsync();
            return Redirect("/");
        }


        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult GestionnaireSupprimerCoach(int id)
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

            Coach coach;
            using (IDalCoach service = new CoachService())
            {
                coach = service.GetCoach(id);
            }
            if (coach != null)
            {
                return View("SupprimerCoach", coach);
            }
            return View("Error");
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult GestionnaireSupprimerCoach(Coach coach)
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

            using (IDalCoach service = new CoachService())
            {
                service.DeleteCoach(coach.Id);
            }
            return RedirectToAction("ListeCoach");
        }

        public IActionResult DashboardCoach()
        {
            List<Coach> listeCoach;
            List<Cours> listCours;
            List<Equipement> listeEquipements;
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
            var model = new DashboardCoachViewModel
            {
                Coachs = listeCoach,
                Cours = listCours,
                Equipements = listeEquipements,
                Salles = listeSalles,
            };
            return View(model);
        }
    }
}
    
