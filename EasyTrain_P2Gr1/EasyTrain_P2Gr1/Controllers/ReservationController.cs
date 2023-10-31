using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

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
            return View();
        }

        [HttpPost]

        public IActionResult CreerReservation(Reservation reservation)
        {

            CoursProgramme coursProgramme;
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                coursProgramme = service.GetCoursProgramme(reservation.CoursProgramme.Id);
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

    }


    }

               
        

        
        //TODO : methode POST/GET SupprimerReservation
        //TODO : Si un client supprime une réservation, on le rembourse (voir les conditions dans le cdc) 
    

