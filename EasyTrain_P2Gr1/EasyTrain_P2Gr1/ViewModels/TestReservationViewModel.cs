using Dynamitey.DynamicObjects;
using EasyTrain_P2Gr1.Models;
using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.ViewModels
{
    public class TestReservationViewModel
    {
        public Reservation Reservation { get; set; }
        public int CoursProgrammeId { get; set; }
        public List<CoursProgramme> CoursProgrammes {get; set;}
    }
}
