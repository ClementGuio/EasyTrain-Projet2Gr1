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
using EasyTrain_P2Gr1.Controllers.Outils;

namespace EasyTrain_P2Gr1.Controllers
{
    public class ReservationController : Controller
    {
        [Authorize(Roles = "Gestionnaire, Client, Coach")]
        [HttpGet]
        public IActionResult Index() 
        {
            List<Reservation> listeReservation = new List<Reservation>();

            using (IDalReservation service = new ReservationService())
            {
                if (HttpContext.User.IsInRole("Client"))
                {
                    listeReservation = service.GetReservationsClient(HttpContext.User.Identity.Name);
                }
                else if (HttpContext.User.IsInRole("Coach"))
                {
                    listeReservation = service.GetReservationsCoach(HttpContext.User.Identity.Name);
                }
                else if (HttpContext.User.IsInRole("Gestionnaire"))
                {
                    listeReservation = service.GetReservations();
                }
                ViewData["Layout"] = RoleResolver.GetRoleLayout(HttpContext);
            } 
            return View("ListeReservation",listeReservation);
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
            ReservationViewModel rvm = new ReservationViewModel
            {
                CoursProgrammes = coursProgrammes
            };
            return View(rvm);
        }

        [Authorize(Roles = "Client")] //TODO: un client ne doit pas pouvoir réserver 2 fois le même cours
        [HttpPost]
        public IActionResult CreerReservation(ReservationViewModel rvm)
        {
            Console.WriteLine("Id cours : "+rvm.SelectCoursProgrammeId);
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
                return RedirectToAction("Index");
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
            //CoursProgramme cp;
            //using (IDalCoursProgramme service = new CoursProgrammeService())
            //{
            //    cp = service.GetCoursProgramme(reservation.CoursProgramme.Id);
            //}
            if (reservation != null)
            {
                return View(new ReservationViewModel { Reservation = reservation, SelectCoursProgrammeId = reservation.CoursProgramme.Id});
            }

            return View("Error");
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        public IActionResult SupprimerReservation(ReservationViewModel rvm)
        {
            Console.WriteLine("id cp : "+rvm.SelectCoursProgrammeId);
            CoursProgramme cp;
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                cp = service.GetCoursProgramme(rvm.SelectCoursProgrammeId);
            }
            DateTime firstDate = DateTime.Now;
            DateTime secondDate = cp.DateDebut;
            TimeSpan diffOfDate = firstDate - secondDate;
            if (diffOfDate.Hours > 48) //TODO : Faire un fichier de constantes
            {
                Console.WriteLine(" vous avez droit à un remboursement...");
            }
            using (IDalReservation service = new ReservationService())
            {
                service.DeleteReservation(rvm.Reservation.Id);
            }

            return RedirectToAction("Index");
        }
    }
}

