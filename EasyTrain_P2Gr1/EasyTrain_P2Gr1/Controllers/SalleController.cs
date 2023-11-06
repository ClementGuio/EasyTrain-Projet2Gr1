using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Mvc;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace EasyTrain_P2Gr1.Controllers
{
    //TODO : ajouter AjouterEquipement(salleId)
    public class SalleController : Controller
    {
        [HttpGet]
        public IActionResult AfficherSalle(int id) //TODO : ne fonctionne pas
        {
            Salle salle;

            using (IDalSalle service = new SalleService())
            {
                salle = service.GetSalle(id);

            }
            if (salle != null)
            {
                return View(salle);
            }
            return View("Error");
        }
        [HttpGet]
        public IActionResult ListeSalle()
        {
            List<Salle> listeSalle;

            using (IDalSalle service = new SalleService())
            {
                listeSalle = service.GetSalles();
            }
            return View(listeSalle);
        }

        [HttpGet]
        public IActionResult ModifierSalle(int id)
        {

            if (id != 0)
            {
                Salle salle;
                using (IDalSalle service = new SalleService())
                {
                    salle = service.GetSalle(id);

                }
                if (salle != null)
                {
                    return View(salle);
                }
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult ModifierSalle(Salle salle)
        {
            using (IDalSalle service = new SalleService())
            {
                service.UpdateSalle(salle);

            }
            return View(salle);
        }


        [Authorize(Roles = "Gestionnaire")]
        [HttpGet]
        public IActionResult ListeSalleEquipement(int id)
        {
            Salle salle;
            using (IDalSalle service = new SalleService())
            {
                salle = service.GetSalle(id);
             }
            return View(salle);
        }

        [Authorize(Roles = "Gestionnaire")]
        [HttpPost]
        public IActionResult ListeSalleEquipement(Salle salle)
        {
            using (IDalSalle service = new SalleService())
            {
                service.UpdateSalle(salle);

            }
            return View("ListeSalle");
        }

    }
}
