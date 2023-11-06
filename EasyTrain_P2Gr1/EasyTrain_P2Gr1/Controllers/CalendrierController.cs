using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Controllers
{
    public class CalendrierController : Controller
    {
        public IActionResult CalendrierUtilisateur()
        {
            List<CoursProgramme> listeCoursProgrammes;
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                listeCoursProgrammes = service.GetCoursProgrammesAVenir();
            }
            CalendrierViewModel cvm = new CalendrierViewModel(listeCoursProgrammes, 30);
            return View(cvm);
        }
    }
}
