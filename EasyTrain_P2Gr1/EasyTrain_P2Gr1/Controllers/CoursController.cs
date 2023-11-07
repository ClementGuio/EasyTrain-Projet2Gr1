using EasyTrain_P2Gr1.Controllers.Outils;
using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace EasyTrain_P2Gr1.Controllers
{
    public class CoursController : Controller
    {
        [Authorize(Roles = "Gestionnaire, Client")]
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Layout"] = RoleResolver.GetRoleLayout(HttpContext);
            ViewData["role"] = RoleResolver.GetRole(HttpContext);
            List<Cours> cours;
            using (IDalCours service = new CoursService())
            {
                cours = service.GetCours();
            }
            return View("ListeCours", cours);
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public ActionResult CreerCours()
        {
            FormulaireCoursViewModel model = new FormulaireCoursViewModel();
            using (IDalCoach service = new CoachService())
            {
                model.Coachs = service.GetCoachs();
            };
            using (IDalSalle service = new SalleService())
            {
                model.Salles = service.GetSalles();
            };

            return View(model);
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public ActionResult CreerCours(FormulaireCoursViewModel model)
        {

            if (!ModelState.IsValid) //AIDE : On teste la validation du formulaire
            {
                return View(model);
            }
            Salle salle;
            using (IDalSalle service = new SalleService())
            {
                salle = service.GetSalle(model.SalleId);
            };
            Coach coach;
            using (IDalCoach service = new CoachService())
            {
                coach = service.GetCoach(model.CoachId);
            }
            Cours cours = new Cours
            {
                Titre = model.Titre,
                NbParticipants = model.NbParticipants,
                Prix = model.Prix,
                DureeMinutes = model.DureeMinutes,
                Salle = salle,
                Coach = coach
            };
            using (IDalCours service = new CoursService())
            {
                service.CreateCours(cours);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult SupprimerCours(int id)
        {
            Cours cours;
            using (IDalCours service = new CoursService())
            {
                cours = service.GetCours(id);
            }
            return View(cours);
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult SupprimerCours(Cours cours)
        {
            Console.WriteLine(cours.Id);
            using (IDalCours service = new CoursService())
            {
                Cours coursSupp = service.GetCours(cours.Id);
                coursSupp.Supprime = true;
                service.UpdateCours(coursSupp);
            }
            return RedirectToAction("Index");
        }
    }
}
