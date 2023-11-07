using EasyTrain_P2Gr1.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class ReservationService : DisposableService, IDalReservation
    {

        public List<Reservation> GetReservations()
        {
            return this._bddContext.Reservations
                .Include(c => c.CoursProgramme)
                .ThenInclude(c => c.Cours)
                .ThenInclude(c => c.Coach)
                .Include(c => c.Client)
                .ToList();
        }

        public Reservation GetReservation(int id)
        {
            return _bddContext.Reservations.Include(c => c.CoursProgramme).Include(c => c.Client).FirstOrDefault(r => r.Id == id);
        }
        public Reservation GetReservation(string strId)
        {
            if (int.TryParse(strId, out int id))
            {
                return GetReservation(id);
            }
            return null;
        }


        public List<Reservation> GetReservationsClient(int idClient)
        {
            DateTime jour = DateTime.Now;
            return GetReservations().Where(r => r.Client.Id == idClient && r.CoursProgramme.DateDebut.CompareTo(jour) > 0).ToList();
        }

        public List<Reservation> GetReservationsClient(string strId)
        {
            if (int.TryParse(strId, out int id))
            {
                return GetReservationsClient(id);
            }
            return new List<Reservation>();
        }

        public List<Reservation> GetReservationsCoach(int idCoach)
        {
            DateTime jour = DateTime.Now;
            return GetReservations().Where(r => r.CoursProgramme.Cours.Coach.Id == idCoach && r.CoursProgramme.DateDebut.CompareTo(jour) > 0).ToList();
        }

        public List<Reservation> GetReservationsCoach(string strId)
        {
            if (int.TryParse(strId, out int id))
            {
                return GetReservationsCoach(id);
            }
            return new List<Reservation>();
        }

        public List<Client> GetClientsInscrits(CoursProgramme coursProgramme)
        {
            DateTime jour = DateTime.Now;
            return this._bddContext.Reservations.Where(r => r.CoursProgramme.Id == coursProgramme.Id && r.CoursProgramme.DateDebut.CompareTo(jour) > 0).Select(r => r.Client).ToList();
        }

        public int CreateReservation(Reservation reservation)
        {
            this._bddContext.Attach(reservation.Client);
            this._bddContext.Attach(reservation.CoursProgramme);
            this._bddContext.Reservations.Add(reservation);
            this._bddContext.SaveChanges();
            return reservation.Id;
        }

        public void UpdateReservation(Reservation reservation)
        {
            _bddContext.Reservations.Update(reservation);
            _bddContext.SaveChanges();
        }

        public void DeleteReservation(int id)
        {
            Reservation oldReservation = this._bddContext.Reservations.Find(id);
            if (oldReservation != null)
            {
                _bddContext.Reservations.Remove(oldReservation);
                _bddContext.SaveChanges();
            }
        }

    }
}
