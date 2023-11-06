using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using Microsoft.AspNetCore.Http;

namespace EasyTrain_P2Gr1.Controllers
{

    public class CalendrierController : Controller
    {
        [HttpGet]
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


        public IActionResult CalendrierReservation(int id)
        {

            CoursProgramme coursProgramme;
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                coursProgramme = service.GetCoursProgramme(id);
            }
            Client client;
            using (IDalClient service = new ClientService())
            {
                client = service.GetClient(HttpContext.User.Identity.Name);
            }
            Reservation reservation = new Reservation
            {
                CoursProgramme = coursProgramme,
                Client = client
            };

            if (coursProgramme.PlacesLibres > 0)
            {
                coursProgramme.PlacesLibres--;
                using (IDalReservation service = new ReservationService())
                {
                    service.CreateReservation(reservation);
                }
                using (IDalCoursProgramme service = new CoursProgrammeService())
                {
                    service.UpdateCoursProgramme(coursProgramme);
                }
                return RedirectToAction("Index", "Reservation");
            }
            return View ("CalendrierUtilisateur");



            

        }
    }
}
