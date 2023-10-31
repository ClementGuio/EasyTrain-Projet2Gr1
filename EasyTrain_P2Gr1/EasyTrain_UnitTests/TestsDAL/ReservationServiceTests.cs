using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EasyTrain_UnitTests.TestsDAL
{
    //TODO : Tests à compléter
    [Collection("sequential")]
    [DbCleanUp()]
    public class ReservationServiceTests
    {


        [Fact]
        public void TestGetReservations()
        {
            using (BddContext ctx = new BddContext())
            {
                ctx.Reservations.AddRange(new List<Reservation>() {

                new Reservation(),
                new Reservation()


            });

                ctx.SaveChanges();
            }


            List<Reservation> reservations;
            using (IDalReservation service = new ReservationService())
            {
                reservations = service.GetReservations();
            }
            Assert.NotEmpty(reservations);
            Assert.Equal(2, reservations.Count);

        }

        [Fact]

        public void TestGetReservation()
        {

            using (BddContext ctx = new BddContext())
            {
                ctx.Reservations.AddRange(new List<Reservation>()
                {
                new Reservation() { },
                new Reservation() { }
                });
                ctx.SaveChanges();
            }

            Reservation reservation;
            using (IDalReservation service = new ReservationService())
            {
                reservation = service.GetReservation(2);
            }
            Assert.NotNull(reservation);
            Assert.Same(reservation.CoursProgramme, reservation.Client);


        }

        [Fact]
        public void TestCreateReservation()
        {
            //Initialisation
            Client client = new Client
            {
                Nom = "BONNER",
                Prenom = "Henri",
                DateNaissance = new DateTime(1980, 12, 12),
                AdresseMail = "BONNER.Henri@gmail.com",
                MotDePasse = "mdp",
                DateAbonnement = new DateTime(2023, 3, 15),
                DateCreationCompte = new DateTime(2022, 4, 27)
            };
            Cours cours = new Cours()
            {
                Titre = "Musculation débutant",
                NbParticipants = 10,
                Prix = 23.5,
                Coach = new Coach()
                {
                    Nom = "Benani",
                    Prenom = "Alba",
                    AdresseMail = "albabenani@mail.com",
                    MotDePasse = "mdp",
                    DateNaissance = new DateTime(1995, 2, 13),
                    DateCreationCompte = new DateTime(2023, 5, 9)
                },
                Salle = new Salle { Nom = "Salle A", Type = "Muscu" }
            };
            CoursProgramme coursProgramme = new CoursProgramme()
            {
                DateDebut = new DateTime(2023, 11, 9, 10, 30, 0),
                DateFin = new DateTime(2023, 11, 9, 11, 15, 0),
                Cours = cours,
                PlacesLibres = cours.NbParticipants
            };
            Reservation reservation = new Reservation
            {
                Client = client,
                CoursProgramme = coursProgramme
            };
            //Execution
            using (IDalReservation service = new ReservationService())
            {
                service.CreateReservation(reservation);
            }
            //Verification
            Reservation reservationDb;
            using (BddContext ctx = new BddContext())
            {
                reservationDb = ctx.Reservations.Find(reservation.Id);
            }
            Assert.NotNull(reservationDb);
            
        }


        [Fact]
        public void TestDeleteReservation()
        {

            using (BddContext ctx = new BddContext())
            {
                ctx.Reservations.AddRange(new List<Reservation>()
                {
                new Reservation() {}
                });
                ctx.SaveChanges();
            }
            List<Reservation> reservations;

            using (IDalReservation service = new ReservationService())
            {
                service.DeleteReservation(1);
                reservations = service.GetReservations();
            }

            Assert.Empty(reservations);

        }


        [Fact]
        public void TestUpdateReservation()
        {
            Reservation reservation = new Reservation() {};


            using (BddContext ctx = new BddContext())
            {

                ctx.Reservations.AddRange(new List<Reservation>()
                {
                  reservation

                });
                ctx.SaveChanges();
            }





            using (IDalReservation service = new ReservationService())
            {
                service.UpdateReservation(reservation);

                reservation = service.GetReservation(1);
            }


            Assert.Same(reservation.CoursProgramme, reservation.Client);

        }
    }

}





    

