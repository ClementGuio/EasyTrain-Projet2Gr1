using EasyTrain_P2Gr1.Models;
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
    //TODO : Afficher et liste ne fonctionnent pas
    public class PresenceController : Controller
    {

        [HttpGet]
        public IActionResult ListePresences()
        {
            List<Presence> listePresences;
            using (IDalPresence service = new PresenceService())
            {
                listePresences = service.GetPresences();

            }
            
            return View(listePresences);
        }
    }
}
