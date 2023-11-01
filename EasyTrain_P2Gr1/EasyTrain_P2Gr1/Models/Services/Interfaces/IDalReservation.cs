using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.Services.Interfaces
{
    public interface IDalReservation: IDisposable
    {
        List<Reservation> GetReservations();
        List<Reservation> GetReservationsClient(int idClient);
        List<Reservation> GetReservationsClient(string strId);
        Reservation GetReservation(int Id);
        Reservation GetReservation(string StrId);
        int CreateReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(int id);
       
    }
}
