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

        [HttpGet]
        public IActionResult CreerReservation()
        {
            List<Reservation> reservations;
            using (IDalReservation service = new ReservationService())
            {
                reservations = service.GetReservations();  
            }
            List<TestReservationViewModel> rvm = new List<TestReservationViewModel>();
            foreach (Reservation res in reservations)
            {
                rvm.Add(new TestReservationViewModel
                {
                    Reservation = res,
                    CoursProgrammeId = res.CoursProgramme.Id,
                    DateDebut = res.CoursProgramme.DateDebut
                }); 
            }

            return View(rvm);
        }

        [HttpPost]

        public IActionResult CreerReservation(TestReservationViewModel rvm)
        {

            CoursProgramme cours;
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                cours = service.GetCoursProgramme(rvm.CoursProgrammeId);
            }
            Client client;
            using(IDalClient service = new ClientService())
            {
                client = service.GetClient(HttpContext.User.Identity.Name);
            }
            Reservation reservation = new Reservation
            {
                CoursProgramme = cours,
                Client = client
            };
            using (IDalReservation service = new ReservationService())
            {
                service.CreateReservation(reservation);

            }

            if (reservation.Client.ReserverCoursProgramme(coursProgramme)) { //Si la réservation a réussi
                using (IDalReservation service = new ReservationService())
                {
                    service.CreateReservation(reservation);
                }
                using (IDalCoursProgramme service = new CoursProgrammeService())
                {
                    service.UpdateCoursProgramme(coursProgramme);
                    return RedirectToAction("ConfirmationReservation");
                }

            }
            else  // Si la réseservation a échoué
            {
                return View(reservation);
            }
        }
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

            if (diffOfDate.Hours > 48)
            {
                Console.WriteLine(" vous avez droit à un remboursement...");
            }

            return Redirect("/");
        }
      

        //TODO : methode POST/GET SupprimerReservation
        //TODO : Si un client supprime une réservation, on le rembourse (voir les conditions dans le cdc) 
    

