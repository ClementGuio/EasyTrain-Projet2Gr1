using EasyTrain_P2Gr1.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class ReservationService : DisposableService, IDalReservation
    {


        public Reservation GetReservation(int id)
        {
            return _bddContext.Reservations.Include(c => c.CoursProgramme).Include(c => c.Client).FirstOrDefault(r => r.Id == id);
        }

        public List<Reservation> GetReservations()
        {
            return this._bddContext.Reservations.Include(c => c.CoursProgramme).Include(c => c.Client).ToList();
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
