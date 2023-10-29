using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.Services.Interfaces
{
    public interface IDalReservation: IDisposable
    {
        List<Reservation> GetReservations();
        Reservation GetReservation(int Id);
        int CreateReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(int id);
    }
}
