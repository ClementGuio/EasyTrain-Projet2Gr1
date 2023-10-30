﻿using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace EasyTrain_P2Gr1.Controllers
{
    public class PresencesController : Controller
    {

        [HttpGet]
        public IActionResult ListePresences()
        {
            List<Presences> listePresences;
            using (IDalPresences service = new PresencesService())
            {
                listePresences = service.GetPresences();

            }
            
            return View(listePresences);
        }


        [HttpGet]
        public IActionResult CreerPresences()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreerPresences(Presences Presences)
        { 
                using (IDalPresences service= new PresencesService())
              
                    service.CreatePresences(Presences);
                    TempData["Message"] = "nouvel Presences crée";
                    return RedirectToAction("ListePresencess");        
        }

        [HttpPost]
        public IActionResult SupprimerPresences(int id)
        {
            using (IDalPresences service = new PresencesService())
            {
                Presences Presences = service.GetPresence(id);

                if (Presences != null)
                {
                    service.DeletePresence(id);
                    TempData["Message"] = "Presences supprimé avec succès";
                }
                else
                {
                    TempData["Message"] = "Presences introuvable";
                }

                return RedirectToAction("ListePresencess");
            }
        }
    }

}
