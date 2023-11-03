using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authentication;

namespace EasyTrain_P2Gr1.Controllers
{
    //TODO : Créer viewmodel pour modifier (problème de validation)
    public class CoachController : Controller
    {
        [Authorize(Roles = "Coach")]
        [HttpGet]
        public IActionResult Index()
        {
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
            Coach coach = new Coach { DateCreationCompte = DateTime.Now };
            return View(coach);
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult CreerCoach(Coach coach)
        {
            coach.DateCreationCompte = DateTime.Now;
            using (IDalCoach service = new CoachService())
            {
                service.CreateCoach(coach);
            }
            return View();
        }

        [Authorize(Roles = "Coach")]
        [HttpGet]
        public IActionResult ModifierCoach()
        {
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
            using (IDalCoach service = new CoachService())
            {
                service.UpdateCoach(coach);
            }
            return View();
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult GestionnaireModifierCoach(int id)
        {
             Coach coach;
            using (IDalCoach service = new CoachService())
            {
                coach = service.GetCoach(id);

            }
            if (coach != null)
            {
                return View("ModifierCoach",coach);
            }


            return View("Error");
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult GestionnaireModifierCoach(Coach coach)
        {
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
            using (IDalCoach service = new CoachService())
            {
                service.DeleteCoach(coach.Id);
            }
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
