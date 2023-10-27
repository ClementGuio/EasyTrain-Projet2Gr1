using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.ViewModels
{
    public class FormulaireCoursViewModel
    {
        public Cours Cours { get; set; }
        public int SalleId { get; set; }
        public int CoachId { get; set; }
        public List<SelectListItem> Coach { get; set; }
        public List<SelectListItem> Salle { get; set; }
    }
}
