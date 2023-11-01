using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
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
    

    public IActionResult ListeEquipement()
        {
            List<Equipement>listeEquipement;

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

    [HttpGet]
    public IActionResult CreerEquipement()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreerEquipement(Equipement equipement)
    {
       
        using (IDalEquipement service = new EquipementService())
        {
            service.CreateEquipement(equipement);
        }
        return View();
    }

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
