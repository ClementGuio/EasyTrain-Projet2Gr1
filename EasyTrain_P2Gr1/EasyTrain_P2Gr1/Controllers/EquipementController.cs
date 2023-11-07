using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Controllers
{
    public class EquipementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GestionnaireListeEquipement()
        {
            List<Equipement> listeEquipement;

            using (IDalEquipement service = new EquipementService())
            {
                listeEquipement = service.GetEquipements();
            }
            return View(listeEquipement);
        }
        public IActionResult ListeEquipement()
        {
            List<Equipement> listeEquipement;

            using (IDalEquipement service = new EquipementService())
            {
                listeEquipement = service.GetEquipements();
            }
            return View(listeEquipement);
        }
        public IActionResult AfficherEquipement(int id)
        {
            Equipement equipement;
            using (IDalEquipement service = new EquipementService())
            {
                equipement = service.GetEquipement(id);

            }
            if (equipement != null)
            {
                return View(equipement);
            }
            return View("Error");
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult CreerEquipement()
        {
            return View();
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult CreerEquipement(Equipement equipement)
        {

            using (IDalEquipement service = new EquipementService())
            {
                service.CreateEquipement(equipement);
            }
            return RedirectToAction("GestionnaireListeEquipement", "Equipement");
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult SupprimerEquipement(int id)
        {
            if (id != 0)
            {
                Equipement equipement;
                using (IDalEquipement service = new EquipementService())
                {
                    equipement = service.GetEquipement(id);
                }
                if (equipement != null)
                {
                    return View(equipement);
                }

            }
            return View("Error");
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult SupprimerEquipement(Equipement equipement)
        {
            using (IDalEquipement service = new EquipementService())
            {
                service.DeleteEquipement(equipement.Id);
            }
            return View();
        }
    }
}
