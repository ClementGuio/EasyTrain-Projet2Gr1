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
        [Authorize(Roles = "Gestionnaire, Client, Coach")]
        [HttpGet]
        public IActionResult ListeReservation() //TODO : ListeReservation pour le Client affiches SES reservations
        {
            List<Reservation> listeReservation = new List<Reservation>();

            using (IDalReservation service = new ReservationService())
            {
                if (HttpContext.User.IsInRole("Client"))
                {
                    listeReservation = service.GetReservationsClient(HttpContext.User.Identity.Name);
                }
                //listeReservation = service.GetReservations();
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
            FormulaireReservationViewModel rvm = new FormulaireReservationViewModel
            {
                CoursProgrammes = coursProgrammes
            };

            return View(rvm);
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        public IActionResult CreerReservation(FormulaireReservationViewModel rvm)
        {

            CoursProgramme coursProgramme;
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                coursProgramme = service.GetCoursProgramme(rvm.SelectCoursProgrammeId);
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
        public IActionResult SupprimerReservation(int id) //TODO : faire un viewmodel
        {
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
            DateTime firstDate = DateTime.Now;
            DateTime secondDate = reservation.CoursProgramme.DateDebut;
            TimeSpan diffOfDate = firstDate - secondDate;
            if (diffOfDate.Hours > 48) //TODO : Faire un fichier de constantes
            {
                Console.WriteLine(" vous avez droit à un remboursement...");
            }
            using (IDalReservation service = new ReservationService())
            {
                service.DeleteReservation(reservation.Id);
            }

            return Redirect("/");
        }
    }
}

