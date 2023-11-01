using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Mvc;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Controllers
{
    //TODO : supprimer modifier, creer, supprimer
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
        public IActionResult CreerSalle()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreerSalle(Salle salle)
        {
           
            
                using (IDalSalle service = new SalleService())
                {
                
                service.CreateSalle(salle);
                  
        
                }
            
            return View(salle);
        }


        [HttpGet]
        public IActionResult ModifierSalle(int id)
        {

            if (id != 0) {
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
            
            using(IDalSalle service=new SalleService())
            {
                service.UpdateSalle(salle);

            }

            return View(salle);

        }


        [HttpGet]
        public IActionResult SupprimerSalle(int id)
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
        public IActionResult SupprimerSalle(Salle salle)
        {
            
            using (IDalSalle service = new SalleService())
            {
                service.DeleteSalle(salle.Id);

            }

            return View(salle);

        }


    }
}
