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

namespace EasyTrain_P2Gr1.Controllers
{
    public class CoursController : Controller
    {
        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult Index()
        {
            List<Cours> cours;
            using (IDalCours service = new CoursService())
            {
                cours = service.GetCours();
            }
            return View("ListeCours",cours);
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public ActionResult CreerCours()
        {
            FormulaireCoursViewModel model = new FormulaireCoursViewModel();
            using(IDalCoach service = new CoachService())
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

            //Console.WriteLine($"SalleId : {model.SalleId} ; CoachId : {model.CoachId}");
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
            //Console.WriteLine($"Salle : {salle.Id}, {salle.Nom}");
            Cours cours = new Cours
            {
                Titre = model.Titre,
                NbParticipants = model.NbParticipants,
                Prix = model.Prix,
                Salle = salle,
                Coach = coach
            };
            using (IDalCours service = new CoursService())
            {
                service.CreateCours(cours);
            }
            return RedirectToAction("Index");
        }

        //TODO : Pas de modification des cours
        //[Authorize(Roles = "Gestionnaire")]
        //[HttpGet]
        //public IActionResult ModifierCours(int id)
        //{
        //    Cours cours;
        //    using (IDalCours service = new CoursService())
        //    {
        //        cours = service.GetCours(id);
        //    }
        //    List<Salle> salles;
        //    using (IDalSalle service = new SalleService())
        //    {
        //        salles = service.GetSalles();
        //    }
        //    List<Coach> coachs;
        //    using (IDalCoach service = new CoachService())
        //    {
        //        coachs = service.GetCoachs();
        //    }

        //    FormulaireCoursViewModel fcm = new FormulaireCoursViewModel
        //    {
        //        Titre = cours.Titre,
        //        NbParticipants = cours.NbParticipants,
        //        Prix = cours.Prix,
        //        SalleId = cours.Salle.Id,
        //        CoachId = cours.Coach.Id,
        //        Salles = salles,
        //        Coachs = coachs
        //    };
        //    return View(fcm);
        //}

        //[Authorize(Roles = "Gestionnaire")]
        //[HttpPost]
        //public IActionResult ModifierCours(FormulaireCoursViewModel model)
        //{
        //    Salle salle;
        //    using (IDalSalle service = new SalleService())
        //    {
        //        salle = service.GetSalle(model.SalleId);
        //    };
        //    Coach coach;
        //    using (IDalCoach service = new CoachService())
        //    {
        //        coach = service.GetCoach(model.CoachId);
        //    }

        //    Cours cours = new Cours
        //    {
        //        Id = model.Id,
        //        Titre = model.Titre,
        //        NbParticipants = model.NbParticipants,
        //        Prix = model.Prix,
        //        Coach = coach,
        //        Salle = salle
        //    };

        //    using (IDalCours service = new CoursService())
        //    {
        //        service.UpdateCours(cours);
        //    }

        //    return RedirectToAction("Index");
        //}

        //TODO : Il manque les methodes GET/POST SupprimerCours
    }
}
