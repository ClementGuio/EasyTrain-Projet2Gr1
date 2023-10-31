using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System;
using EasyTrain_P2Gr1.ViewModels;


namespace EasyTrain_P2Gr1.Controllers
{
    public class ReservationController : Controller
    {
        [HttpGet]
        public IActionResult ListeReservation()
        {
            List<Reservation> listeReservation;


            using (IDalReservation service = new ReservationService())
            {
                listeReservation = service.GetReservations();
            }
            return View(listeReservation);
        }

        [Authorize(Roles = "Client")]
        [HttpGet]
        public IActionResult CreerReservation()
        {
            
            List<CoursProgramme> coursProgrammes;
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                coursProgrammes = service.GetCoursProgrammes();
            }
            TestReservationViewModel rvm = new TestReservationViewModel
            {
                CoursProgrammes = coursProgrammes
            };             

            return View(rvm);
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        public IActionResult CreerReservation(TestReservationViewModel rvm)
        {

            CoursProgramme coursProgramme;
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                coursProgramme = service.GetCoursProgramme(rvm.CoursProgrammeId);
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
            

            if (reservation.Client.ReserverCoursProgramme(coursProgramme))
            { //Si la réservation a réussi
                using (IDalReservation service = new ReservationService())
                {
                    service.CreateReservation(reservation);
                }
                using (IDalCoursProgramme service = new CoursProgrammeService())
                {
                    service.UpdateCoursProgramme(coursProgramme);
                }
                return RedirectToAction("ConfirmationReservation");
            }
            else  // Si la réseservation a échoué
            {
                return View(reservation);
            }
        }

        [Authorize(Roles = "Client")]
        [HttpGet]
        public IActionResult SupprimerReservation()
        {
            string id = HttpContext.User.Identity.Name;

            Reservation reservation;
            using (IDalReservation service = new ReservationService())
            {
                reservation = service.GetReservation(id);
            }
            if (reservation != null)
            {
                return View(reservation);
            }


            return View("Error");
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        public IActionResult SupprimerReservation(Reservation reservation)
        {

            using (IDalReservation service = new ReservationService())
            {
                service.DeleteReservation(reservation.Id);
            }


            DateTime firstDate = DateTime.Now;
            DateTime secondDate = DateTime.Now.AddDays(2);
            TimeSpan diffOfDate = firstDate - secondDate;

            if (diffOfDate.Hours > 48) //TODO : Faire un fichier de constantes
            {
                Console.WriteLine(" vous avez droit à un remboursement...");
            }

            return Redirect("/");
        }


        //TODO : methode POST/GET SupprimerReservation
        //TODO : Si un client supprime une réservation, on le rembourse (voir les conditions dans le cdc) 
    }
}

