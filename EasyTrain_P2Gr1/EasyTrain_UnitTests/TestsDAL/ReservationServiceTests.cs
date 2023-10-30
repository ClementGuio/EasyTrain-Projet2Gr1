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

            Reservation reservation = new Reservation() { };


            using (IDalReservation service = new ReservationService())
            {
                service.CreateReservation(reservation);

            }


            using (BddContext ctx = new BddContext())
            {
                reservation = ctx.Reservations.Find(1);
            }
            Assert.Same(reservation.CoursProgramme, reservation.Client);
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





    

