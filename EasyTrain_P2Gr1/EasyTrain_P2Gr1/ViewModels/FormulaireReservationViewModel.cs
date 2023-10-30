using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.ViewModels
{
    public class FormulaireReservationViewModel
    {

        public Reservation Reservation { get; set; }
        public int CoursProgrammeId { get; set; }

        
    }
}

