using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using EasyTrain_P2Gr1.Models;

namespace EasyTrain_P2Gr1.ViewModels
{
    public class FormulaireCoursProgrammeViewModel
    {
        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        public int CoursId { get; set; }

        public IEnumerable<Cours> Cours { get; set; }
    }
}
